using CSSPEnums;
using CSSPWebModels;
using System.Threading.Tasks;
using Xunit;

namespace CSSPReadGzFileServices.Tests
{
    public partial class CSSPReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMWQMAnalysisReportParameters_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllMWQMAnalysisReportParameters;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMWQMSubsectors_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllMWQMSubsectors;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllSearch;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllTels;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllUseOfSites_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebAllUseOfSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebArea_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 629;
            WebTypeEnum webType = WebTypeEnum.WebArea;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebClimateSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 5;
            WebTypeEnum webType = WebTypeEnum.WebCountry;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebLabSheet_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebLabSheets;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 27764;
            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 5;
            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 5;
            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 27764;
            WebTypeEnum webType = WebTypeEnum.WebMunicipality;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSamples1980_2020(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSamples2021_2060(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 7;
            WebTypeEnum webType = WebTypeEnum.WebProvince;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebRoot_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 0;
            WebTypeEnum webType = WebTypeEnum.WebRoot;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebSector_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 633;
            WebTypeEnum webType = WebTypeEnum.WebSector;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
        [Theory(Skip = "WebTideSite does not yet have items")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebTideSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            int TVItemID = 635;
            WebTypeEnum webType = WebTypeEnum.WebTideSites;

            await DoFullGetUncompressTest(webType, TVItemID);
        }
    }
}
