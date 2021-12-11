namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    private async Task TestReadJSON(WebTypeEnum webType, int TVItemID)
    {

        switch (webType)
        {
            case WebTypeEnum.WebAllAddresses:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllAddresses>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllAddresses webAllAddresses = (WebAllAddresses)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllAddresses);
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllContacts>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllContacts webAllContacts = (WebAllContacts)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllContacts);
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllCountries>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllCountries webAllCountries = (WebAllCountries)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllCountries);
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllEmails>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllEmails webAllEmails = (WebAllEmails)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllEmails);
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllHelpDocs>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllHelpDocs webAllHelpDocs = (WebAllHelpDocs)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllHelpDocs);
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllMunicipalities>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllMunicipalities webAllMunicipalities = (WebAllMunicipalities)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllMunicipalities);
                }
                break;
            case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllMWQMAnalysisReportParameters>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters = (WebAllMWQMAnalysisReportParameters)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllMWQMAnalysisReportParameters);
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllMWQMLookupMPNs>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = (WebAllMWQMLookupMPNs)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllMWQMLookupMPNs);
                }
                break;
            case WebTypeEnum.WebAllMWQMSubsectors:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllMWQMSubsectors>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllMWQMSubsectors webAllMWQMSubsectors = (WebAllMWQMSubsectors)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllMWQMSubsectors);
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllPolSourceGroupings>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllPolSourceGroupings webAllPolSourceGroupings = (WebAllPolSourceGroupings)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllPolSourceGroupings);
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllPolSourceSiteEffectTerms>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = (WebAllPolSourceSiteEffectTerms)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllPolSourceSiteEffectTerms);
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllProvinces>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllProvinces webAllProvinces = (WebAllProvinces)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllProvinces);
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllReportTypes>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllReportTypes webAllReportTypes = (WebAllReportTypes)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllReportTypes);
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllSearch>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllSearch webAllSearch = (WebAllSearch)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllSearch);
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllTels>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllTels webAllTels = (WebAllTels)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllTels);
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllTideLocations>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllTideLocations webAllTideLocations = (WebAllTideLocations)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllTideLocations);
                }
                break;
            case WebTypeEnum.WebAllUseOfSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebAllUseOfSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebAllUseOfSites webAllUseOfSites = (WebAllUseOfSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webAllUseOfSites);
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebArea>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebArea webArea = (WebArea)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webArea);
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebClimateSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebClimateSites webClimateSites = (WebClimateSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webClimateSites);
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebCountry>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebCountry webCountry = (WebCountry)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webCountry);
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebDrogueRuns>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebDrogueRuns webDrogueRuns = (WebDrogueRuns)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webDrogueRuns);
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebHydrometricSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebHydrometricSites webHydrometricSites = (WebHydrometricSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webHydrometricSites);
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebLabSheets>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebLabSheets webLabSheets = (WebLabSheets)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webLabSheets);
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMikeScenarios>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMikeScenarios webMikeScenarios = (WebMikeScenarios)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMikeScenarios);
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMonitoringOtherStatsCountry>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = (WebMonitoringOtherStatsCountry)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMonitoringOtherStatsCountry);
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMonitoringOtherStatsProvince>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince = (WebMonitoringOtherStatsProvince)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMonitoringOtherStatsProvince);
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMonitoringRoutineStatsCountry>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = (WebMonitoringRoutineStatsCountry)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMonitoringRoutineStatsCountry);
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMonitoringRoutineStatsProvince>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = (WebMonitoringRoutineStatsProvince)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMonitoringRoutineStatsProvince);
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMunicipality>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMunicipality webMunicipality = (WebMunicipality)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMunicipality);
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMWQMRuns>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMWQMRuns webMWQMRuns = (WebMWQMRuns)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMWQMRuns);
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMWQMSamples1980_2020>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMWQMSamples1980_2020 webMWQMSamples1980_2020 = (WebMWQMSamples1980_2020)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMWQMSamples1980_2020);
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMWQMSamples2021_2060>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMWQMSamples2021_2060 webMWQMSamples2021_2060 = (WebMWQMSamples2021_2060)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMWQMSamples2021_2060);
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebMWQMSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebMWQMSites webMWQMSites = (WebMWQMSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webMWQMSites);
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebPolSourceSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebPolSourceSites webPolSourceSites = (WebPolSourceSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webPolSourceSites);
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebProvince>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebProvince webProvince = (WebProvince)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webProvince);
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebRoot>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebRoot webRoot = (WebRoot)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webRoot);
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebSector>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebSector webSector = (WebSector)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webSector);
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebSubsector>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webSubsector);
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    var actionRes2 = await CSSPReadGzFileService.ReadJSONAsync<WebTideSites>(webType, TVItemID);
                    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
                    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
                    WebTideSites webTideSites = (WebTideSites)((OkObjectResult)actionRes2.Result).Value;
                    Assert.NotNull(webTideSites);
                }
                break;
            default:
                break;
        }
    }
}

