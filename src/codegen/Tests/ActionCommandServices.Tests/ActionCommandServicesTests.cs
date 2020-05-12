using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Xunit;
using ActionCommandServices.Resources;
using ActionCommandServices.Services;
using ActionCommandServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandDBServices.Tests
{
    public partial class ActionCommandServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IActionCommandService actionCommandService { get; set; }
        private IServiceProvider serviceProvider { get; set; }
        private string ActionCommandDB { get; set; } = "ActionCommandDB";
        #endregion Properties

        #region Constructors
        public ActionCommandServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandService_Constructors_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture), "appsettings.json");

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(actionCommandDBService);
            Assert.NotNull(actionCommandService);

            Assert.Equal(new CultureInfo(culture), AppRes.Culture);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandService_SetCulture_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture), "appsettings.json");

            await actionCommandService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), AppRes.Culture);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandService_RunActionCommand_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture), "appsettings.json");

            ActionCommand actionCommand = new ActionCommand()
            {
                Action = "run",
                Command = "EnumsGenerated_cs",
                //FullFileName = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe",
            };

            var actionActionCommand = await actionCommandService.RunActionCommand(actionCommand);
            Assert.Equal(200, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionActionCommand.Result).Value);
            actionCommand = (ActionCommand)((OkObjectResult)actionActionCommand.Result).Value;
            Assert.Equal(actionCommandDBService.Action, actionCommand.Action);
            Assert.Equal(actionCommandDBService.Command, actionCommand.Command);
            Assert.True(actionCommand.ActionCommandID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandService_RunActionCommand_ExePath_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture), "appsettings_bad1.json");

            ActionCommand actionCommand = new ActionCommand()
            {
                Action = "run",
                Command = "EnumsGenerated_cs",
                //FullFileName = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe",
            };

            var actionActionCommand = await actionCommandService.RunActionCommand(actionCommand);
            Assert.Equal(400, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionActionCommand.Result).Value);
            Assert.Contains(AppRes.ExePathIsEmpty, (string)((BadRequestObjectResult)actionActionCommand.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandService_RunActionCommand_CouldNotFindExePath_Error_Test(string culture)
        {
            Setup(new CultureInfo(culture), "appsettings_bad2.json");

            ActionCommand actionCommand = new ActionCommand()
            {
                Action = "run",
                Command = "EnumsGenerated_cs",
                //FullFileName = "C:\\CSSPTools\\src\\codegen\\EnumsGenerated_cs\\bin\\Debug\\netcoreapp3.1\\EnumsGenerated_cs.exe",
            };

            var actionActionCommand = await actionCommandService.RunActionCommand(actionCommand);
            Assert.Equal(400, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionActionCommand.Result).Value);

            string exePath = configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
            Assert.Contains(string.Format(AppRes.CouldNotFindExePath_, exePath), (string)((BadRequestObjectResult)actionActionCommand.Result).Value);
        }
        #endregion Functions public

        #region Functions private
        private void Setup(CultureInfo culture, string appsettingfilename)
        {
            AppRes.Culture = culture;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile(appsettingfilename)
                .Build();

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IActionCommandService, ActionCommandService>();

            IConfigurationSection connectionStringsSection = configuration.GetSection("ConnectionStrings");
            serviceCollection.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();
            Assert.NotNull(connectionStrings);

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Assert.False(string.IsNullOrWhiteSpace(appDataPath));

            FileInfo fiDB = new FileInfo(connectionStrings.ActionCommandDB.Replace("{appDataPath}", appDataPath));
            Assert.True(fiDB.Exists);

            serviceCollection.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.NotNull(serviceProvider);

            actionCommandDBService = serviceProvider.GetService<IActionCommandDBService>();
            Assert.NotNull(actionCommandDBService);

            actionCommandDBService.SetCulture(culture);

            actionCommandService = serviceProvider.GetService<IActionCommandService>();
            Assert.NotNull(actionCommandService);

            actionCommandService.SetCulture(culture);
        }
        #endregion Functions private

    }
}
