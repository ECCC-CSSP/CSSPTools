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
    public partial class TideLocationControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITideLocationService tideLocationService { get; set; }
        private ITideLocationController tideLocationController { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideLocationController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tideLocationService);
            Assert.NotNull(tideLocationController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideLocationController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTideLocationList = await tideLocationController.Get();
               Assert.Equal(200, ((ObjectResult)actionTideLocationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationList.Result).Value);
               List<TideLocation> tideLocationList = (List<TideLocation>)(((OkObjectResult)actionTideLocationList.Result).Value);

               int count = ((List<TideLocation>)((OkObjectResult)actionTideLocationList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TideLocationID)
               var actionTideLocation = await tideLocationController.Get(tideLocationList[0].TideLocationID);
               Assert.Equal(200, ((ObjectResult)actionTideLocation.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocation.Result).Value);
               TideLocation tideLocation = (TideLocation)(((OkObjectResult)actionTideLocation.Result).Value);
               Assert.NotNull(tideLocation);
               Assert.Equal(tideLocationList[0].TideLocationID, tideLocation.TideLocationID);

               // testing Post(TideLocation tideLocation)
               tideLocation.TideLocationID = 0;
               var actionTideLocationNew = await tideLocationController.Post(tideLocation);
               Assert.Equal(200, ((ObjectResult)actionTideLocationNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationNew.Result).Value);
               TideLocation tideLocationNew = (TideLocation)(((OkObjectResult)actionTideLocationNew.Result).Value);
               Assert.NotNull(tideLocationNew);

               // testing Put(TideLocation tideLocation)
               var actionTideLocationUpdate = await tideLocationController.Put(tideLocationNew);
               Assert.Equal(200, ((ObjectResult)actionTideLocationUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationUpdate.Result).Value);
               TideLocation tideLocationUpdate = (TideLocation)(((OkObjectResult)actionTideLocationUpdate.Result).Value);
               Assert.NotNull(tideLocationUpdate);

               // testing Delete(TideLocation tideLocation)
               var actionTideLocationDelete = await tideLocationController.Delete(tideLocationUpdate);
               Assert.Equal(200, ((ObjectResult)actionTideLocationDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationDelete.Result).Value);
               TideLocation tideLocationDelete = (TideLocation)(((OkObjectResult)actionTideLocationDelete.Result).Value);
               Assert.NotNull(tideLocationDelete);
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
            Services.AddSingleton<ITideLocationService, TideLocationService>();
            Services.AddSingleton<ITideLocationController, TideLocationController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tideLocationService = Provider.GetService<ITideLocationService>();
            Assert.NotNull(tideLocationService);
        
            await tideLocationService.SetCulture(culture);
        
            tideLocationController = Provider.GetService<ITideLocationController>();
            Assert.NotNull(tideLocationController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
