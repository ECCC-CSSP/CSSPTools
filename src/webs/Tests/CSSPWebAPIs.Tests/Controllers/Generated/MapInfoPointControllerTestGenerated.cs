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
    public partial class MapInfoPointControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMapInfoPointService mapInfoPointService { get; set; }
        private IMapInfoPointController mapInfoPointController { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MapInfoPointController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mapInfoPointService);
            Assert.NotNull(mapInfoPointController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MapInfoPointController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMapInfoPointList = await mapInfoPointController.Get();
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointList.Result).Value);
               List<MapInfoPoint> mapInfoPointList = (List<MapInfoPoint>)(((OkObjectResult)actionMapInfoPointList.Result).Value);

               int count = ((List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MapInfoPointID)
               var actionMapInfoPoint = await mapInfoPointController.Get(mapInfoPointList[0].MapInfoPointID);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPoint.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPoint.Result).Value);
               MapInfoPoint mapInfoPoint = (MapInfoPoint)(((OkObjectResult)actionMapInfoPoint.Result).Value);
               Assert.NotNull(mapInfoPoint);
               Assert.Equal(mapInfoPointList[0].MapInfoPointID, mapInfoPoint.MapInfoPointID);

               // testing Post(MapInfoPoint mapInfoPoint)
               mapInfoPoint.MapInfoPointID = 0;
               var actionMapInfoPointNew = await mapInfoPointController.Post(mapInfoPoint);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointNew.Result).Value);
               MapInfoPoint mapInfoPointNew = (MapInfoPoint)(((OkObjectResult)actionMapInfoPointNew.Result).Value);
               Assert.NotNull(mapInfoPointNew);

               // testing Put(MapInfoPoint mapInfoPoint)
               var actionMapInfoPointUpdate = await mapInfoPointController.Put(mapInfoPointNew);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointUpdate.Result).Value);
               MapInfoPoint mapInfoPointUpdate = (MapInfoPoint)(((OkObjectResult)actionMapInfoPointUpdate.Result).Value);
               Assert.NotNull(mapInfoPointUpdate);

               // testing Delete(MapInfoPoint mapInfoPoint)
               var actionMapInfoPointDelete = await mapInfoPointController.Delete(mapInfoPointUpdate);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointDelete.Result).Value);
               MapInfoPoint mapInfoPointDelete = (MapInfoPoint)(((OkObjectResult)actionMapInfoPointDelete.Result).Value);
               Assert.NotNull(mapInfoPointDelete);
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
            Services.AddSingleton<IMapInfoPointService, MapInfoPointService>();
            Services.AddSingleton<IMapInfoPointController, MapInfoPointController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mapInfoPointService = Provider.GetService<IMapInfoPointService>();
            Assert.NotNull(mapInfoPointService);
        
            await mapInfoPointService.SetCulture(culture);
        
            mapInfoPointController = Provider.GetService<IMapInfoPointController>();
            Assert.NotNull(mapInfoPointController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
