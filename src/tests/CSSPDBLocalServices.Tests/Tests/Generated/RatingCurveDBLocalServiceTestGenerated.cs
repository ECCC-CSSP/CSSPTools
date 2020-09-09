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
    public partial class RatingCurveDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IRatingCurveDBLocalService RatingCurveDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private RatingCurve ratingCurve { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ratingCurve = GetFilledRandomRatingCurve("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

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

            var actionRatingCurveList = await RatingCurveDBLocalService.GetRatingCurveList();
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

            var actionRatingCurve = await RatingCurveDBLocalService.Put(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.RatingCurveID = 10000000;
            actionRatingCurve = await RatingCurveDBLocalService.Put(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
            // ratingCurve.HydrometricSiteID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.HydrometricSiteID = 0;
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // ratingCurve.RatingCurveNumber   (String)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.RatingCurveNumber = GetRandomString("", 51);
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);
            //Assert.AreEqual(count, ratingCurveDBLocalService.GetRatingCurveList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // ratingCurve.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateDate_UTC = new DateTime();
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);
            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // ratingCurve.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateContactTVItemID = 0;
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateContactTVItemID = 1;
            actionRatingCurve = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurve.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post RatingCurve
            var actionRatingCurveAdded = await RatingCurveDBLocalService.Post(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveAdded.Result).Value);
            RatingCurve ratingCurveAdded = (RatingCurve)((OkObjectResult)actionRatingCurveAdded.Result).Value;
            Assert.NotNull(ratingCurveAdded);

            // List<RatingCurve>
            var actionRatingCurveList = await RatingCurveDBLocalService.GetRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveList.Result).Value);
            List<RatingCurve> ratingCurveList = (List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value;

            int count = ((List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value).Count();
            Assert.True(count > 0);

            // Get RatingCurve With RatingCurveID
            var actionRatingCurveGet = await RatingCurveDBLocalService.GetRatingCurveWithRatingCurveID(ratingCurveList[0].RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveGet.Result).Value);
            RatingCurve ratingCurveGet = (RatingCurve)((OkObjectResult)actionRatingCurveGet.Result).Value;
            Assert.NotNull(ratingCurveGet);
            Assert.Equal(ratingCurveGet.RatingCurveID, ratingCurveList[0].RatingCurveID);

            // Put RatingCurve
            var actionRatingCurveUpdated = await RatingCurveDBLocalService.Put(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveUpdated.Result).Value);
            RatingCurve ratingCurveUpdated = (RatingCurve)((OkObjectResult)actionRatingCurveUpdated.Result).Value;
            Assert.NotNull(ratingCurveUpdated);

            // Delete RatingCurve
            var actionRatingCurveDeleted = await RatingCurveDBLocalService.Delete(ratingCurve.RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRatingCurveDeleted.Result).Value;
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
            Services.AddSingleton<IRatingCurveDBLocalService, RatingCurveDBLocalService>();

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

            RatingCurveDBLocalService = Provider.GetService<IRatingCurveDBLocalService>();
            Assert.NotNull(RatingCurveDBLocalService);

            return await Task.FromResult(true);
        }
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 1;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.HydrometricSites.Add(new HydrometricSite() { HydrometricSiteID = 1, HydrometricSiteTVItemID = 8, FedSiteNumber = "01BL003", QuebecSiteNumber = "null", HydrometricSiteName = "BIG TRACADIE RIVER AT MURCHY BRIDGE CROSSING", Description = "null", Province = "NB", Elevation_m = null, StartDate_Local = new DateTime(1970, 1, 1, 0, 0, 0), EndDate_Local = new DateTime(2028, 12, 31, 0, 0, 0), TimeOffset_hour = -4D, DrainageArea_km2 = 383, IsNatural = true, IsActive = true, Sediment = false, RHBN = false, RealTime = true, HasDischarge = true, HasLevel = true, HasRatingCurve = true, LastUpdateDate_UTC = new DateTime(2018, 9, 13, 16, 56, 10), LastUpdateContactTVItemID = 2 });
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


            return ratingCurve;
        }
        private void CheckRatingCurveFields(List<RatingCurve> ratingCurveList)
        {
            Assert.False(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveNumber));
        }

        #endregion Functions private
    }
}
