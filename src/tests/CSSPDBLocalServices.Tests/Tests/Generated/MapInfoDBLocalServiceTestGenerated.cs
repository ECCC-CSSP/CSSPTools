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
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class MapInfoDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMapInfoDBLocalService MapInfoDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private MapInfo mapInfo { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfoDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfoDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mapInfo = GetFilledRandomMapInfo("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MapInfo_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMapInfoList = await MapInfoDBLocalService.GetMapInfoList();
            Assert.Equal(200, ((ObjectResult)actionMapInfoList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoList.Result).Value);
            List<MapInfo> mapInfoList = (List<MapInfo>)((OkObjectResult)actionMapInfoList.Result).Value;

            count = mapInfoList.Count();

            MapInfo mapInfo = GetFilledRandomMapInfo("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mapInfo.MapInfoID   (Int32)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.MapInfoID = 0;

            var actionMapInfo = await MapInfoDBLocalService.Put(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.MapInfoID = 10000000;
            actionMapInfo = await MapInfoDBLocalService.Put(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOtherMunicipality,LineOverflow,RainExceedance,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted)]
            // mapInfo.TVItemID   (Int32)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.TVItemID = 0;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.TVItemID = 2;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mapInfo.TVType   (TVTypeEnum)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.TVType = (TVTypeEnum)1000000;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // mapInfo.LatMin   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LatMin]

            //CSSPError: Type not implemented [LatMin]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMin = -91.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMin = 91.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoDBLocalService.GetMapInfoList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // mapInfo.LatMax   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LatMax]

            //CSSPError: Type not implemented [LatMax]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMax = -91.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMax = 91.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoDBLocalService.GetMapInfoList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // mapInfo.LngMin   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LngMin]

            //CSSPError: Type not implemented [LngMin]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMin = -181.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMin = 181.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoDBLocalService.GetMapInfoList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // mapInfo.LngMax   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LngMax]

            //CSSPError: Type not implemented [LngMax]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMax = -181.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMax = 181.0D;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            //Assert.AreEqual(count, mapInfoDBLocalService.GetMapInfoList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mapInfo.MapInfoDrawType   (MapInfoDrawTypeEnum)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.MapInfoDrawType = (MapInfoDrawTypeEnum)1000000;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mapInfo.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateDate_UTC = new DateTime();
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mapInfo.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateContactTVItemID = 0;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateContactTVItemID = 1;
            actionMapInfo = await MapInfoDBLocalService.Post(mapInfo);
            Assert.IsType<BadRequestObjectResult>(actionMapInfo.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post MapInfo
            var actionMapInfoAdded = await MapInfoDBLocalService.Post(mapInfo);
            Assert.Equal(200, ((ObjectResult)actionMapInfoAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoAdded.Result).Value);
            MapInfo mapInfoAdded = (MapInfo)((OkObjectResult)actionMapInfoAdded.Result).Value;
            Assert.NotNull(mapInfoAdded);

            // List<MapInfo>
            var actionMapInfoList = await MapInfoDBLocalService.GetMapInfoList();
            Assert.Equal(200, ((ObjectResult)actionMapInfoList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoList.Result).Value);
            List<MapInfo> mapInfoList = (List<MapInfo>)((OkObjectResult)actionMapInfoList.Result).Value;

            int count = ((List<MapInfo>)((OkObjectResult)actionMapInfoList.Result).Value).Count();
            Assert.True(count > 0);

            // Get MapInfo With MapInfoID
            var actionMapInfoGet = await MapInfoDBLocalService.GetMapInfoWithMapInfoID(mapInfoList[0].MapInfoID);
            Assert.Equal(200, ((ObjectResult)actionMapInfoGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoGet.Result).Value);
            MapInfo mapInfoGet = (MapInfo)((OkObjectResult)actionMapInfoGet.Result).Value;
            Assert.NotNull(mapInfoGet);
            Assert.Equal(mapInfoGet.MapInfoID, mapInfoList[0].MapInfoID);

            // Put MapInfo
            var actionMapInfoUpdated = await MapInfoDBLocalService.Put(mapInfo);
            Assert.Equal(200, ((ObjectResult)actionMapInfoUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoUpdated.Result).Value);
            MapInfo mapInfoUpdated = (MapInfo)((OkObjectResult)actionMapInfoUpdated.Result).Value;
            Assert.NotNull(mapInfoUpdated);

            // Delete MapInfo
            var actionMapInfoDeleted = await MapInfoDBLocalService.Delete(mapInfo.MapInfoID);
            Assert.Equal(200, ((ObjectResult)actionMapInfoDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMapInfoDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMapInfoDBLocalService, MapInfoDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            MapInfoDBLocalService = Provider.GetService<IMapInfoDBLocalService>();
            Assert.NotNull(MapInfoDBLocalService);

            return await Task.FromResult(true);
        }
        private MapInfo GetFilledRandomMapInfo(string OmitPropName)
        {
            MapInfo mapInfo = new MapInfo();

            if (OmitPropName != "TVItemID") mapInfo.TVItemID = 1;
            if (OmitPropName != "TVType") mapInfo.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LatMin") mapInfo.LatMin = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LatMax") mapInfo.LatMax = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LngMin") mapInfo.LngMin = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LngMax") mapInfo.LngMax = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "MapInfoDrawType") mapInfo.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mapInfo.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfo.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return mapInfo;
        }
        private void CheckMapInfoFields(List<MapInfo> mapInfoList)
        {
        }

        #endregion Functions private
    }
}