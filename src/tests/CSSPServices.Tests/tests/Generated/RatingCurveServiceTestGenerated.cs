/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class RatingCurveServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRatingCurveService RatingCurveService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private RatingCurve ratingCurve { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task RatingCurve_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            ratingCurve = GetFilledRandomRatingCurve("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post RatingCurve
            var actionRatingCurveAdded = await RatingCurveService.Post(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveAdded.Result).Value);
            RatingCurve ratingCurveAdded = (RatingCurve)((OkObjectResult)actionRatingCurveAdded.Result).Value;
            Assert.NotNull(ratingCurveAdded);

            // List<RatingCurve>
            var actionRatingCurveList = await RatingCurveService.GetRatingCurveList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveList.Result).Value);
            List<RatingCurve> ratingCurveList = (List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value;

            int count = ((List<RatingCurve>)((OkObjectResult)actionRatingCurveList.Result).Value).Count();
            Assert.True(count > 0);

            // Put RatingCurve
            var actionRatingCurveUpdated = await RatingCurveService.Put(ratingCurve);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveUpdated.Result).Value);
            RatingCurve ratingCurveUpdated = (RatingCurve)((OkObjectResult)actionRatingCurveUpdated.Result).Value;
            Assert.NotNull(ratingCurveUpdated);

            // Delete RatingCurve
            var actionRatingCurveDeleted = await RatingCurveService.Delete(ratingCurve.RatingCurveID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRatingCurveDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IRatingCurveService, RatingCurveService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            RatingCurveService = Provider.GetService<IRatingCurveService>();
            Assert.NotNull(RatingCurveService);

            return await Task.FromResult(true);
        }
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            List<RatingCurve> ratingCurveListToDelete = (from c in dbLocal.RatingCurves
                                                               select c).ToList(); 
            
            dbLocal.RatingCurves.RemoveRange(ratingCurveListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 1;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "RatingCurveID") ratingCurve.RatingCurveID = 10000000;

                try
                {
                    dbIM.HydrometricSites.Add(new HydrometricSite() { HydrometricSiteID = 1, HydrometricSiteTVItemID = 8, FedSiteNumber = "01BL003", QuebecSiteNumber = "null", HydrometricSiteName = "BIG TRACADIE RIVER AT MURCHY BRIDGE CROSSING", Description = "null", Province = "NB", Elevation_m = null, StartDate_Local = new DateTime(1970, 1, 1, 0, 0, 0), EndDate_Local = new DateTime(2028, 12, 31, 0, 0, 0), TimeOffset_hour = -4D, DrainageArea_km2 = 383, IsNatural = true, IsActive = true, Sediment = false, RHBN = false, RealTime = true, HasDischarge = true, HasLevel = true, HasRatingCurve = true, LastUpdateDate_UTC = new DateTime(2018, 9, 13, 16, 56, 10), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return ratingCurve;
        }
        #endregion Functions private
    }
}
