using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPReadGzFileServices.Tests
{
     public partial class CSSPReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllAddresses>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllAddresses webAllAddresses = (WebAllAddresses)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllAddresses);
            //Assert.NotNull(webAllAddresses.AddressModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllContacts>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllContacts webAllContacts = (WebAllContacts)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllContacts);
            Assert.NotNull(webAllContacts.ContactModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllCountries>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllCountries webAllCountries = (WebAllCountries)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllCountries);
            //Assert.NotNull(webAllCountries.TVItemModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllEmails>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllEmails webAllEmails = (WebAllEmails)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllEmails);
            //Assert.NotNull(webAllEmails.EmailModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllHelpDocs>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllHelpDocs webAllHelpDocs = (WebAllHelpDocs)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllHelpDocs);
            Assert.NotNull(webAllHelpDocs.HelpDocList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllMunicipalities>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllMunicipalities webAllMunicipalities = (WebAllMunicipalities)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllMunicipalities);
            //Assert.NotNull(webAllMunicipalities.TVItemModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllMWQMAnalysisReportParameters_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMAnalysisReportParameters;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllMWQMAnalysisReportParameters>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters = (WebAllMWQMAnalysisReportParameters)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllMWQMAnalysisReportParameters);
            Assert.NotNull(webAllMWQMAnalysisReportParameters.MWQMAnalysisReportParameterList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllMWQMLookupMPNs>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = (WebAllMWQMLookupMPNs)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotNull(webAllMWQMLookupMPNs.MWQMLookupMPNList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllMWQMSubsectors_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMSubsectors;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllMWQMSubsectors>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllMWQMSubsectors webAllMWQMSubsectors = (WebAllMWQMSubsectors)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllMWQMSubsectors);
            Assert.NotNull(webAllMWQMSubsectors.MWQMSubsectorModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllPolSourceGroupings>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllPolSourceGroupings webAllPolSourceGroupings = (WebAllPolSourceGroupings)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllPolSourceGroupings);
            Assert.NotNull(webAllPolSourceGroupings.PolSourceGroupingModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllPolSourceSiteEffectTerms>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = (WebAllPolSourceSiteEffectTerms)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllPolSourceSiteEffectTerms);
            Assert.NotNull(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllReportTypes>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllReportTypes webAllReportTypes = (WebAllReportTypes)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllReportTypes);
            Assert.NotNull(webAllReportTypes.ReportTypeModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllSearch_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllSearch;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllSearch>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllSearch webAllSearch = (WebAllSearch)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllSearch);
            Assert.NotEmpty(webAllSearch.TVItemModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTels;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllTels>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTels webAllTels = (WebAllTels)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllTels);
            Assert.NotEmpty(webAllTels.TelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllTideLocations>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTideLocations webAllTideLocations = (WebAllTideLocations)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllTideLocations);
            Assert.NotNull(webAllTideLocations.TideLocationList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebAllUseOfSites_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllUseOfSites;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebAllUseOfSites>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllUseOfSites webAllUseOfSites = (WebAllUseOfSites)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllUseOfSites);
            Assert.NotEmpty(webAllUseOfSites.UseOfSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebArea_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebArea>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebArea webArea = (WebArea)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webArea);
            Assert.NotNull(webArea.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebClimateSites>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebClimateSites webClimateSite = (WebClimateSites)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webClimateSite);
            Assert.NotNull(webClimateSite.ClimateSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebCountry>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebCountry webCountry = (WebCountry)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebDrogueRuns>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebDrogueRuns webDrogueRuns = (WebDrogueRuns)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webDrogueRuns);
            Assert.NotEmpty(webDrogueRuns.DrogueRunModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebHydrometricSites>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebHydrometricSites webHydrometricSite = (WebHydrometricSites)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webHydrometricSite);
            Assert.NotNull(webHydrometricSite.HydrometricSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebLabSheets_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebLabSheets;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebLabSheets>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebLabSheets webLabSheets = (WebLabSheets)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webLabSheets);
            Assert.NotEmpty(webLabSheets.LabSheetModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            int TVItemID = 27764;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMikeScenarios>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMikeScenarios webMikeScenarios = (WebMikeScenarios)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMikeScenarios);
            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
            int TVItemID = 5;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMonitoringOtherStatsCountry>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = (WebMonitoringOtherStatsCountry)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMonitoringOtherStatsCountry);
            Assert.NotEmpty(webMonitoringOtherStatsCountry.MonitoringStatsModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMonitoringOtherStatsProvince>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince = (WebMonitoringOtherStatsProvince)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMonitoringOtherStatsProvince);
            Assert.NotEmpty(webMonitoringOtherStatsProvince.MonitoringStatsModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
            int TVItemID = 5;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMonitoringRoutineStatsCountry>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = (WebMonitoringRoutineStatsCountry)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMonitoringRoutineStatsCountry);
            Assert.NotEmpty(webMonitoringRoutineStatsCountry.MonitoringStatsModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMonitoringRoutineStatsProvince>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = (WebMonitoringRoutineStatsProvince)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMonitoringRoutineStatsProvince);
            Assert.NotEmpty(webMonitoringRoutineStatsProvince.MonitoringStatsModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 27764;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMunicipality>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMunicipality webMunicipality = (WebMunicipality)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMunicipality);
            Assert.NotNull(webMunicipality.InfrastructureModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMWQMRuns>(webType, TVItemID);            
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMRuns webMWQMRun = (WebMWQMRuns)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMWQMSamples>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSamples webMWQMSample = (WebMWQMSamples)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMWQMSamples>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSamples webMWQMSample = (WebMWQMSamples)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebMWQMSites>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSites webMWQMSite = (WebMWQMSites)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSite);
            Assert.NotNull(webMWQMSite.MWQMSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebPolSourceSites>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebPolSourceSites webPolSourceSite = (WebPolSourceSites)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebProvince_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebProvince>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebProvince webProvince = (WebProvince)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItemModelAreaList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebRoot_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebRoot>(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebRoot webRoot = (WebRoot)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItemModelCountryList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebSector_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebSector>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebSector webSector = (WebSector)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webSector);
            Assert.NotNull(webSector.TVItemModelSubsectorList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;

            var actionRes = await CSSPReadGzFileService.ReadJSON<WebSubsector>(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webSubsector);
        }
    }
}
