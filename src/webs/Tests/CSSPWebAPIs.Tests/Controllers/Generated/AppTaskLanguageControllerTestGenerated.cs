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
    public partial class AppTaskLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IAppTaskLanguageService appTaskLanguageService { get; set; }
        private IAppTaskLanguageController appTaskLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppTaskLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(appTaskLanguageService);
            Assert.NotNull(appTaskLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppTaskLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionAppTaskLanguageList = await appTaskLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
               List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)(((OkObjectResult)actionAppTaskLanguageList.Result).Value);

               int count = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(AppTaskLanguageID)
               var actionAppTaskLanguage = await appTaskLanguageController.Get(appTaskLanguageList[0].AppTaskLanguageID);
               Assert.Equal(200, ((ObjectResult)actionAppTaskLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppTaskLanguage.Result).Value);
               AppTaskLanguage appTaskLanguage = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguage.Result).Value);
               Assert.NotNull(appTaskLanguage);
               Assert.Equal(appTaskLanguageList[0].AppTaskLanguageID, appTaskLanguage.AppTaskLanguageID);

               // testing Post(AppTaskLanguage appTaskLanguage)
               appTaskLanguage.AppTaskLanguageID = 0;
               var actionAppTaskLanguageNew = await appTaskLanguageController.Post(appTaskLanguage);
               Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppTaskLanguageNew.Result).Value);
               AppTaskLanguage appTaskLanguageNew = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageNew.Result).Value);
               Assert.NotNull(appTaskLanguageNew);

               // testing Put(AppTaskLanguage appTaskLanguage)
               var actionAppTaskLanguageUpdate = await appTaskLanguageController.Put(appTaskLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppTaskLanguageUpdate.Result).Value);
               AppTaskLanguage appTaskLanguageUpdate = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageUpdate.Result).Value);
               Assert.NotNull(appTaskLanguageUpdate);

               // testing Delete(AppTaskLanguage appTaskLanguage)
               var actionAppTaskLanguageDelete = await appTaskLanguageController.Delete(appTaskLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionAppTaskLanguageDelete.Result).Value);
               AppTaskLanguage appTaskLanguageDelete = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageDelete.Result).Value);
               Assert.NotNull(appTaskLanguageDelete);
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
            Services.AddSingleton<IAppTaskLanguageService, AppTaskLanguageService>();
            Services.AddSingleton<IAppTaskLanguageController, AppTaskLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            appTaskLanguageService = Provider.GetService<IAppTaskLanguageService>();
            Assert.NotNull(appTaskLanguageService);
        
            await appTaskLanguageService.SetCulture(culture);
        
            appTaskLanguageController = Provider.GetService<IAppTaskLanguageController>();
            Assert.NotNull(appTaskLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
