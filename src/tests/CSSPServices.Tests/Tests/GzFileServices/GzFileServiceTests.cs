using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class GzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebAreaGzFile(629);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebArea_629.gz"));

            // Read gz
            WebArea webArea = await ReadGzFileService.ReadWebAreaGzFile(629);
            Assert.NotNull(webArea);
            Assert.NotNull(webArea.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebClimateDataValueGzFile(229465);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebClimateDataValue_229465.gz"));

            // Read gz
            WebClimateDataValue webClimateDataValue = await ReadGzFileService.ReadWebClimateDataValueGzFile(229465);
            Assert.NotNull(webClimateDataValue);
            Assert.NotNull(webClimateDataValue.ClimateDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebClimateSiteGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebClimateSite_7.gz"));

            // Read gz
            WebClimateSite webClimateSite = await ReadGzFileService.ReadWebClimateSiteGzFile(7);
            Assert.NotNull(webClimateSite);
            Assert.NotNull(webClimateSite.ClimateSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebContactGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebContact.gz"));

            // Read gz
            WebContact webContact = await ReadGzFileService.ReadWebContactGzFile();
            Assert.NotNull(webContact);
            Assert.NotNull(webContact.ContactList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebCountryGzFile(5);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebCountry_5.gz"));

            // Read gz
            WebCountry webCountry = await ReadGzFileService.ReadWebCountryGzFile(5);
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebDrogueRunGzFile(556);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebDrogueRun_556.gz"));

            // Read gz
            WebDrogueRun webDrogueRun = await ReadGzFileService.ReadWebDrogueRunGzFile(556);
            Assert.NotNull(webDrogueRun);
            Assert.NotNull(webDrogueRun.DrogueRunList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebHelpDocGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebHelpDoc.gz"));

            // Read gz
            WebHelpDoc webHelpDoc = await ReadGzFileService.ReadWebHelpDocGzFile();
            Assert.NotNull(webHelpDoc);
            Assert.NotNull(webHelpDoc.HelpDocList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebHydrometricDataValueGzFile(51705);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebHydrometricDataValue_51705.gz"));

            // Read gz
            WebHydrometricDataValue webHydrometricDataValue = await ReadGzFileService.ReadWebHydrometricDataValueGzFile(51705);
            Assert.NotNull(webHydrometricDataValue);
            Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebHydrometricSiteGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebHydrometricSite_7.gz"));

            // Read gz
            WebHydrometricSite webHydrometricSite = await ReadGzFileService.ReadWebHydrometricSiteGzFile(7);
            Assert.NotNull(webHydrometricSite);
            Assert.NotNull(webHydrometricSite.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMikeScenarioGzFile(12281);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMikeScenario_12281.gz"));

            // Read gz
            WebMikeScenario webMikeScenario = await ReadGzFileService.ReadWebMikeScenarioGzFile(12281);
            Assert.NotNull(webMikeScenario);
            Assert.NotNull(webMikeScenario.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMunicipalitiesGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMunicipalities_7.gz"));

            // Read gz
            WebMunicipalities webMunicipalities = await ReadGzFileService.ReadWebMunicipalitiesGzFile(7);
            Assert.NotNull(webMunicipalities);
            Assert.NotNull(webMunicipalities.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMunicipalityGzFile(12110);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMunicipality_12110.gz"));

            // Read gz
            WebMunicipality webMunicipality = await ReadGzFileService.ReadWebMunicipalityGzFile(12110);
            Assert.NotNull(webMunicipality);
            Assert.NotNull(webMunicipality.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMWQMLookupMPNGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMLookupMPN.gz"));

            // Read gz
            WebMWQMLookupMPN webMWQMLookupMPN = await ReadGzFileService.ReadWebMWQMLookupMPNGzFile();
            Assert.NotNull(webMWQMLookupMPN);
            Assert.NotNull(webMWQMLookupMPN.MWQMLookupMPNList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMWQMRunGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMRun_635.gz"));

            // Read gz
            WebMWQMRun webMWQMRun = await ReadGzFileService.ReadWebMWQMRunGzFile(635);
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_1980_1989.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_1990_1999.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2000_2009.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2010_2019.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2020_2029.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2030_2039.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2040_2049.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSample_635_2050_2059.gz"));

            // Read gz
            WebMWQMSample webMWQMSample = await ReadGzFileService.ReadWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebMWQMSiteGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebMWQMSite_635.gz"));

            // Read gz
            WebMWQMSite webMWQMSite = await ReadGzFileService.ReadWebMWQMSiteGzFile(635);
            Assert.NotNull(webMWQMSite);
            Assert.NotNull(webMWQMSite.MWQMSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebPolSourceGroupingGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebPolSourceGrouping.gz"));

            // Read gz
            WebPolSourceGrouping webPolSourceGrouping = await ReadGzFileService.ReadWebPolSourceGroupingGzFile();
            Assert.NotNull(webPolSourceGrouping);
            Assert.NotNull(webPolSourceGrouping.PolSourceGroupingList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebPolSourceSiteGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebPolSourceSite_635.gz"));

            // Read gz
            WebPolSourceSite webPolSourceSite = await ReadGzFileService.ReadWebPolSourceSiteGzFile(635);
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebProvinceGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebProvince_7.gz"));

            // Read gz
            WebProvince webProvince = await ReadGzFileService.ReadWebProvinceGzFile(7);
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebReportTypeGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebReportType.gz"));

            // Read gz
            WebReportType webReportType = await ReadGzFileService.ReadWebReportTypeGzFile();
            Assert.NotNull(webReportType);
            Assert.NotNull(webReportType.ReportTypeList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebRootGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebRoot.gz"));

            // Read gz
            WebRoot webRoot = await ReadGzFileService.ReadWebRootGzFile();
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebSamplingPlanGzFile(8);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebSamplingPlan_8.gz"));

            // Read gz
            WebSamplingPlan webSamplingPlan = await ReadGzFileService.ReadWebSamplingPlanGzFile(8);
            Assert.NotNull(webSamplingPlan);
            Assert.NotNull(webSamplingPlan.SamplingPlanEmailList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebSectorGzFile(633);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebSector_633.gz"));

            // Read gz
            WebSector webSector = await ReadGzFileService.ReadWebSectorGzFile(633);
            Assert.NotNull(webSector);
            Assert.NotNull(webSector.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebSubsector_635.gz"));

            // Read gz
            WebSubsector webSubsector = await ReadGzFileService.ReadWebSubsectorGzFile(635);
            Assert.NotNull(webSubsector);
            Assert.NotNull(webSubsector.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // Create gz
            var actionRes = await CreateGzFileService.CreateWebTideLocationGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            Assert.True(await DownloadGzFileService.DownloadGzFile("WebTideLocation.gz"));

            // Read gz
            WebTideLocation webTideLocation = await ReadGzFileService.ReadWebTideLocationGzFile();
            Assert.NotNull(webTideLocation);
            Assert.NotNull(webTideLocation.TideLocationList);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
