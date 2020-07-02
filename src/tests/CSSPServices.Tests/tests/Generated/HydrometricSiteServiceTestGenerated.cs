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
        #endregion Properties

        #region Constructors
        public HydrometricSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task HydrometricSite_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite(""); 

               // List<HydrometricSite>
               var actionHydrometricSiteList = await HydrometricSiteService.GetHydrometricSiteList();
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
               List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value;

               int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
                Assert.True(count > 0);

               // Post HydrometricSite
               var actionHydrometricSiteAdded = await HydrometricSiteService.Post(hydrometricSite);
               Assert.Equal(200, ((ObjectResult)actionHydrometricSiteAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
               HydrometricSite hydrometricSiteAdded = (HydrometricSite)((OkObjectResult)actionHydrometricSiteAdded.Result).Value;
               Assert.NotNull(hydrometricSiteAdded);

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
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

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

            HydrometricSiteService = Provider.GetService<IHydrometricSiteService>();
            Assert.NotNull(HydrometricSiteService);

            return await Task.FromResult(true);
        }
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
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

            return hydrometricSite;
        }
        #endregion Functions private
    }
}
