namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    private async Task TestGetUncompressJSON(WebTypeEnum webType, int TVItemID)
    {

        switch (webType)
        {
            case WebTypeEnum.WebAllAddresses:
                {
                    WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllAddresses>(webType, TVItemID);
                    Assert.NotNull(webAllAddresses);
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    WebAllContacts webAllContacts = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllContacts>(webType, TVItemID);
                    Assert.NotNull(webAllContacts);
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    WebAllCountries webAllCountries = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllCountries>(webType, TVItemID);
                    Assert.NotNull(webAllCountries);
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllEmails>(webType, TVItemID);
                    Assert.NotNull(webAllEmails);
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(webType, TVItemID);
                    Assert.NotNull(webAllHelpDocs);
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    WebAllMunicipalities webAllMunicipalities = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMunicipalities>(webType, TVItemID);
                    Assert.NotNull(webAllMunicipalities);
                }
                break;
            case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                {
                    WebAllMWQMAnalysisReportParameters webAllMWQMAnalysisReportParameters = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMAnalysisReportParameters>(webType, TVItemID);
                    Assert.NotNull(webAllMWQMAnalysisReportParameters);
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMLookupMPNs>(webType, TVItemID);
                    Assert.NotNull(webAllMWQMLookupMPNs);
                }
                break;
            case WebTypeEnum.WebAllMWQMSubsectors:
                {
                    WebAllMWQMSubsectors webAllMWQMSubsectors = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMSubsectors>(webType, TVItemID);
                    Assert.NotNull(webAllMWQMSubsectors);
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    WebAllPolSourceGroupings webAllPolSourceGroupings = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllPolSourceGroupings>(webType, TVItemID);
                    Assert.NotNull(webAllPolSourceGroupings);
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllPolSourceSiteEffectTerms>(webType, TVItemID);
                    Assert.NotNull(webAllPolSourceSiteEffectTerms);
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    WebAllProvinces webAllProvinces = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllProvinces>(webType, TVItemID);
                    Assert.NotNull(webAllProvinces);
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    WebAllReportTypes webAllReportTypes = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllReportTypes>(webType, TVItemID);
                    Assert.NotNull(webAllReportTypes);
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    WebAllSearch webAllSearch = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllSearch>(webType, TVItemID);
                    Assert.NotNull(webAllSearch);
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllTels>(webType, TVItemID);
                    Assert.NotNull(webAllTels);
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    WebAllTideLocations webAllTideLocations = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllTideLocations>(webType, TVItemID);
                    Assert.NotNull(webAllTideLocations);
                }
                break;
            case WebTypeEnum.WebAllUseOfSites:
                {
                    WebAllUseOfSites webAllUseOfSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllUseOfSites>(webType, TVItemID);
                    Assert.NotNull(webAllUseOfSites);
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(webType, TVItemID);
                    Assert.NotNull(webArea);
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(webType, TVItemID);
                    Assert.NotNull(webClimateSites);
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(webType, TVItemID);
                    Assert.NotNull(webCountry);
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    WebDrogueRuns webDrogueRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebDrogueRuns>(webType, TVItemID);
                    Assert.NotNull(webDrogueRuns);
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(webType, TVItemID);
                    Assert.NotNull(webHydrometricSites);
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    WebLabSheets webLabSheets = await CSSPReadGzFileService.GetUncompressJSONAsync<WebLabSheets>(webType, TVItemID);
                    Assert.NotNull(webLabSheets);
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(webType, TVItemID);
                    Assert.NotNull(webMikeScenarios);
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMonitoringOtherStatsCountry>(webType, TVItemID);
                    Assert.NotNull(webMonitoringOtherStatsCountry);
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMonitoringOtherStatsProvince>(webType, TVItemID);
                    Assert.NotNull(webMonitoringOtherStatsProvince);
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMonitoringRoutineStatsCountry>(webType, TVItemID);
                    Assert.NotNull(webMonitoringRoutineStatsCountry);
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMonitoringRoutineStatsProvince>(webType, TVItemID);
                    Assert.NotNull(webMonitoringRoutineStatsProvince);
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(webType, TVItemID);
                    Assert.NotNull(webMunicipality);
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMRuns>(webType, TVItemID);
                    Assert.NotNull(webMWQMRuns);
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    WebMWQMSamples1980_2020 webMWQMSamples1980_2020 = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSamples1980_2020>(webType, TVItemID);
                    Assert.NotNull(webMWQMSamples1980_2020);
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    WebMWQMSamples2021_2060 webMWQMSamples2021_2060 = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSamples2021_2060>(webType, TVItemID);
                    Assert.NotNull(webMWQMSamples2021_2060);
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(webType, TVItemID);
                    Assert.NotNull(webMWQMSites);
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(webType, TVItemID);
                    Assert.NotNull(webPolSourceSites);
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(webType, TVItemID);
                    Assert.NotNull(webProvince);
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(webType, TVItemID);
                    Assert.NotNull(webRoot);
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(webType, TVItemID);
                    Assert.NotNull(webSector);
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(webType, TVItemID);
                    Assert.NotNull(webSubsector);
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(webType, TVItemID);
                    Assert.NotNull(webTideSites);
                }
                break;
            default:
                break;
        }
    }
}

