namespace CSSPModels;

public partial class BaseGzFileService
{
    public BaseGzFileService()
    {
    }

    public static async Task<string> GetFileName(WebTypeEnum webType, int TVItemID)
    {
        string fileName = "";
        switch (webType)
        {
            case WebTypeEnum.WebAllAddresses: fileName = $"{ WebTypeEnum.WebAllAddresses }.gz"; break;
            case WebTypeEnum.WebAllEmails: fileName = $"{ WebTypeEnum.WebAllEmails }.gz"; break;
            case WebTypeEnum.WebAllTels: fileName = $"{ WebTypeEnum.WebAllTels }.gz"; break;
            case WebTypeEnum.WebAllContacts: fileName = $"{ WebTypeEnum.WebAllContacts }.gz"; break;
            case WebTypeEnum.WebAllCountries: fileName = $"{ WebTypeEnum.WebAllCountries }.gz"; break;
            case WebTypeEnum.WebAllHelpDocs: fileName = $"{ WebTypeEnum.WebAllHelpDocs }.gz"; break;
            case WebTypeEnum.WebAllMWQMAnalysisReportParameters: fileName = $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz"; break;
            case WebTypeEnum.WebAllMWQMLookupMPNs: fileName = $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz"; break;
            case WebTypeEnum.WebAllMWQMSubsectors: fileName = $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz"; break;
            case WebTypeEnum.WebAllMunicipalities: fileName = $"{ WebTypeEnum.WebAllMunicipalities }.gz"; break;
            case WebTypeEnum.WebAllPolSourceGroupings: fileName = $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz"; break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms: fileName = $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz"; break;
            case WebTypeEnum.WebAllProvinces: fileName = $"{ WebTypeEnum.WebAllProvinces }.gz"; break;
            case WebTypeEnum.WebAllReportTypes: fileName = $"{ WebTypeEnum.WebAllReportTypes }.gz"; break;
            case WebTypeEnum.WebAllSearch: fileName = $"{ WebTypeEnum.WebAllSearch }.gz"; break;
            case WebTypeEnum.WebAllTideLocations: fileName = $"{ WebTypeEnum.WebAllTideLocations }.gz"; break;
            case WebTypeEnum.WebAllUseOfSites: fileName = $"{ WebTypeEnum.WebAllUseOfSites }.gz"; break;
            case WebTypeEnum.WebArea: fileName = $"{ WebTypeEnum.WebArea }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebClimateSites: fileName = $"{ WebTypeEnum.WebClimateSites }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebCountry: fileName = $"{ WebTypeEnum.WebCountry }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebDrogueRuns: fileName = $"{ WebTypeEnum.WebDrogueRuns }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebHydrometricSites: fileName = $"{ WebTypeEnum.WebHydrometricSites }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebLabSheets: fileName = $"{ WebTypeEnum.WebLabSheets }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMikeScenarios: fileName = $"{ WebTypeEnum.WebMikeScenarios }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry: fileName = $"{ WebTypeEnum.WebMonitoringOtherStatsCountry }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry: fileName = $"{ WebTypeEnum.WebMonitoringRoutineStatsCountry }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince: fileName = $"{ WebTypeEnum.WebMonitoringOtherStatsProvince }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince: fileName = $"{ WebTypeEnum.WebMonitoringRoutineStatsProvince }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMunicipality: fileName = $"{ WebTypeEnum.WebMunicipality }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMWQMRuns: fileName = $"{ WebTypeEnum.WebMWQMRuns }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMWQMSamples1980_2020: fileName = $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMWQMSamples2021_2060: fileName = $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebMWQMSites: fileName = $"{ WebTypeEnum.WebMWQMSites }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebPolSourceSites: fileName = $"{ WebTypeEnum.WebPolSourceSites }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebProvince: fileName = $"{ WebTypeEnum.WebProvince }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebRoot: fileName = $"{ WebTypeEnum.WebRoot }.gz"; break;
            case WebTypeEnum.WebSector: fileName = $"{ WebTypeEnum.WebSector }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebSubsector: fileName = $"{ WebTypeEnum.WebSubsector }_{ TVItemID }.gz"; break;
            case WebTypeEnum.WebTideSites: fileName = $"{ WebTypeEnum.WebTideSites }_{ TVItemID }.gz"; break;
            default:
                return await Task.FromResult("WebError.gz");
        }

        return await Task.FromResult(fileName);
    }
}

