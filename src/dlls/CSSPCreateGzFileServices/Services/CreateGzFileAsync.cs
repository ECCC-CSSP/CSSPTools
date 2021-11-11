/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPCreateGzFileServices
{
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
                    await DoCreateWebAllAddressesGzFileAsync();
                    break;
                case WebTypeEnum.WebAllContacts:
                    await DoCreateWebAllContactsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllCountries:
                    await DoCreateWebAllCountriesGzFileAsync();
                    break;
                case WebTypeEnum.WebAllEmails:
                    await DoCreateWebAllEmailsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    await DoCreateWebAllHelpDocsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    await DoCreateWebAllMunicipalitiesGzFileAsync();
                    break;
                case WebTypeEnum.WebAllMWQMAnalysisReportParameters:
                    await DoCreateWebAllMWQMAnalysisReportParametersGzFileAsync();
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    await DoCreateWebAllMWQMLookupMPNsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllMWQMSubsectors:
                    await DoCreateWebAllMWQMSubsectorsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    await DoCreateWebAllPolSourceGroupingsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    await DoCreateWebAllPolSourceSiteEffectTermsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllProvinces:
                    await DoCreateWebAllProvincesGzFileAsync();
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    await DoCreateWebAllReportTypesGzFileAsync();
                    break;
                case WebTypeEnum.WebAllSearch:
                    await DoCreateWebAllSearchGzFileAsync();
                    break;
                case WebTypeEnum.WebAllTels:
                    await DoCreateWebAllTelsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    await DoCreateWebAllTideLocationsGzFileAsync();
                    break;
                case WebTypeEnum.WebAllUseOfSites:
                    await DoCreateWebAllUseOfSitesGzFileAsync();
                    break;
                case WebTypeEnum.WebArea:
                    await DoCreateWebAreaGzFileAsync(TVItemID); // TVItemID = AreaTVItemID
                    break;
                case WebTypeEnum.WebClimateSites:
                    await DoCreateWebClimateSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebCountry:
                    await DoCreateWebCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    await DoCreateWebDrogueRunsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    await DoCreateWebHydrometricSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebLabSheets:
                    await DoCreateWebLabSheetsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMikeScenarios:
                    await DoCreateWebMikeScenariosGzFileAsync(TVItemID); // TVItemID = MunicipalityTVItemID
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    await DoCreateWebMonitoringOtherStatsCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    await DoCreateWebMonitoringOtherStatsProvinceGzFileAsync(TVItemID);
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    await DoCreateWebMonitoringRoutineStatsCountryGzFileAsync(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    await DoCreateWebMonitoringRoutineStatsProvinceGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebMunicipality:
                    await DoCreateWebMunicipalityGzFileAsync(TVItemID); // TVItemID = MunicipalityTVItemID
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    await DoCreateWebMWQMRunsGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    await DoCreateWebMWQMSamples1980_2020GzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    await DoCreateWebMWQMSamples2021_2060GzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSites:
                    await DoCreateWebMWQMSitesGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    await DoCreateWebPolSourceSitesGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebProvince:
                    await DoCreateWebProvinceGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebRoot:
                    await DoCreateWebRootGzFileAsync();
                    break;
                case WebTypeEnum.WebSector:
                    await DoCreateWebSectorGzFileAsync(TVItemID); // TVItemID = SectorTVItemID
                    break;
                case WebTypeEnum.WebSubsector:
                    await DoCreateWebSubsectorGzFileAsync(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebTideSites:
                    await DoCreateWebTideSitesGzFileAsync(TVItemID); // TVItemID = ProvinceTVItemID
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
}
