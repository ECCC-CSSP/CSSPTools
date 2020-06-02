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
    public partial class MapInfoControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMapInfoService mapInfoService { get; set; }
        private IMapInfoController mapInfoController { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MapInfoController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mapInfoService);
            Assert.NotNull(mapInfoController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MapInfoController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMapInfoList = await mapInfoController.Get();
               Assert.Equal(200, ((ObjectResult)actionMapInfoList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoList.Result).Value);
               List<MapInfo> mapInfoList = (List<MapInfo>)(((OkObjectResult)actionMapInfoList.Result).Value);

               int count = ((List<MapInfo>)((OkObjectResult)actionMapInfoList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MapInfoID)
               var actionMapInfo = await mapInfoController.Get(mapInfoList[0].MapInfoID);
               Assert.Equal(200, ((ObjectResult)actionMapInfo.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfo.Result).Value);
               MapInfo mapInfo = (MapInfo)(((OkObjectResult)actionMapInfo.Result).Value);
               Assert.NotNull(mapInfo);
               Assert.Equal(mapInfoList[0].MapInfoID, mapInfo.MapInfoID);

               // testing Post(MapInfo mapInfo)
               mapInfo.MapInfoID = 0;
               var actionMapInfoNew = await mapInfoController.Post(mapInfo);
               Assert.Equal(200, ((ObjectResult)actionMapInfoNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoNew.Result).Value);
               MapInfo mapInfoNew = (MapInfo)(((OkObjectResult)actionMapInfoNew.Result).Value);
               Assert.NotNull(mapInfoNew);

               // testing Put(MapInfo mapInfo)
               var actionMapInfoUpdate = await mapInfoController.Put(mapInfoNew);
               Assert.Equal(200, ((ObjectResult)actionMapInfoUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoUpdate.Result).Value);
               MapInfo mapInfoUpdate = (MapInfo)(((OkObjectResult)actionMapInfoUpdate.Result).Value);
               Assert.NotNull(mapInfoUpdate);

               // testing Delete(MapInfo mapInfo)
               var actionMapInfoDelete = await mapInfoController.Delete(mapInfoUpdate);
               Assert.Equal(200, ((ObjectResult)actionMapInfoDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoDelete.Result).Value);
               MapInfo mapInfoDelete = (MapInfo)(((OkObjectResult)actionMapInfoDelete.Result).Value);
               Assert.NotNull(mapInfoDelete);
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
            Services.AddSingleton<IMapInfoService, MapInfoService>();
            Services.AddSingleton<IMapInfoController, MapInfoController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mapInfoService = Provider.GetService<IMapInfoService>();
            Assert.NotNull(mapInfoService);
        
            await mapInfoService.SetCulture(culture);
        
            mapInfoController = Provider.GetService<IMapInfoController>();
            Assert.NotNull(mapInfoController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
