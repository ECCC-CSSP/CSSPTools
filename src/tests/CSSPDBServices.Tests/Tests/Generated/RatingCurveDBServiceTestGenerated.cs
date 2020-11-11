/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
    public partial class RatingCurveDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRatingCurveDBService RatingCurveDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private RatingCurve ratingCurve { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ratingCurve = GetFilledRandomRatingCurve("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurve_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionRatingCurveList = await RatingCurveDBService.GetRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveList.Result).Value);
            List<RatingCurve> ratingCurveList = (List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value;

            count = ratingCurveList.Count();

            RatingCurve ratingCurve = GetFilledRandomRatingCurve("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // ratingCurve.RatingCurveID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.RatingCurveID = 0;

            var actionRatingCurve = await RatingCurveDBService.Put(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.RatingCurveID = 10000000;
            actionRatingCurve = await RatingCurveDBService.Put(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
            // ratingCurve.HydrometricSiteID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.HydrometricSiteID = 0;
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // ratingCurve.RatingCurveNumber   (String)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.RatingCurveNumber = GetRandomString("", 51);
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);
            //Assert.AreEqual(count, ratingCurveDBService.GetRatingCurveList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // ratingCurve.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateDate_UTC = new DateTime();
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);
            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // ratingCurve.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateContactTVItemID = 0;
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateContactTVItemID = 1;
            actionRatingCurve = await RatingCurveDBService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post RatingCurve
            var actionRatingCurveAdded = await RatingCurveDBService.Post(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveAdded.Result).Value);
            RatingCurve ratingCurveAdded = (RatingCurve)((OkObjectResult)actionRatingCurveAdded.Result).Value;
            Assert.NotNull(ratingCurveAdded);

            // List<RatingCurve>
            var actionRatingCurveList = await RatingCurveDBService.GetRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveList.Result).Value);
            List<RatingCurve> ratingCurveList = (List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value;

            int count = ((List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value).Count();
            Assert.True(count > 0);

            // List<RatingCurve> with skip and take
            var actionRatingCurveListSkipAndTake = await RatingCurveDBService.GetRatingCurveList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveListSkipAndTake.Result).Value);
            List<RatingCurve> ratingCurveListSkipAndTake = (List<RatingCurve>)((OkObjectResult)actionRatingCurveListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<RatingCurve>)((OkObjectResult)actionRatingCurveListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(ratingCurveList[0].RatingCurveID == ratingCurveListSkipAndTake[0].RatingCurveID);

            // Get RatingCurve With RatingCurveID
            var actionRatingCurveGet = await RatingCurveDBService.GetRatingCurveWithRatingCurveID(ratingCurveList[0].RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveGet.Result).Value);
            RatingCurve ratingCurveGet = (RatingCurve)((OkObjectResult)actionRatingCurveGet.Result).Value;
            Assert.NotNull(ratingCurveGet);
            Assert.Equal(ratingCurveGet.RatingCurveID, ratingCurveList[0].RatingCurveID);

            // Put RatingCurve
            var actionRatingCurveUpdated = await RatingCurveDBService.Put(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveUpdated.Result).Value);
            RatingCurve ratingCurveUpdated = (RatingCurve)((OkObjectResult)actionRatingCurveUpdated.Result).Value;
            Assert.NotNull(ratingCurveUpdated);

            // Delete RatingCurve
            var actionRatingCurveDeleted = await RatingCurveDBService.Delete(ratingCurve.RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRatingCurveDeleted.Result).Value;
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
            Services.AddSingleton<IRatingCurveDBService, RatingCurveDBService>();

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

            RatingCurveDBService = Provider.GetService<IRatingCurveDBService>();
            Assert.NotNull(RatingCurveDBService);

            return await Task.FromResult(true);
        }
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 0;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;



            return ratingCurve;
        }
        private void CheckRatingCurveFields(List<RatingCurve> ratingCurveList)
        {
            Assert.False(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveNumber));
        }

        #endregion Functions private
    }
}
