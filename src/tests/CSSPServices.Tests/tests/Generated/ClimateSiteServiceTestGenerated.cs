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
    public partial class ClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IClimateSiteService climateSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ClimateSite_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            ClimateSite climateSite = GetFilledRandomClimateSite(""); 

            // List<ClimateSite>
            var actionClimateSiteList = await climateSiteService.GetClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClimateSiteList.Result).Value);
            List<ClimateSite> climateSiteList = (List<ClimateSite>)(((OkObjectResult)actionClimateSiteList.Result).Value);

            int count = ((List<ClimateSite>)((OkObjectResult)actionClimateSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Add ClimateSite
            var actionClimateSiteAdded = await climateSiteService.Add(climateSite);
            Assert.Equal(200, ((ObjectResult)actionClimateSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClimateSiteAdded.Result).Value);
            ClimateSite climateSiteAdded = (ClimateSite)(((OkObjectResult)actionClimateSiteAdded.Result).Value);
            Assert.NotNull(climateSiteAdded);

            // Update ClimateSite
            var actionClimateSiteUpdated = await climateSiteService.Update(climateSite);
            Assert.Equal(200, ((ObjectResult)actionClimateSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClimateSiteUpdated.Result).Value);
            ClimateSite climateSiteUpdated = (ClimateSite)(((OkObjectResult)actionClimateSiteUpdated.Result).Value);
            Assert.NotNull(climateSiteUpdated);

            // Delete ClimateSite
            var actionClimateSiteDeleted = await climateSiteService.Delete(climateSite);
            Assert.Equal(200, ((ObjectResult)actionClimateSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClimateSiteDeleted.Result).Value);
            ClimateSite climateSiteDeleted = (ClimateSite)(((OkObjectResult)actionClimateSiteDeleted.Result).Value);
            Assert.NotNull(climateSiteDeleted);
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
            Services.AddSingleton<IClimateSiteService, ClimateSiteService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            climateSiteService = Provider.GetService<IClimateSiteService>();
            Assert.NotNull(climateSiteService);
        
            await climateSiteService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private ClimateSite GetFilledRandomClimateSite(string OmitPropName)
        {
            ClimateSite climateSite = new ClimateSite();

            if (OmitPropName != "ClimateSiteTVItemID") climateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 100000);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 100000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsQuebecSite") climateSite.IsQuebecSite = true;
            if (OmitPropName != "IsCoCoRaHS") climateSite.IsCoCoRaHS = true;
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "File_desc") climateSite.File_desc = GetRandomString("", 5);
            if (OmitPropName != "HourlyStartDate_Local") climateSite.HourlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "HourlyEndDate_Local") climateSite.HourlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "HourlyNow") climateSite.HourlyNow = true;
            if (OmitPropName != "DailyStartDate_Local") climateSite.DailyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyEndDate_Local") climateSite.DailyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "DailyNow") climateSite.DailyNow = true;
            if (OmitPropName != "MonthlyStartDate_Local") climateSite.MonthlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MonthlyEndDate_Local") climateSite.MonthlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "MonthlyNow") climateSite.MonthlyNow = true;
            if (OmitPropName != "LastUpdateDate_UTC") climateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateSite.LastUpdateContactTVItemID = 2;

            return climateSite;
        }
        #endregion Functions private
    }
}