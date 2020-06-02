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
    public partial class VPScenarioLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IVPScenarioLanguageService vpScenarioLanguageService { get; set; }
        private IVPScenarioLanguageController vpScenarioLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPScenarioLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(vpScenarioLanguageService);
            Assert.NotNull(vpScenarioLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task VPScenarioLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionVPScenarioLanguageList = await vpScenarioLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionVPScenarioLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioLanguageList.Result).Value);
               List<VPScenarioLanguage> vpScenarioLanguageList = (List<VPScenarioLanguage>)(((OkObjectResult)actionVPScenarioLanguageList.Result).Value);

               int count = ((List<VPScenarioLanguage>)((OkObjectResult)actionVPScenarioLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(VPScenarioLanguageID)
               var actionVPScenarioLanguage = await vpScenarioLanguageController.Get(vpScenarioLanguageList[0].VPScenarioLanguageID);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioLanguage.Result).Value);
               VPScenarioLanguage vpScenarioLanguage = (VPScenarioLanguage)(((OkObjectResult)actionVPScenarioLanguage.Result).Value);
               Assert.NotNull(vpScenarioLanguage);
               Assert.Equal(vpScenarioLanguageList[0].VPScenarioLanguageID, vpScenarioLanguage.VPScenarioLanguageID);

               // testing Post(VPScenarioLanguage vpScenarioLanguage)
               vpScenarioLanguage.VPScenarioLanguageID = 0;
               var actionVPScenarioLanguageNew = await vpScenarioLanguageController.Post(vpScenarioLanguage);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioLanguageNew.Result).Value);
               VPScenarioLanguage vpScenarioLanguageNew = (VPScenarioLanguage)(((OkObjectResult)actionVPScenarioLanguageNew.Result).Value);
               Assert.NotNull(vpScenarioLanguageNew);

               // testing Put(VPScenarioLanguage vpScenarioLanguage)
               var actionVPScenarioLanguageUpdate = await vpScenarioLanguageController.Put(vpScenarioLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioLanguageUpdate.Result).Value);
               VPScenarioLanguage vpScenarioLanguageUpdate = (VPScenarioLanguage)(((OkObjectResult)actionVPScenarioLanguageUpdate.Result).Value);
               Assert.NotNull(vpScenarioLanguageUpdate);

               // testing Delete(VPScenarioLanguage vpScenarioLanguage)
               var actionVPScenarioLanguageDelete = await vpScenarioLanguageController.Delete(vpScenarioLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionVPScenarioLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionVPScenarioLanguageDelete.Result).Value);
               VPScenarioLanguage vpScenarioLanguageDelete = (VPScenarioLanguage)(((OkObjectResult)actionVPScenarioLanguageDelete.Result).Value);
               Assert.NotNull(vpScenarioLanguageDelete);
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
            Services.AddSingleton<IVPScenarioLanguageService, VPScenarioLanguageService>();
            Services.AddSingleton<IVPScenarioLanguageController, VPScenarioLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            vpScenarioLanguageService = Provider.GetService<IVPScenarioLanguageService>();
            Assert.NotNull(vpScenarioLanguageService);
        
            await vpScenarioLanguageService.SetCulture(culture);
        
            vpScenarioLanguageController = Provider.GetService<IVPScenarioLanguageController>();
            Assert.NotNull(vpScenarioLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
