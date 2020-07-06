/* Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UserServices.Models;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class AppTaskControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ICultureService CultureService { get; set; }
        private IAppTaskService appTaskService { get; set; }
        private IAppTaskController appTaskController { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppTaskController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(appTaskService);
            Assert.NotNull(appTaskController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppTaskController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionAppTaskList = await appTaskController.Get();
                Assert.Equal(200, ((ObjectResult)actionAppTaskList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskList.Result).Value);
                List<AppTask> appTaskList = (List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value;

                int count = ((List<AppTask>)((OkObjectResult)actionAppTaskList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(AppTaskID)
                var actionAppTask = await appTaskController.Get(appTaskList[0].AppTaskID);
                Assert.Equal(200, ((ObjectResult)actionAppTask.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTask.Result).Value);
                AppTask appTask = (AppTask)((OkObjectResult)actionAppTask.Result).Value;
                Assert.NotNull(appTask);
                Assert.Equal(appTaskList[0].AppTaskID, appTask.AppTaskID);

                // testing Post(AppTask appTask)
                appTask.AppTaskID = 0;
                var actionAppTaskNew = await appTaskController.Post(appTask);
                Assert.Equal(200, ((ObjectResult)actionAppTaskNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskNew.Result).Value);
                AppTask appTaskNew = (AppTask)((OkObjectResult)actionAppTaskNew.Result).Value;
                Assert.NotNull(appTaskNew);

                // testing Put(AppTask appTask)
                var actionAppTaskUpdate = await appTaskController.Put(appTaskNew);
                Assert.Equal(200, ((ObjectResult)actionAppTaskUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskUpdate.Result).Value);
                AppTask appTaskUpdate = (AppTask)((OkObjectResult)actionAppTaskUpdate.Result).Value;
                Assert.NotNull(appTaskUpdate);

                // testing Delete(int appTask.AppTaskID)
                var actionAppTaskDelete = await appTaskController.Delete(appTaskUpdate.AppTaskID);
                Assert.Equal(200, ((ObjectResult)actionAppTaskDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAppTaskDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionAppTaskDelete.Result).Value;
                Assert.True(retBool2);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IAppTaskService, AppTaskService>();
            Services.AddSingleton<IAppTaskController, AppTaskController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            appTaskService = Provider.GetService<IAppTaskService>();
            Assert.NotNull(appTaskService);

            appTaskController = Provider.GetService<IAppTaskController>();
            Assert.NotNull(appTaskController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
