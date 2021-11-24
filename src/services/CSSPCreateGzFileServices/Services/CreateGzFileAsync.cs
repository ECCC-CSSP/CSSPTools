namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    public async Task<ActionResult<bool>> CreateGzFileAsync(WebTypeEnum webType, int TVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        switch (webType)
        {
            case WebTypeEnum.WebAllAddresses:
                await CreateWebAllAddressesGzFileAsync();
                break;
            case WebTypeEnum.WebAllContacts:
                await CreateWebAllContactsGzFileAsync();
                break;
            case WebTypeEnum.WebAllCountries:
                await CreateWebAllCountriesGzFileAsync();
                break;
            case WebTypeEnum.WebAllEmails:
                await CreateWebAllEmailsGzFileAsync();
                break;
            case WebTypeEnum.WebAllHelpDocs:
                await CreateWebAllHelpDocsGzFileAsync();
                break;
            case WebTypeEnum.WebAllMunicipalities:
                await CreateWebAllMunicipalitiesGzFileAsync();
                break;
            case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                await CreateWebAllMWQMAnalysisReportParametersGzFileAsync();
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                await CreateWebAllMWQMLookupMPNsGzFileAsync();
                break;
            case WebTypeEnum.WebAllMWQMSubsectors:
                await CreateWebAllMWQMSubsectorsGzFileAsync();
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                await CreateWebAllPolSourceGroupingsGzFileAsync();
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                await CreateWebAllPolSourceSiteEffectTermsGzFileAsync();
                break;
            case WebTypeEnum.WebAllProvinces:
                await CreateWebAllProvincesGzFileAsync();
                break;
            case WebTypeEnum.WebAllReportTypes:
                await CreateWebAllReportTypesGzFileAsync();
                break;
            case WebTypeEnum.WebAllSearch:
                await CreateWebAllSearchGzFileAsync();
                break;
            case WebTypeEnum.WebAllTels:
                await CreateWebAllTelsGzFileAsync();
                break;
            case WebTypeEnum.WebAllTideLocations:
                await CreateWebAllTideLocationsGzFileAsync();
                break;
            case WebTypeEnum.WebAllUseOfSites:
                await CreateWebAllUseOfSitesGzFileAsync();
                break;
            case WebTypeEnum.WebArea:
                await CreateWebAreaGzFileAsync(TVItemID); // TVItemID = AreaTVItemID
                break;
            case WebTypeEnum.WebClimateSites:
                await CreateWebClimateSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                break;
            case WebTypeEnum.WebCountry:
                await CreateWebCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                break;
            case WebTypeEnum.WebDrogueRuns:
                await CreateWebDrogueRunsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebHydrometricSites:
                await CreateWebHydrometricSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                break;
            case WebTypeEnum.WebLabSheets:
                await CreateWebLabSheetsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebMikeScenarios:
                await CreateWebMikeScenariosGzFileAsync(TVItemID); // TVItemID = MunicipalityTVItemID
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                await CreateWebMonitoringOtherStatsCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                await CreateWebMonitoringOtherStatsProvinceGzFileAsync(TVItemID);
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                await CreateWebMonitoringRoutineStatsCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                await CreateWebMonitoringRoutineStatsProvinceGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                break;
            case WebTypeEnum.WebMunicipality:
                await CreateWebMunicipalityGzFileAsync(TVItemID); // TVItemID = MunicipalityTVItemID
                break;
            case WebTypeEnum.WebMWQMRuns:
                await CreateWebMWQMRunsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                await CreateWebMWQMSamples1980_2020GzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                await CreateWebMWQMSamples2021_2060GzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebMWQMSites:
                await CreateWebMWQMSitesGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebPolSourceSites:
                await CreateWebPolSourceSitesGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebProvince:
                await CreateWebProvinceGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                break;
            case WebTypeEnum.WebRoot:
                await CreateWebRootGzFileAsync();
                break;
            case WebTypeEnum.WebSector:
                await CreateWebSectorGzFileAsync(TVItemID); // TVItemID = SectorTVItemID
                break;
            case WebTypeEnum.WebSubsector:
                await CreateWebSubsectorGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                break;
            case WebTypeEnum.WebTideSites:
                await CreateWebTideSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                break;
            default:
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }"));
                    CSSPLogService.EndFunctionLog(FunctionName);
                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0)
        {
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);
        return await Task.FromResult(Ok(true));
    }
}

