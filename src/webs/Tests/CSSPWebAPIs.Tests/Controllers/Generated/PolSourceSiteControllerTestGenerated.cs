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
    public partial class PolSourceSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceSiteService polSourceSiteService { get; set; }
        private IPolSourceSiteController polSourceSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceSiteService);
            Assert.NotNull(polSourceSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceSiteList = await polSourceSiteController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteList.Result).Value);
               List<PolSourceSite> polSourceSiteList = (List<PolSourceSite>)(((OkObjectResult)actionPolSourceSiteList.Result).Value);

               int count = ((List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceSiteID)
               var actionPolSourceSite = await polSourceSiteController.Get(polSourceSiteList[0].PolSourceSiteID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSite.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSite.Result).Value);
               PolSourceSite polSourceSite = (PolSourceSite)(((OkObjectResult)actionPolSourceSite.Result).Value);
               Assert.NotNull(polSourceSite);
               Assert.Equal(polSourceSiteList[0].PolSourceSiteID, polSourceSite.PolSourceSiteID);

               // testing Post(PolSourceSite polSourceSite)
               polSourceSite.PolSourceSiteID = 0;
               var actionPolSourceSiteNew = await polSourceSiteController.Post(polSourceSite);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteNew.Result).Value);
               PolSourceSite polSourceSiteNew = (PolSourceSite)(((OkObjectResult)actionPolSourceSiteNew.Result).Value);
               Assert.NotNull(polSourceSiteNew);

               // testing Put(PolSourceSite polSourceSite)
               var actionPolSourceSiteUpdate = await polSourceSiteController.Put(polSourceSiteNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteUpdate.Result).Value);
               PolSourceSite polSourceSiteUpdate = (PolSourceSite)(((OkObjectResult)actionPolSourceSiteUpdate.Result).Value);
               Assert.NotNull(polSourceSiteUpdate);

               // testing Delete(PolSourceSite polSourceSite)
               var actionPolSourceSiteDelete = await polSourceSiteController.Delete(polSourceSiteUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteDelete.Result).Value);
               PolSourceSite polSourceSiteDelete = (PolSourceSite)(((OkObjectResult)actionPolSourceSiteDelete.Result).Value);
               Assert.NotNull(polSourceSiteDelete);
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
            Services.AddSingleton<IPolSourceSiteService, PolSourceSiteService>();
            Services.AddSingleton<IPolSourceSiteController, PolSourceSiteController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceSiteService = Provider.GetService<IPolSourceSiteService>();
            Assert.NotNull(polSourceSiteService);
        
            await polSourceSiteService.SetCulture(culture);
        
            polSourceSiteController = Provider.GetService<IPolSourceSiteController>();
            Assert.NotNull(polSourceSiteController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
