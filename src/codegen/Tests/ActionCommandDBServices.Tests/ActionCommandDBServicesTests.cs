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
using ActionCommandDBServices.Resources;

namespace ActionCommandDBServices.Tests
{
    public partial class ActionCommandDBServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IServiceProvider serviceProvider { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ActionCommandDBServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_Constructors_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(actionCommandDBService);

            Assert.Equal(new CultureInfo(culture), AppRes.Culture);

            await actionCommandDBService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), AppRes.Culture);

            Assert.Equal(0, actionCommandDBService.ActionCommandID);
            Assert.Equal("", actionCommandDBService.Action);
            Assert.Equal("", actionCommandDBService.Command);
            Assert.Equal("", actionCommandDBService.FullFileName);
            Assert.Equal("", actionCommandDBService.Description);
            Assert.Equal("", actionCommandDBService.TempStatusText.ToString());
            Assert.Equal("", actionCommandDBService.ErrorText.ToString());
            Assert.Equal("", actionCommandDBService.ExecutionStatusText.ToString());
            Assert.Equal("", actionCommandDBService.FilesStatusText.ToString());
            Assert.Equal(0, actionCommandDBService.PercentCompleted);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_CreateDeleteGetGetOrCreateUpdate_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "TestingAction";
            actionCommandDBService.Command = "TestingCommand";
            actionCommandDBService.FullFileName = "C:\\some\\path\\file.txt";
            actionCommandDBService.Description = "This would be the description";
            actionCommandDBService.TempStatusText = new StringBuilder("Some Temp Status Text");
            actionCommandDBService.ErrorText = new StringBuilder("Some Error Text");
            actionCommandDBService.ExecutionStatusText = new StringBuilder("Some Execution Status Text");
            actionCommandDBService.FilesStatusText = new StringBuilder("Some Files Status Text");
            actionCommandDBService.PercentCompleted = 10;

            // Clearing object in DB
            ActionCommand actionCommand = await actionCommandDBService.Get();

            if (actionCommand != null)
            {
                await actionCommandDBService.Delete();
                actionCommand = await actionCommandDBService.Get();
                Assert.Null(actionCommand);
            }

            actionCommand = await actionCommandDBService.Get();
            Assert.Null(actionCommand);

            // Creating object in DB
            actionCommand = await actionCommandDBService.Create();
            Assert.NotNull(actionCommand);

            // Should not create a second objct but just return the existing one
            actionCommand = await actionCommandDBService.Create();
            Assert.NotNull(actionCommand);

            // Should delete the object
            actionCommand = await actionCommandDBService.Delete();
            Assert.NotNull(actionCommand);

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "TestingAction";
            actionCommandDBService.Command = "TestingCommand";
            actionCommandDBService.FullFileName = "C:\\some\\path\\file.txt";
            actionCommandDBService.Description = "This would be the description";
            actionCommandDBService.TempStatusText = new StringBuilder("Some Temp Status Text");
            actionCommandDBService.ErrorText = new StringBuilder("Some Error Text");
            actionCommandDBService.ExecutionStatusText = new StringBuilder("Some Execution Status Text");
            actionCommandDBService.FilesStatusText = new StringBuilder("Some Files Status Text");
            actionCommandDBService.PercentCompleted = 10;

            actionCommand = await actionCommandDBService.Get();
            Assert.Null(actionCommand);

            // Recreating the object in DB using the GetOrCreate
            actionCommand = await actionCommandDBService.GetOrCreate();
            Assert.NotNull(actionCommand);

            actionCommand = await actionCommandDBService.Get();
            Assert.NotNull(actionCommand);

            // Should just return the existing object
            actionCommand = await actionCommandDBService.GetOrCreate();
            Assert.NotNull(actionCommand);

            // Should update the existing object with info
            actionCommandDBService.ErrorText = new StringBuilder("Testing");
            actionCommandDBService.TempStatusText = new StringBuilder("Bonjour");
            actionCommandDBService.PercentCompleted = 33;
            actionCommand = await actionCommandDBService.Update();
            Assert.NotNull(actionCommand);

            actionCommand = await actionCommandDBService.Get();
            Assert.Equal("Testing", actionCommand.ErrorText);
            Assert.Equal("Bonjour", actionCommand.TempStatusText);
            Assert.Equal(33, actionCommand.PercentCompleted);

            actionCommand = await actionCommandDBService.Get();
            Assert.NotNull(actionCommand);

            await actionCommandDBService.Delete();
            actionCommand = await actionCommandDBService.Get();
            Assert.Null(actionCommand);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_SetCulture_Good_Test(string culture)
        {
            Setup(new CultureInfo(culture));

            await actionCommandDBService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), AppRes.Culture);
        }
        #endregion Functions public

        #region Functions private
        private void Setup(CultureInfo culture)
        {
            AppRes.Culture = culture;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Assert.NotNull(configuration.GetValue<string>(DBFileName));

            FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));
            Assert.True(fiDB.Exists);

            try
            {
                serviceCollection.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }

            serviceProvider = serviceCollection.BuildServiceProvider();
            if (serviceProvider == null)
            {
                Assert.NotNull(serviceProvider);
            }

            actionCommandDBService = serviceProvider.GetService<IActionCommandDBService>();
            if (actionCommandDBService == null)
            {
                Assert.NotNull(actionCommandDBService);
            }
            actionCommandDBService.SetCulture(culture);

        }
        #endregion Functions private

    }
}
