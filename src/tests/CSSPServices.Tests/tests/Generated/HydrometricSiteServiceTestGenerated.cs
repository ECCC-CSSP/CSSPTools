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
    public partial class HydrometricSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHydrometricSiteService HydrometricSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private HydrometricSite hydrometricSite { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task HydrometricSite_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            hydrometricSite = GetFilledRandomHydrometricSite("");

            if (LoggedInService.IsLocal)
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
            // Post HydrometricSite
            var actionHydrometricSiteAdded = await HydrometricSiteService.Post(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
            HydrometricSite hydrometricSiteAdded = (HydrometricSite)((OkObjectResult)actionHydrometricSiteAdded.Result).Value;
            Assert.NotNull(hydrometricSiteAdded);

            // List<HydrometricSite>
            var actionHydrometricSiteList = await HydrometricSiteService.GetHydrometricSiteList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
            List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value;

            int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Put HydrometricSite
            var actionHydrometricSiteUpdated = await HydrometricSiteService.Put(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteUpdated.Result).Value);
            HydrometricSite hydrometricSiteUpdated = (HydrometricSite)((OkObjectResult)actionHydrometricSiteUpdated.Result).Value;
            Assert.NotNull(hydrometricSiteUpdated);

            // Delete HydrometricSite
            var actionHydrometricSiteDeleted = await HydrometricSiteService.Delete(hydrometricSite.HydrometricSiteID);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHydrometricSiteDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IHydrometricSiteService, HydrometricSiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            HydrometricSiteService = Provider.GetService<IHydrometricSiteService>();
            Assert.NotNull(HydrometricSiteService);

            return await Task.FromResult(true);
        }
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
            List<HydrometricSite> hydrometricSiteListToDelete = (from c in dbLocal.HydrometricSites
                                                               select c).ToList(); 
            
            dbLocal.HydrometricSites.RemoveRange(hydrometricSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            HydrometricSite hydrometricSite = new HydrometricSite();

            if (OmitPropName != "HydrometricSiteTVItemID") hydrometricSite.HydrometricSiteTVItemID = 8;
            if (OmitPropName != "FedSiteNumber") hydrometricSite.FedSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "QuebecSiteNumber") hydrometricSite.QuebecSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "HydrometricSiteName") hydrometricSite.HydrometricSiteName = GetRandomString("", 5);
            if (OmitPropName != "Description") hydrometricSite.Description = GetRandomString("", 5);
            if (OmitPropName != "Province") hydrometricSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasDischarge") hydrometricSite.HasDischarge = true;
            if (OmitPropName != "HasLevel") hydrometricSite.HasLevel = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "HydrometricSiteID") hydrometricSite.HydrometricSiteID = 10000000;

                try
                {
                dbIM.TVItems.Add(new TVItem() { TVItemID = 8, TVLevel = 3, TVPath = "p1p5p6p8", TVType = (TVTypeEnum)9, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 3, 20, 45, 2), LastUpdateContactTVItemID = 2});
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

            return hydrometricSite;
        }
        #endregion Functions private
    }
}
