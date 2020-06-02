using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
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
    public partial class AppErrLogControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IAppErrLogService appErrLogService { get; set; }
        private IAppErrLogController appErrLogController { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppErrLogController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(appErrLogService);
            Assert.NotNull(appErrLogController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppErrLogController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionAppErrLogList = await appErrLogController.Get();
               Assert.Equal(200, ((ObjectResult)actionAppErrLogList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogList.Result).Value);
               List<AppErrLog> appErrLogList = (List<AppErrLog>)(((OkObjectResult)actionAppErrLogList.Result).Value);

               int count = ((List<AppErrLog>)((OkObjectResult)actionAppErrLogList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(AppErrLogID)
               var actionAppErrLog = await appErrLogController.Get(appErrLogList[0].AppErrLogID);
               Assert.Equal(200, ((ObjectResult)actionAppErrLog.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLog.Result).Value);
               AppErrLog appErrLog = (AppErrLog)(((OkObjectResult)actionAppErrLog.Result).Value);
               Assert.NotNull(appErrLog);
               Assert.Equal(appErrLogList[0].AppErrLogID, appErrLog.AppErrLogID);

               // testing Post(AppErrLog appErrLog)
               appErrLog.AppErrLogID = 0;
               var actionAppErrLogNew = await appErrLogController.Post(appErrLog);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogNew.Result).Value);
               AppErrLog appErrLogNew = (AppErrLog)(((OkObjectResult)actionAppErrLogNew.Result).Value);
               Assert.NotNull(appErrLogNew);

               // testing Put(AppErrLog appErrLog)
               var actionAppErrLogUpdate = await appErrLogController.Put(appErrLogNew);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogUpdate.Result).Value);
               AppErrLog appErrLogUpdate = (AppErrLog)(((OkObjectResult)actionAppErrLogUpdate.Result).Value);
               Assert.NotNull(appErrLogUpdate);

               // testing Delete(AppErrLog appErrLog)
               var actionAppErrLogDelete = await appErrLogController.Delete(appErrLogUpdate);
               Assert.Equal(200, ((ObjectResult)actionAppErrLogDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppErrLogDelete.Result).Value);
               AppErrLog appErrLogDelete = (AppErrLog)(((OkObjectResult)actionAppErrLogDelete.Result).Value);
               Assert.NotNull(appErrLogDelete);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
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
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IAppErrLogService, AppErrLogService>();
            Services.AddSingleton<IAppErrLogController, AppErrLogController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            appErrLogService = Provider.GetService<IAppErrLogService>();
            Assert.NotNull(appErrLogService);
        
            await appErrLogService.SetCulture(culture);
        
            appErrLogController = Provider.GetService<IAppErrLogController>();
            Assert.NotNull(appErrLogController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
