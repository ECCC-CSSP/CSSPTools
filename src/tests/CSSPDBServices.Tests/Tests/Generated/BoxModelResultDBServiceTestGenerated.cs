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
    public partial class BoxModelResultDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IBoxModelResultDBService BoxModelResultDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private BoxModelResult boxModelResult { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task BoxModelResultDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            boxModelResult = GetFilledRandomBoxModelResult("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task BoxModelResult_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionBoxModelResultList = await BoxModelResultDBService.GetBoxModelResultList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultList.Result).Value);
            List<BoxModelResult> boxModelResultList = (List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value;

            count = boxModelResultList.Count();

            BoxModelResult boxModelResult = GetFilledRandomBoxModelResult("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModelResult.BoxModelResultID   (Int32)
            // -----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.BoxModelResultID = 0;

            var actionBoxModelResult = await BoxModelResultDBService.Put(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.BoxModelResultID = 10000000;
            actionBoxModelResult = await BoxModelResultDBService.Put(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = )]
            // boxModelResult.BoxModelID   (Int32)
            // -----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.BoxModelID = 0;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
            // -----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)1000000;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // boxModelResult.Volume_m3   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Volume_m3]

            //CSSPError: Type not implemented [Volume_m3]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.Volume_m3 = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, -1)]
            // boxModelResult.Surface_m2   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Surface_m2]

            //CSSPError: Type not implemented [Surface_m2]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.Surface_m2 = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // boxModelResult.Radius_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Radius_m]

            //CSSPError: Type not implemented [Radius_m]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.Radius_m = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.Radius_m = 100001.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 360)]
            // boxModelResult.LeftSideDiameterLineAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideDiameterLineAngle_deg]

            //CSSPError: Type not implemented [LeftSideDiameterLineAngle_deg]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // boxModelResult.CircleCenterLatitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CircleCenterLatitude]

            //CSSPError: Type not implemented [CircleCenterLatitude]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.CircleCenterLatitude = -91.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.CircleCenterLatitude = 91.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // boxModelResult.CircleCenterLongitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CircleCenterLongitude]

            //CSSPError: Type not implemented [CircleCenterLongitude]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.CircleCenterLongitude = -181.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.CircleCenterLongitude = 181.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // boxModelResult.FixLength   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // boxModelResult.FixWidth   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // boxModelResult.RectLength_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [RectLength_m]

            //CSSPError: Type not implemented [RectLength_m]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.RectLength_m = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.RectLength_m = 100001.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // boxModelResult.RectWidth_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [RectWidth_m]

            //CSSPError: Type not implemented [RectWidth_m]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.RectWidth_m = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.RectWidth_m = 100001.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 360)]
            // boxModelResult.LeftSideLineAngle_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineAngle_deg]

            //CSSPError: Type not implemented [LeftSideLineAngle_deg]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineAngle_deg = -1.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineAngle_deg = 361.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-90, 90)]
            // boxModelResult.LeftSideLineStartLatitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineStartLatitude]

            //CSSPError: Type not implemented [LeftSideLineStartLatitude]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineStartLatitude = -91.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineStartLatitude = 91.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(-180, 180)]
            // boxModelResult.LeftSideLineStartLongitude   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [LeftSideLineStartLongitude]

            //CSSPError: Type not implemented [LeftSideLineStartLongitude]

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineStartLongitude = -181.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LeftSideLineStartLongitude = 181.0D;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            //Assert.AreEqual(count, boxModelResultDBService.GetBoxModelResultList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModelResult.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LastUpdateDate_UTC = new DateTime();
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);
            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // boxModelResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LastUpdateContactTVItemID = 0;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.LastUpdateContactTVItemID = 1;
            actionBoxModelResult = await BoxModelResultDBService.Post(boxModelResult);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelResult.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post BoxModelResult
            var actionBoxModelResultAdded = await BoxModelResultDBService.Post(boxModelResult);
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultAdded.Result).Value);
            BoxModelResult boxModelResultAdded = (BoxModelResult)((OkObjectResult)actionBoxModelResultAdded.Result).Value;
            Assert.NotNull(boxModelResultAdded);

            // List<BoxModelResult>
            var actionBoxModelResultList = await BoxModelResultDBService.GetBoxModelResultList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultList.Result).Value);
            List<BoxModelResult> boxModelResultList = (List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value;

            int count = ((List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value).Count();
            Assert.True(count > 0);

            // List<BoxModelResult> with skip and take
            var actionBoxModelResultListSkipAndTake = await BoxModelResultDBService.GetBoxModelResultList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultListSkipAndTake.Result).Value);
            List<BoxModelResult> boxModelResultListSkipAndTake = (List<BoxModelResult>)((OkObjectResult)actionBoxModelResultListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<BoxModelResult>)((OkObjectResult)actionBoxModelResultListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(boxModelResultList[0].BoxModelResultID == boxModelResultListSkipAndTake[0].BoxModelResultID);

            // Get BoxModelResult With BoxModelResultID
            var actionBoxModelResultGet = await BoxModelResultDBService.GetBoxModelResultWithBoxModelResultID(boxModelResultList[0].BoxModelResultID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultGet.Result).Value);
            BoxModelResult boxModelResultGet = (BoxModelResult)((OkObjectResult)actionBoxModelResultGet.Result).Value;
            Assert.NotNull(boxModelResultGet);
            Assert.Equal(boxModelResultGet.BoxModelResultID, boxModelResultList[0].BoxModelResultID);

            // Put BoxModelResult
            var actionBoxModelResultUpdated = await BoxModelResultDBService.Put(boxModelResult);
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultUpdated.Result).Value);
            BoxModelResult boxModelResultUpdated = (BoxModelResult)((OkObjectResult)actionBoxModelResultUpdated.Result).Value;
            Assert.NotNull(boxModelResultUpdated);

            // Delete BoxModelResult
            var actionBoxModelResultDeleted = await BoxModelResultDBService.Delete(boxModelResult.BoxModelResultID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionBoxModelResultDeleted.Result).Value;
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IBoxModelResultDBService, BoxModelResultDBService>();

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

            BoxModelResultDBService = Provider.GetService<IBoxModelResultDBService>();
            Assert.NotNull(BoxModelResultDBService);

            return await Task.FromResult(true);
        }
        private BoxModelResult GetFilledRandomBoxModelResult(string OmitPropName)
        {
            BoxModelResult boxModelResult = new BoxModelResult();

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = 1;
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModelResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelResult.LastUpdateContactTVItemID = 2;



            return boxModelResult;
        }
        private void CheckBoxModelResultFields(List<BoxModelResult> boxModelResultList)
        {
            if (boxModelResultList[0].LeftSideDiameterLineAngle_deg != null)
            {
                Assert.NotNull(boxModelResultList[0].LeftSideDiameterLineAngle_deg);
            }
            if (boxModelResultList[0].CircleCenterLatitude != null)
            {
                Assert.NotNull(boxModelResultList[0].CircleCenterLatitude);
            }
            if (boxModelResultList[0].CircleCenterLongitude != null)
            {
                Assert.NotNull(boxModelResultList[0].CircleCenterLongitude);
            }
            if (boxModelResultList[0].LeftSideLineAngle_deg != null)
            {
                Assert.NotNull(boxModelResultList[0].LeftSideLineAngle_deg);
            }
            if (boxModelResultList[0].LeftSideLineStartLatitude != null)
            {
                Assert.NotNull(boxModelResultList[0].LeftSideLineStartLatitude);
            }
            if (boxModelResultList[0].LeftSideLineStartLongitude != null)
            {
                Assert.NotNull(boxModelResultList[0].LeftSideLineStartLongitude);
            }
        }

        #endregion Functions private
    }
}
