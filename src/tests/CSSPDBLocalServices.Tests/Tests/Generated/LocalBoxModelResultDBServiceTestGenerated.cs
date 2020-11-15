/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalBoxModelResultDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalBoxModelResultDBService LocalBoxModelResultDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalBoxModelResult localBoxModelResult { get; set; }
        #endregion Properties

        #region Constructors
        public LocalBoxModelResultDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalBoxModelResultDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalBoxModelResultDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalBoxModelResult_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalBoxModelResultList = await LocalBoxModelResultDBService.GetLocalBoxModelResultList();
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultList.Result).Value);
            List<LocalBoxModelResult> localBoxModelResultList = (List<LocalBoxModelResult>)((OkObjectResult)actionLocalBoxModelResultList.Result).Value;

            count = localBoxModelResultList.Count();

            LocalBoxModelResult localBoxModelResult = GetFilledRandomLocalBoxModelResult("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localBoxModelResult.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localBoxModelResult.BoxModelResultID   (Int32)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.BoxModelResultID = 0;

            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Put(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.BoxModelResultID = 10000000;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Put(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = )]
            // localBoxModelResult.BoxModelID   (Int32)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.BoxModelID = 0;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localBoxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)1000000;
             actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // localBoxModelResult.Volume_m3   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Volume_m3]

            //CSSPError: Type not implemented [Volume_m3]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.Volume_m3 = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // localBoxModelResult.Surface_m2   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Surface_m2]

            //CSSPError: Type not implemented [Surface_m2]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.Surface_m2 = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // localBoxModelResult.Radius_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Radius_m]

            //CSSPError: Type not implemented [Radius_m]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.Radius_m = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.Radius_m = 100001.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 360)]
            // localBoxModelResult.LeftSideDiameterLineAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideDiameterLineAngle_deg]

            //CSSPError: Type not implemented [LeftSideDiameterLineAngle_deg]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // localBoxModelResult.CircleCenterLatitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CircleCenterLatitude]

            //CSSPError: Type not implemented [CircleCenterLatitude]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.CircleCenterLatitude = -91.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.CircleCenterLatitude = 91.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // localBoxModelResult.CircleCenterLongitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CircleCenterLongitude]

            //CSSPError: Type not implemented [CircleCenterLongitude]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.CircleCenterLongitude = -181.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.CircleCenterLongitude = 181.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // localBoxModelResult.FixLength   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // localBoxModelResult.FixWidth   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // localBoxModelResult.RectLength_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [RectLength_m]

            //CSSPError: Type not implemented [RectLength_m]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.RectLength_m = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.RectLength_m = 100001.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // localBoxModelResult.RectWidth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [RectWidth_m]

            //CSSPError: Type not implemented [RectWidth_m]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.RectWidth_m = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.RectWidth_m = 100001.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 360)]
            // localBoxModelResult.LeftSideLineAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineAngle_deg]

            //CSSPError: Type not implemented [LeftSideLineAngle_deg]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineAngle_deg = -1.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineAngle_deg = 361.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // localBoxModelResult.LeftSideLineStartLatitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineStartLatitude]

            //CSSPError: Type not implemented [LeftSideLineStartLatitude]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineStartLatitude = -91.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineStartLatitude = 91.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // localBoxModelResult.LeftSideLineStartLongitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineStartLongitude]

            //CSSPError: Type not implemented [LeftSideLineStartLongitude]

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineStartLongitude = -181.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultService.GetLocalBoxModelResultList().Count());
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LeftSideLineStartLongitude = 181.0D;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            //Assert.AreEqual(count, localBoxModelResultDBService.GetLocalBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localBoxModelResult.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LastUpdateDate_UTC = new DateTime();
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);
            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localBoxModelResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LastUpdateContactTVItemID = 0;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);

            localBoxModelResult = null;
            localBoxModelResult = GetFilledRandomLocalBoxModelResult("");
            localBoxModelResult.LastUpdateContactTVItemID = 1;
            actionLocalBoxModelResult = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionLocalBoxModelResult.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalBoxModelResult
            var actionLocalBoxModelResultAdded = await LocalBoxModelResultDBService.Post(localBoxModelResult);
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultAdded.Result).Value);
            LocalBoxModelResult localBoxModelResultAdded = (LocalBoxModelResult)((OkObjectResult)actionLocalBoxModelResultAdded.Result).Value;
            Assert.NotNull(localBoxModelResultAdded);

            // List<LocalBoxModelResult>
            var actionLocalBoxModelResultList = await LocalBoxModelResultDBService.GetLocalBoxModelResultList();
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultList.Result).Value);
            List<LocalBoxModelResult> localBoxModelResultList = (List<LocalBoxModelResult>)((OkObjectResult)actionLocalBoxModelResultList.Result).Value;

            int count = ((List<LocalBoxModelResult>)((OkObjectResult)actionLocalBoxModelResultList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalBoxModelResult> with skip and take
            var actionLocalBoxModelResultListSkipAndTake = await LocalBoxModelResultDBService.GetLocalBoxModelResultList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultListSkipAndTake.Result).Value);
            List<LocalBoxModelResult> localBoxModelResultListSkipAndTake = (List<LocalBoxModelResult>)((OkObjectResult)actionLocalBoxModelResultListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalBoxModelResult>)((OkObjectResult)actionLocalBoxModelResultListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localBoxModelResultList[0].BoxModelResultID == localBoxModelResultListSkipAndTake[0].BoxModelResultID);

            // Get LocalBoxModelResult With BoxModelResultID
            var actionLocalBoxModelResultGet = await LocalBoxModelResultDBService.GetLocalBoxModelResultWithBoxModelResultID(localBoxModelResultList[0].BoxModelResultID);
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultGet.Result).Value);
            LocalBoxModelResult localBoxModelResultGet = (LocalBoxModelResult)((OkObjectResult)actionLocalBoxModelResultGet.Result).Value;
            Assert.NotNull(localBoxModelResultGet);
            Assert.Equal(localBoxModelResultGet.BoxModelResultID, localBoxModelResultList[0].BoxModelResultID);

            // Put LocalBoxModelResult
            var actionLocalBoxModelResultUpdated = await LocalBoxModelResultDBService.Put(localBoxModelResult);
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultUpdated.Result).Value);
            LocalBoxModelResult localBoxModelResultUpdated = (LocalBoxModelResult)((OkObjectResult)actionLocalBoxModelResultUpdated.Result).Value;
            Assert.NotNull(localBoxModelResultUpdated);

            // Delete LocalBoxModelResult
            var actionLocalBoxModelResultDeleted = await LocalBoxModelResultDBService.Delete(localBoxModelResult.BoxModelResultID);
            Assert.Equal(200, ((ObjectResult)actionLocalBoxModelResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalBoxModelResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalBoxModelResultDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalBoxModelResultDBService, LocalBoxModelResultDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalBoxModelResultDBService = Provider.GetService<ILocalBoxModelResultDBService>();
            Assert.NotNull(LocalBoxModelResultDBService);

            return await Task.FromResult(true);
        }
        private LocalBoxModelResult GetFilledRandomLocalBoxModelResult(string OmitPropName)
        {
            LocalBoxModelResult localBoxModelResult = new LocalBoxModelResult();

            if (OmitPropName != "LocalDBCommand") localBoxModelResult.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "BoxModelID") localBoxModelResult.BoxModelID = 0;
            if (OmitPropName != "BoxModelResultType") localBoxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") localBoxModelResult.Volume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Surface_m2") localBoxModelResult.Surface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Radius_m") localBoxModelResult.Radius_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") localBoxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "CircleCenterLatitude") localBoxModelResult.CircleCenterLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "CircleCenterLongitude") localBoxModelResult.CircleCenterLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FixLength") localBoxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") localBoxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") localBoxModelResult.RectLength_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RectWidth_m") localBoxModelResult.RectWidth_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") localBoxModelResult.LeftSideLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") localBoxModelResult.LeftSideLineStartLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") localBoxModelResult.LeftSideLineStartLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") localBoxModelResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localBoxModelResult.LastUpdateContactTVItemID = 2;



            return localBoxModelResult;
        }
        private void CheckLocalBoxModelResultFields(List<LocalBoxModelResult> localBoxModelResultList)
        {
            if (localBoxModelResultList[0].LeftSideDiameterLineAngle_deg != null)
            {
                Assert.NotNull(localBoxModelResultList[0].LeftSideDiameterLineAngle_deg);
            }
            if (localBoxModelResultList[0].CircleCenterLatitude != null)
            {
                Assert.NotNull(localBoxModelResultList[0].CircleCenterLatitude);
            }
            if (localBoxModelResultList[0].CircleCenterLongitude != null)
            {
                Assert.NotNull(localBoxModelResultList[0].CircleCenterLongitude);
            }
            if (localBoxModelResultList[0].LeftSideLineAngle_deg != null)
            {
                Assert.NotNull(localBoxModelResultList[0].LeftSideLineAngle_deg);
            }
            if (localBoxModelResultList[0].LeftSideLineStartLatitude != null)
            {
                Assert.NotNull(localBoxModelResultList[0].LeftSideLineStartLatitude);
            }
            if (localBoxModelResultList[0].LeftSideLineStartLongitude != null)
            {
                Assert.NotNull(localBoxModelResultList[0].LeftSideLineStartLongitude);
            }
        }

        #endregion Functions private
    }
}