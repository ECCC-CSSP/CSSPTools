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
    public partial class TideSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITideSiteService tideSiteService { get; set; }
        private ITideSiteController tideSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideSiteController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tideSiteService);
            Assert.NotNull(tideSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideSiteController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTideSiteList = await tideSiteController.Get();
               Assert.Equal(200, ((ObjectResult)actionTideSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteList.Result).Value);
               List<TideSite> tideSiteList = (List<TideSite>)(((OkObjectResult)actionTideSiteList.Result).Value);

               int count = ((List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TideSiteID)
               var actionTideSite = await tideSiteController.Get(tideSiteList[0].TideSiteID);
               Assert.Equal(200, ((ObjectResult)actionTideSite.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSite.Result).Value);
               TideSite tideSite = (TideSite)(((OkObjectResult)actionTideSite.Result).Value);
               Assert.NotNull(tideSite);
               Assert.Equal(tideSiteList[0].TideSiteID, tideSite.TideSiteID);

               // testing Post(TideSite tideSite)
               tideSite.TideSiteID = 0;
               var actionTideSiteNew = await tideSiteController.Post(tideSite);
               Assert.Equal(200, ((ObjectResult)actionTideSiteNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteNew.Result).Value);
               TideSite tideSiteNew = (TideSite)(((OkObjectResult)actionTideSiteNew.Result).Value);
               Assert.NotNull(tideSiteNew);

               // testing Put(TideSite tideSite)
               var actionTideSiteUpdate = await tideSiteController.Put(tideSiteNew);
               Assert.Equal(200, ((ObjectResult)actionTideSiteUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteUpdate.Result).Value);
               TideSite tideSiteUpdate = (TideSite)(((OkObjectResult)actionTideSiteUpdate.Result).Value);
               Assert.NotNull(tideSiteUpdate);

               // testing Delete(TideSite tideSite)
               var actionTideSiteDelete = await tideSiteController.Delete(tideSiteUpdate);
               Assert.Equal(200, ((ObjectResult)actionTideSiteDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideSiteDelete.Result).Value);
               TideSite tideSiteDelete = (TideSite)(((OkObjectResult)actionTideSiteDelete.Result).Value);
               Assert.NotNull(tideSiteDelete);
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
            Services.AddSingleton<ITideSiteService, TideSiteService>();
            Services.AddSingleton<ITideSiteController, TideSiteController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tideSiteService = Provider.GetService<ITideSiteService>();
            Assert.NotNull(tideSiteService);
        
            await tideSiteService.SetCulture(culture);
        
            tideSiteController = Provider.GetService<ITideSiteController>();
            Assert.NotNull(tideSiteController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
