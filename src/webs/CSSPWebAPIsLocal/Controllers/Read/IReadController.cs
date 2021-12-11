namespace CSSPWebAPIsLocal.Controllers;

public partial interface IReadController
{
    Task<ActionResult<WebAllAddresses>> WebAllAddressesAsync();
    Task<ActionResult<WebAllContacts>> WebAllContactsAsync();
    Task<ActionResult<WebAllCountries>> WebAllCountriesAsync();
    Task<ActionResult<WebAllEmails>> WebAllEmailsAsync();
    Task<ActionResult<WebAllHelpDocs>> WebAllHelpDocsAsync();
    Task<ActionResult<WebAllMunicipalities>> WebAllMunicipalitiesAsync();
    Task<ActionResult<WebAllMWQMAnalysisReportParameters>> WebAllMWQMAnalysisReportParametersAsync();
    Task<ActionResult<WebAllMWQMLookupMPNs>> WebAllMWQMLookupMPNsAsync();
    Task<ActionResult<WebAllMWQMSubsectors>> WebAllMWQMSubsectorsAsync();
    Task<ActionResult<WebAllPolSourceGroupings>> WebAllPolSourceGroupingsAsync();
    Task<ActionResult<WebAllPolSourceSiteEffectTerms>> WebAllPolSourceSiteEffectTermsAsync();
    Task<ActionResult<WebAllProvinces>> WebAllProvincesAsync();
    Task<ActionResult<WebAllReportTypes>> WebAllReportTypesAsync();
    Task<ActionResult<WebAllTels>> WebAllTelsAsync();
    Task<ActionResult<WebAllTideLocations>> WebAllTideLocationsAsync();
    Task<ActionResult<WebAllUseOfSites>> WebAllUseOfSitesAsync();
    Task<ActionResult<WebArea>> WebAreaAsync(int TVItemID);
    Task<ActionResult<WebClimateSites>> WebClimateSitesAsync(int TVItemID);
    Task<ActionResult<WebCountry>> WebCountryAsync(int TVItemID);
    Task<ActionResult<WebDrogueRuns>> WebDrogueRunsAsync(int TVItemID);
    Task<ActionResult<WebHydrometricSites>> WebHydrometricSitesAsync(int TVItemID);
    Task<ActionResult<WebLabSheets>> WebLabSheetsAsync(int TVItemID);
    Task<ActionResult<WebMikeScenarios>> WebMikeScenariosAsync(int TVItemID);
    Task<ActionResult<WebMonitoringOtherStatsCountry>> WebMonitoringOtherStatsCountryAsync(int TVItemID);
    Task<ActionResult<WebMonitoringRoutineStatsCountry>> WebMonitoringRoutineStatsCountryAsync(int TVItemID);
    Task<ActionResult<WebMonitoringOtherStatsProvince>> WebMonitoringOtherStatsProvinceAsync(int TVItemID);
    Task<ActionResult<WebMonitoringRoutineStatsProvince>> WebMonitoringRoutineStatsProvinceAsync(int TVItemID);
    Task<ActionResult<WebMunicipality>> WebMunicipalityAsync(int TVItemID);
    Task<ActionResult<WebMWQMRuns>> WebMWQMRunsAsync(int TVItemID);
    Task<ActionResult<WebMWQMSamples1980_2020>> WebMWQMSamples1980_2020Async(int TVItemID);
    Task<ActionResult<WebMWQMSamples2021_2060>> WebMWQMSamples2021_2060Async(int TVItemID);
    Task<ActionResult<WebMWQMSites>> WebMWQMSitesAsync(int TVItemID);
    Task<ActionResult<WebPolSourceSites>> WebPolSourceSitesAsync(int TVItemID);
    Task<ActionResult<WebProvince>> WebProvinceAsync(int TVItemID);
    Task<ActionResult<WebRoot>> WebRootAsync();
    Task<ActionResult<WebAllSearch>> WebAllSearchAsync();
    Task<ActionResult<WebSector>> WebSectorAsync(int TVItemID);
    Task<ActionResult<WebSubsector>> WebSubsectorAsync(int TVItemID);
    Task<ActionResult<WebTideSites>> WebTideSitesAsync(int TVItemID);
}

