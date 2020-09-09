/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
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
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class MapInfoPointDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMapInfoPointDBService MapInfoPointDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MapInfoPoint mapInfoPoint { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfoPointDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfoPointDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mapInfoPoint = GetFilledRandomMapInfoPoint("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfoPoint_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMapInfoPointList = await MapInfoPointDBService.GetMapInfoPointList();
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointList.Result).Value);
            List<MapInfoPoint> mapInfoPointList = (List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value;

            count = mapInfoPointList.Count();

            MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mapInfoPoint.MapInfoPointID   (Int32)
            // -----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.MapInfoPointID = 0;

            var actionMapInfoPoint = await MapInfoPointDBService.Put(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.MapInfoPointID = 10000000;
            actionMapInfoPoint = await MapInfoPointDBService.Put(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID", AllowableTVtypeList = )]
            // mapInfoPoint.MapInfoID   (Int32)
            // -----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.MapInfoID = 0;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // mapInfoPoint.Ordinal   (Int32)
            // -----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.Ordinal = -1;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            //Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // mapInfoPoint.Lat   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Lat]

            //CSSPError: Type not implemented [Lat]

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.Lat = -91.0D;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            //Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.Lat = 91.0D;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            //Assert.AreEqual(count, mapInfoPointDBService.GetMapInfoPointList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // mapInfoPoint.Lng   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Lng]

            //CSSPError: Type not implemented [Lng]

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.Lng = -181.0D;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            //Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.Lng = 181.0D;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            //Assert.AreEqual(count, mapInfoPointDBService.GetMapInfoPointList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.LastUpdateDate_UTC = new DateTime();
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);
            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mapInfoPoint.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.LastUpdateContactTVItemID = 0;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.LastUpdateContactTVItemID = 1;
            actionMapInfoPoint = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.IsType<BadRequestObjectResult>(actionMapInfoPoint.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MapInfoPoint
            var actionMapInfoPointAdded = await MapInfoPointDBService.Post(mapInfoPoint);
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointAdded.Result).Value);
            MapInfoPoint mapInfoPointAdded = (MapInfoPoint)((OkObjectResult)actionMapInfoPointAdded.Result).Value;
            Assert.NotNull(mapInfoPointAdded);

            // List<MapInfoPoint>
            var actionMapInfoPointList = await MapInfoPointDBService.GetMapInfoPointList();
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointList.Result).Value);
            List<MapInfoPoint> mapInfoPointList = (List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value;

            int count = ((List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MapInfoPoint> with skip and take
            var actionMapInfoPointListSkipAndTake = await MapInfoPointDBService.GetMapInfoPointList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointListSkipAndTake.Result).Value);
            List<MapInfoPoint> mapInfoPointListSkipAndTake = (List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mapInfoPointList[0].MapInfoPointID == mapInfoPointListSkipAndTake[0].MapInfoPointID);

            // Get MapInfoPoint With MapInfoPointID
            var actionMapInfoPointGet = await MapInfoPointDBService.GetMapInfoPointWithMapInfoPointID(mapInfoPointList[0].MapInfoPointID);
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointGet.Result).Value);
            MapInfoPoint mapInfoPointGet = (MapInfoPoint)((OkObjectResult)actionMapInfoPointGet.Result).Value;
            Assert.NotNull(mapInfoPointGet);
            Assert.Equal(mapInfoPointGet.MapInfoPointID, mapInfoPointList[0].MapInfoPointID);

            // Put MapInfoPoint
            var actionMapInfoPointUpdated = await MapInfoPointDBService.Put(mapInfoPoint);
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointUpdated.Result).Value);
            MapInfoPoint mapInfoPointUpdated = (MapInfoPoint)((OkObjectResult)actionMapInfoPointUpdated.Result).Value;
            Assert.NotNull(mapInfoPointUpdated);

            // Delete MapInfoPoint
            var actionMapInfoPointDeleted = await MapInfoPointDBService.Delete(mapInfoPoint.MapInfoPointID);
            Assert.Equal(200, ((ObjectResult)actionMapInfoPointDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoPointDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMapInfoPointDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMapInfoPointDBService, MapInfoPointDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            MapInfoPointDBService = Provider.GetService<IMapInfoPointDBService>();
            Assert.NotNull(MapInfoPointDBService);

            return await Task.FromResult(true);
        }
        private MapInfoPoint GetFilledRandomMapInfoPoint(string OmitPropName)
        {
            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            if (OmitPropName != "MapInfoID") mapInfoPoint.MapInfoID = 1;
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 10);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;



            return mapInfoPoint;
        }
        private void CheckMapInfoPointFields(List<MapInfoPoint> mapInfoPointList)
        {
        }

        #endregion Functions private
    }
}
