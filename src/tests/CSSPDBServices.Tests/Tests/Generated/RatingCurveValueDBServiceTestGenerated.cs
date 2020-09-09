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
    public partial class RatingCurveValueDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRatingCurveValueDBService RatingCurveValueDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private RatingCurveValue ratingCurveValue { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValueDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValueDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ratingCurveValue = GetFilledRandomRatingCurveValue("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValue_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionRatingCurveValueList = await RatingCurveValueDBService.GetRatingCurveValueList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueList.Result).Value);
            List<RatingCurveValue> ratingCurveValueList = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value;

            count = ratingCurveValueList.Count();

            RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // ratingCurveValue.RatingCurveValueID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveValueID = 0;

            var actionRatingCurveValue = await RatingCurveValueDBService.Put(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveValueID = 10000000;
            actionRatingCurveValue = await RatingCurveValueDBService.Put(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = )]
            // ratingCurveValue.RatingCurveID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveID = 0;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // ratingCurveValue.StageValue_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [StageValue_m]

            //CSSPError: Type not implemented [StageValue_m]

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.StageValue_m = -1.0D;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.StageValue_m = 1001.0D;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueDBService.GetRatingCurveValueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // ratingCurveValue.DischargeValue_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DischargeValue_m3_s]

            //CSSPError: Type not implemented [DischargeValue_m3_s]

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.DischargeValue_m3_s = -1.0D;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueDBService.GetRatingCurveValueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateDate_UTC = new DateTime();
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateContactTVItemID = 0;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateContactTVItemID = 1;
            actionRatingCurveValue = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post RatingCurveValue
            var actionRatingCurveValueAdded = await RatingCurveValueDBService.Post(ratingCurveValue);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueAdded.Result).Value);
            RatingCurveValue ratingCurveValueAdded = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueAdded.Result).Value;
            Assert.NotNull(ratingCurveValueAdded);

            // List<RatingCurveValue>
            var actionRatingCurveValueList = await RatingCurveValueDBService.GetRatingCurveValueList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueList.Result).Value);
            List<RatingCurveValue> ratingCurveValueList = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value;

            int count = ((List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value).Count();
            Assert.True(count > 0);

            // List<RatingCurveValue> with skip and take
            var actionRatingCurveValueListSkipAndTake = await RatingCurveValueDBService.GetRatingCurveValueList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueListSkipAndTake.Result).Value);
            List<RatingCurveValue> ratingCurveValueListSkipAndTake = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(ratingCurveValueList[0].RatingCurveValueID == ratingCurveValueListSkipAndTake[0].RatingCurveValueID);

            // Get RatingCurveValue With RatingCurveValueID
            var actionRatingCurveValueGet = await RatingCurveValueDBService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValueList[0].RatingCurveValueID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueGet.Result).Value);
            RatingCurveValue ratingCurveValueGet = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueGet.Result).Value;
            Assert.NotNull(ratingCurveValueGet);
            Assert.Equal(ratingCurveValueGet.RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);

            // Put RatingCurveValue
            var actionRatingCurveValueUpdated = await RatingCurveValueDBService.Put(ratingCurveValue);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueUpdated.Result).Value);
            RatingCurveValue ratingCurveValueUpdated = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueUpdated.Result).Value;
            Assert.NotNull(ratingCurveValueUpdated);

            // Delete RatingCurveValue
            var actionRatingCurveValueDeleted = await RatingCurveValueDBService.Delete(ratingCurveValue.RatingCurveValueID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRatingCurveValueDeleted.Result).Value;
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
            Services.AddSingleton<IRatingCurveValueDBService, RatingCurveValueDBService>();

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

            RatingCurveValueDBService = Provider.GetService<IRatingCurveValueDBService>();
            Assert.NotNull(RatingCurveValueDBService);

            return await Task.FromResult(true);
        }
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = 1;
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;



            return ratingCurveValue;
        }
        private void CheckRatingCurveValueFields(List<RatingCurveValue> ratingCurveValueList)
        {
        }

        #endregion Functions private
    }
}
