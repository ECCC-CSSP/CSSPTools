namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<List<string>> GetJsonFileNameListAsync()
    {
        return await Task.FromResult(new List<string>()
        {
            $"{ WebTypeEnum.WebAllAddresses }.gz",
            $"{ WebTypeEnum.WebAllContacts }.gz",
            $"{ WebTypeEnum.WebAllCountries }.gz",
            $"{ WebTypeEnum.WebAllEmails }.gz",
            $"{ WebTypeEnum.WebAllHelpDocs }.gz",
            $"{ WebTypeEnum.WebAllMunicipalities }.gz",
            $"{ WebTypeEnum.WebAllMWQMAnalysisReportParameters }.gz",
            $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz",
            $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz",
            $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz",
            $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz",
            $"{ WebTypeEnum.WebAllProvinces }.gz",
            $"{ WebTypeEnum.WebAllReportTypes }.gz",
            $"{ WebTypeEnum.WebAllSearch }.gz",
            $"{ WebTypeEnum.WebAllTels }.gz",
            $"{ WebTypeEnum.WebAllTideLocations }.gz",
            $"{ WebTypeEnum.WebAllUseOfSites }.gz",
            $"{ WebTypeEnum.WebRoot }.gz",
        });
    }
}

