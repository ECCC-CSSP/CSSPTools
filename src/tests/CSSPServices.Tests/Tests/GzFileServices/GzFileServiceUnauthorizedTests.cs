using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class GzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebArea_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebArea = await CreateGzFileService.CreateWebAreaGzFile(629);
            Assert.Equal(401, ((UnauthorizedResult)actionWebArea.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebArea_629.gz"));

            // Read gz
            WebArea webArea = await ReadGzFileService.ReadWebAreaGzFile(629);
            Assert.NotNull(webArea);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebClimateDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebClimateDataValue = await CreateGzFileService.CreateWebClimateDataValueGzFile(229465);
            Assert.Equal(401, ((UnauthorizedResult)actionWebClimateDataValue.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebClimateDateValue_229465.gz"));

            // Read gz
            WebClimateDataValue webClimateDataValue = await ReadGzFileService.ReadWebClimateDataValueGzFile(229465);
            Assert.NotNull(webClimateDataValue);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebClimateSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebClimateSite = await CreateGzFileService.CreateWebClimateSiteGzFile(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebClimateSite.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebClimateSite.gz"));

            // Read gz
            WebClimateSite webClimateSite = await ReadGzFileService.ReadWebClimateSiteGzFile(7);
            Assert.NotNull(webClimateSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebContact_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebContact = await CreateGzFileService.CreateWebContactGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebContact.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebContact.gz"));

            // Read gz
            WebContact webContact = await ReadGzFileService.ReadWebContactGzFile();
            Assert.NotNull(webContact);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebCountry_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebCountry = await CreateGzFileService.CreateWebCountryGzFile(5);
            Assert.Equal(401, ((UnauthorizedResult)actionWebCountry.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebCountry_5.gz"));

            // Read gz
            WebCountry webCountry = await ReadGzFileService.ReadWebCountryGzFile(5);
            Assert.NotNull(webCountry);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebDrogueRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebDrogueRun = await CreateGzFileService.CreateWebDrogueRunGzFile(556);
            Assert.Equal(401, ((UnauthorizedResult)actionWebDrogueRun.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebDrogueRun_556.gz"));

            // Read gz
            WebDrogueRun webDrogueRun = await ReadGzFileService.ReadWebDrogueRunGzFile(556);
            Assert.NotNull(webDrogueRun);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHelpDoc_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebHelpDoc = await CreateGzFileService.CreateWebHelpDocGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebHelpDoc.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebHelpDoc.gz"));

            // Read gz
            WebHelpDoc webHelpDoc = await ReadGzFileService.ReadWebHelpDocGzFile();
            Assert.NotNull(webHelpDoc);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHydrometricDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebHydrometricDataValue = await CreateGzFileService.CreateWebHydrometricDataValueGzFile(51705);
            Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricDataValue.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebClimateSite_51705.gz"));

            // Read gz
            WebClimateSite webClimateSite = await ReadGzFileService.ReadWebClimateSiteGzFile(51705);
            Assert.NotNull(webClimateSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHydrometricSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebHydrometricSite = await CreateGzFileService.CreateWebHydrometricSiteGzFile(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricSite.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebHydrometricSite_7.gz"));

            // Read gz
            WebHydrometricSite webHydrometricSite = await ReadGzFileService.ReadWebHydrometricSiteGzFile(7);
            Assert.NotNull(webHydrometricSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMikeScenario_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMikeScenario = await CreateGzFileService.CreateWebMikeScenarioGzFile(12281);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMikeScenario.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMikeScenario_12281.gz"));

            // Read gz
            WebMikeScenario webMikeScenario = await ReadGzFileService.ReadWebMikeScenarioGzFile(12281);
            Assert.NotNull(webMikeScenario);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMunicipalities_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMunicipalities = await CreateGzFileService.CreateWebMunicipalitiesGzFile(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipalities.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMunicipalities_7.gz"));

            // Read gz
            WebMunicipalities webMunicipalities = await ReadGzFileService.ReadWebMunicipalitiesGzFile(7);
            Assert.NotNull(webMunicipalities);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMunicipality_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMunicipality = await CreateGzFileService.CreateWebMunicipalityGzFile(12110);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipality.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMunicipality_12110.gz"));

            // Read gz
            WebMunicipality webMunicipality = await ReadGzFileService.ReadWebMunicipalityGzFile(12110);
            Assert.NotNull(webMunicipality);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMLookupMPN_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMLookupMPN = await CreateGzFileService.CreateWebMWQMLookupMPNGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMLookupMPN.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMLookupMPN.gz"));

            // Read gz
            WebMWQMLookupMPN webMWQMLookupMPN = await ReadGzFileService.ReadWebMWQMLookupMPNGzFile();
            Assert.NotNull(webMWQMLookupMPN);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMRun = await CreateGzFileService.CreateWebMWQMRunGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMRun.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMRun_635.gz"));

            // Read gz
            WebMWQMRun webMWQMRun = await ReadGzFileService.ReadWebMWQMRunGzFile(635);
            Assert.NotNull(webMWQMRun);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1980_1989FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_1980_1989.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1990_1999FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_1990_1999.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2000_2009FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2000_2009.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2010_2019FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2010_2019.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2020_2029FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2020_2029.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2030_2039FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2030_2039.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2040_2049FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2040_2049.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2050_2059FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2050_2059.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebMWQMSite = await CreateGzFileService.CreateWebMWQMSiteGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSite.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebMWQMSite_635.gz"));

            // Read gz
            WebMWQMSite webMWQMSite = await ReadGzFileService.ReadWebMWQMSiteGzFile(635);
            Assert.NotNull(webMWQMSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebPolSourceGrouping_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebPolSourceGrouping = await CreateGzFileService.CreateWebPolSourceGroupingGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceGrouping.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebPolSourceGrouping.gz"));

            // Read gz
            WebPolSourceGrouping webPolSourceGrouping = await ReadGzFileService.ReadWebPolSourceGroupingGzFile();
            Assert.NotNull(webPolSourceGrouping);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebPolSourceSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebPolSourceSite = await CreateGzFileService.CreateWebPolSourceSiteGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceSite.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebPolSourceSite_635.gz"));

            // Read gz
            WebPolSourceSite webPolSourceSite = await ReadGzFileService.ReadWebPolSourceSiteGzFile(635);
            Assert.NotNull(webPolSourceSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebProvince_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebProvince = await CreateGzFileService.CreateWebProvinceGzFile(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebProvince.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebProvince_7.gz"));

            // Read gz
            WebProvince webProvince = await ReadGzFileService.ReadWebProvinceGzFile(7);
            Assert.NotNull(webProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebReportType_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebReportType = await CreateGzFileService.CreateWebReportTypeGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebReportType.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebReportType.gz"));

            // Read gz
            WebReportType webReportType = await ReadGzFileService.ReadWebReportTypeGzFile();
            Assert.NotNull(webReportType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebRoot_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebRoot = await CreateGzFileService.CreateWebRootGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebRoot.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebRoot.gz"));

            // Read gz
            WebRoot webRoot = await ReadGzFileService.ReadWebRootGzFile();
            Assert.NotNull(webRoot);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSamplingPlan_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebSamplingPlan = await CreateGzFileService.CreateWebSamplingPlanGzFile(8);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSamplingPlan.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebSamplingPlan_8.gz"));

            // Read gz
            WebSamplingPlan webSamplingPlan = await ReadGzFileService.ReadWebSamplingPlanGzFile(8);
            Assert.NotNull(webSamplingPlan);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebSector = await CreateGzFileService.CreateWebSectorGzFile(633);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSector.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebSector_633.gz"));

            // Read gz
            WebSector webSector = await ReadGzFileService.ReadWebSectorGzFile(633);
            Assert.NotNull(webSector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebSubsector = await CreateGzFileService.CreateWebSubsectorGzFile(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSubsector.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebSubsector_635.gz"));

            // Read gz
            WebSubsector webSubsector = await ReadGzFileService.ReadWebSubsectorGzFile(635);
            Assert.NotNull(webSubsector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebTideLocation_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            // Create gz
            var actionWebTideLocation = await CreateGzFileService.CreateWebTideLocationGzFile();
            Assert.Equal(401, ((UnauthorizedResult)actionWebTideLocation.Result).StatusCode);

            // Download gz
            Assert.False(await DownloadGzFileService.DownloadGzFile("WebTideLocation.gz"));

            // Read gz
            WebTideLocation webTideLocation = await ReadGzFileService.ReadWebTideLocationGzFile();
            Assert.NotNull(webTideLocation);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
