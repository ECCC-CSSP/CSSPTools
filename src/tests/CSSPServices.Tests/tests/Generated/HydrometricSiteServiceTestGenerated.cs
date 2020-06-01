/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
        private IHydrometricSiteService hydrometricSiteService { get; set; }
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

            await Setup(new CultureInfo(culture));

            HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite(""); 

            // List<HydrometricSite>
            var actionHydrometricSiteList = await hydrometricSiteService.GetHydrometricSiteList();
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteList.Result).Value);
            List<HydrometricSite> hydrometricSiteList = (List<HydrometricSite>)(((OkObjectResult)actionHydrometricSiteList.Result).Value);

            int count = ((List<HydrometricSite>)((OkObjectResult)actionHydrometricSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Add HydrometricSite
            var actionHydrometricSiteAdded = await hydrometricSiteService.Add(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
            HydrometricSite hydrometricSiteAdded = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteAdded.Result).Value);
            Assert.NotNull(hydrometricSiteAdded);

            // Update HydrometricSite
            var actionHydrometricSiteUpdated = await hydrometricSiteService.Update(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteUpdated.Result).Value);
            HydrometricSite hydrometricSiteUpdated = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteUpdated.Result).Value);
            Assert.NotNull(hydrometricSiteUpdated);

            // Delete HydrometricSite
            var actionHydrometricSiteDeleted = await hydrometricSiteService.Delete(hydrometricSite);
            Assert.Equal(200, ((ObjectResult)actionHydrometricSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHydrometricSiteDeleted.Result).Value);
            HydrometricSite hydrometricSiteDeleted = (HydrometricSite)(((OkObjectResult)actionHydrometricSiteDeleted.Result).Value);
            Assert.NotNull(hydrometricSiteDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IHydrometricSiteService, HydrometricSiteService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            hydrometricSiteService = Provider.GetService<IHydrometricSiteService>();
            Assert.NotNull(hydrometricSiteService);
        
            await hydrometricSiteService.SetCulture(culture);
        
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