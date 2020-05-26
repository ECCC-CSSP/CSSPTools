using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            await Setup(new CultureInfo(culture));

            Assert.NotNull(configuration);
            Assert.NotNull(serviceCollection);
            Assert.NotNull(actionCommandDBService);

            Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);

            await actionCommandDBService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);

            Assert.Equal(0, actionCommandDBService.ActionCommandID);
            Assert.Equal("", actionCommandDBService.Action);
            Assert.Equal("", actionCommandDBService.Command);
            Assert.Equal("", actionCommandDBService.FullFileName);
            Assert.Equal("", actionCommandDBService.Description);
            Assert.Equal("", actionCommandDBService.ErrorText.ToString());
            Assert.Equal("", actionCommandDBService.ExecutionStatusText.ToString());
            Assert.Equal("", actionCommandDBService.FilesStatusText.ToString());
            Assert.Equal(0, actionCommandDBService.PercentCompleted);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_Get_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await actionCommandDBService.RefillAll();

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "run";
            actionCommandDBService.Command = "AngularEnumsGenerated";

            var actionActionCommand = await actionCommandDBService.Get();
            Assert.Equal(200, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionActionCommand.Result).Value);
            ActionCommand actionCommand = (ActionCommand)((OkObjectResult)actionActionCommand.Result).Value;
            Assert.Equal(actionCommandDBService.Action, actionCommand.Action);
            Assert.Equal(actionCommandDBService.Command, actionCommand.Command);
            Assert.True(actionCommand.ActionCommandID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_Update_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await actionCommandDBService.RefillAll();

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "run";
            actionCommandDBService.Command = "AngularEnumsGenerated";

            var actionActionCommand = await actionCommandDBService.Get();
            Assert.Equal(200, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionActionCommand.Result).Value);
            ActionCommand actionCommand = (ActionCommand)((OkObjectResult)actionActionCommand.Result).Value;
            Assert.Equal(actionCommandDBService.Action, actionCommand.Action);
            Assert.Equal(actionCommandDBService.Command, actionCommand.Command);
            Assert.True(actionCommand.ActionCommandID > 0);

            // Should update the existing object with info
            actionCommandDBService.ErrorText = new StringBuilder("Testing");
            actionCommandDBService.PercentCompleted = 33;
            actionActionCommand = await actionCommandDBService.Update();
            Assert.Equal(200, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionActionCommand.Result).Value);
            actionCommand = (ActionCommand)((OkObjectResult)actionActionCommand.Result).Value;
            Assert.Equal(actionCommandDBService.Action, actionCommand.Action);
            Assert.Equal(actionCommandDBService.Command, actionCommand.Command);
            Assert.True(actionCommand.ActionCommandID > 0);
            Assert.Equal("Testing", actionCommand.ErrorText);
            Assert.Equal(33, actionCommand.PercentCompleted);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_RefillAll_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            // Should Repopulate the ActionCommandDB.db database
            var actionBool = await actionCommandDBService.RefillAll();
            Assert.Equal(200, ((ObjectResult)actionBool.Result).StatusCode);

            var actionActionCommandList = await actionCommandDBService.GetAll();
            Assert.Equal(200, ((ObjectResult)actionActionCommandList.Result).StatusCode);
            Assert.Equal(112, ((List<ActionCommand>)((OkObjectResult)actionActionCommandList.Result).Value).Count);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_Get_BadRequests_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await actionCommandDBService.RefillAll();

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "run";
            actionCommandDBService.Command = "AngularEnumsGeneratedNotFound";

            var actionActionCommand = await actionCommandDBService.Get();
            Assert.Equal(400, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.Equal($"{ CultureServicesRes.CouldNotFindActionCommand } { string.Format(CultureServicesRes.WithAction_AndCommand_, actionCommandDBService.Action, actionCommandDBService.Command) }", ((BadRequestObjectResult)actionActionCommand.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_Update_BadRequests_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await actionCommandDBService.RefillAll();

            actionCommandDBService.ActionCommandID = 0;
            actionCommandDBService.Action = "run";
            actionCommandDBService.Command = "AngularEnumsGenerated";

            var actionActionCommand = await actionCommandDBService.Get();
            Assert.Equal(200, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionActionCommand.Result).Value);
            ActionCommand actionCommand = (ActionCommand)((OkObjectResult)actionActionCommand.Result).Value;
            Assert.Equal(actionCommandDBService.Action, actionCommand.Action);
            Assert.Equal(actionCommandDBService.Command, actionCommand.Command);
            Assert.True(actionCommand.ActionCommandID > 0);

            // Should update the existing object with info
            actionCommandDBService.Command = "";
            actionCommandDBService.ErrorText = new StringBuilder("Testing");
            actionCommandDBService.PercentCompleted = 33;
            actionActionCommand = await actionCommandDBService.Update();
            Assert.Equal(400, ((ObjectResult)actionActionCommand.Result).StatusCode);
            Assert.Equal($"{ string.Format(CultureServicesRes._IsRequied, "Command") }", ((BadRequestObjectResult)actionActionCommand.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ActionCommandDBService_SetCulture_Good_Test(string culture)
        {
            await Setup(new CultureInfo(culture));

            await actionCommandDBService.SetCulture(new CultureInfo(culture));
            Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);
        }
        #endregion Functions public

        #region Functions private
        private async Task Setup(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;

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
                    options.UseInMemoryDatabase($"DataSource={fiDB.FullName}");
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
            Assert.NotNull(actionCommandDBService);

            await actionCommandDBService.SetCulture(culture);
            Assert.Equal(culture, CultureServicesRes.Culture);

        }
        #endregion Functions private
    }
}
