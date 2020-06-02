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
    public partial class HydrometricSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IHydrometricSiteService hydrometricSiteService { get; set; }
        private IHydrometricSiteController hydrometricSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HydrometricSiteController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(hydrometricSiteService);
            Assert.NotNull(hydrometricSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HydrometricSiteController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionHydrometricSiteList = await hydrometricSiteController.Get();
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
               List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)(((OkObjectResult)actionHydrometricSiteList.Result).Value);

               int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(HydrometricSiteID)
               var actionHydrometricSite = await hydrometricSiteController.Get(hydrometricSiteList[0].HydrometricSiteID);
               Assert.Equal(200, ((ObjectResult)actionHydrometricSite.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSite.Result).Value);
               HydrometricSite hydrometricSite = (HydrometricSite)(((OkObjectResult)actionHydrometricSite.Result).Value);
               Assert.NotNull(hydrometricSite);
               Assert.Equal(hydrometricSiteList[0].HydrometricSiteID, hydrometricSite.HydrometricSiteID);

               // testing Post(HydrometricSite hydrometricSite)
               hydrometricSite.HydrometricSiteID = 0;
               var actionHydrometricSiteNew = await hydrometricSiteController.Post(hydrometricSite);
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteNew.Result).Value);
               HydrometricSite hydrometricSiteNew = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteNew.Result).Value);
               Assert.NotNull(hydrometricSiteNew);

               // testing Put(HydrometricSite hydrometricSite)
               var actionHydrometricSiteUpdate = await hydrometricSiteController.Put(hydrometricSiteNew);
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteUpdate.Result).Value);
               HydrometricSite hydrometricSiteUpdate = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteUpdate.Result).Value);
               Assert.NotNull(hydrometricSiteUpdate);

               // testing Delete(HydrometricSite hydrometricSite)
               var actionHydrometricSiteDelete = await hydrometricSiteController.Delete(hydrometricSiteUpdate);
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteDelete.Result).Value);
               HydrometricSite hydrometricSiteDelete = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteDelete.Result).Value);
               Assert.NotNull(hydrometricSiteDelete);
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
            Services.AddSingleton<IHydrometricSiteService, HydrometricSiteService>();
            Services.AddSingleton<IHydrometricSiteController, HydrometricSiteController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            hydrometricSiteService = Provider.GetService<IHydrometricSiteService>();
            Assert.NotNull(hydrometricSiteService);
        
            await hydrometricSiteService.SetCulture(culture);
        
            hydrometricSiteController = Provider.GetService<IHydrometricSiteController>();
            Assert.NotNull(hydrometricSiteController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
