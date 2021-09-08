/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoggedInServices;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices;
using System.Reflection;
using CSSPCreateGzFileServices.Models;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        public async Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";

            if (!await CSSPLogService.FunctionLog(FunctionName)) return await Task.FromResult(false);
            if (!await CheckComputerName(FunctionName)) return await Task.FromResult(false);
            if (!await CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));
            if (!await ValidateDBs(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));

            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    await DoCreateWebAllAddressesGzFile();
                    break;
                case WebTypeEnum.WebAllContacts:
                    await DoCreateWebAllContactsGzFile();
                    break;
                case WebTypeEnum.WebAllCountries:
                    await DoCreateWebAllCountriesGzFile();
                    break;
                case WebTypeEnum.WebAllEmails:
                    await DoCreateWebAllEmailsGzFile();
                    break;
                case WebTypeEnum.WebAllHelpDocs:
                    await DoCreateWebAllHelpDocsGzFile();
                    break;
                case WebTypeEnum.WebAllMunicipalities:
                    await DoCreateWebAllMunicipalitiesGzFile();
                    break;
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    await DoCreateWebAllMWQMLookupMPNsGzFile();
                    break;
                case WebTypeEnum.WebAllPolSourceGroupings:
                    await DoCreateWebAllPolSourceGroupingsGzFile();
                    break;
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    await DoCreateWebAllPolSourceSiteEffectTermsGzFile();
                    break;
                case WebTypeEnum.WebAllProvinces:
                    await DoCreateWebAllProvincesGzFile();
                    break;
                case WebTypeEnum.WebAllReportTypes:
                    await DoCreateWebAllReportTypesGzFile();
                    break;
                case WebTypeEnum.WebAllTels:
                    await DoCreateWebAllTelsGzFile();
                    break;
                case WebTypeEnum.WebAllTideLocations:
                    await DoCreateWebAllTideLocationsGzFile();
                    break;
                case WebTypeEnum.WebArea:
                    await DoCreateWebAreaGzFile(TVItemID); // TVItemID = AreaTVItemID
                    break;
                case WebTypeEnum.WebClimateSites:
                    await DoCreateWebClimateSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebCountry:
                    await DoCreateWebCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebDrogueRuns:
                    await DoCreateWebDrogueRunsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebHydrometricSites:
                    await DoCreateWebHydrometricSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebLabSheets:
                    await DoCreateWebLabSheetsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMikeScenarios:
                    await DoCreateWebMikeScenariosGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                    break;
                case WebTypeEnum.WebMunicipality:
                    await DoCreateWebMunicipalityGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                    break;
                case WebTypeEnum.WebMWQMRuns:
                    await DoCreateWebMWQMRunsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    await DoCreateWebMWQMSamples1980_2020GzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    await DoCreateWebMWQMSamples2021_2060GzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebMWQMSites:
                    await DoCreateWebMWQMSitesGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebPolSourceSites:
                    await DoCreateWebPolSourceSitesGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebProvince:
                    await DoCreateWebProvinceGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebRoot:
                    await DoCreateWebRootGzFile();
                    break;
                case WebTypeEnum.WebAllSearch:
                    await DoCreateWebAllSearchGzFile();
                    break;
                case WebTypeEnum.WebSector:
                    await DoCreateWebSectorGzFile(TVItemID); // TVItemID = SectorTVItemID
                    break;
                case WebTypeEnum.WebSubsector:
                    await DoCreateWebSubsectorGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                    break;
                case WebTypeEnum.WebTideSites:
                    await DoCreateWebTideSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsCountry:
                    await DoCreateWebMonitoringOtherStatsCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                    await DoCreateWebMonitoringRoutineStatsCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                    break;
                case WebTypeEnum.WebMonitoringOtherStatsProvince:
                    await DoCreateWebMonitoringOtherStatsProvinceGzFile(TVItemID);
                    break;
                case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                    await DoCreateWebMonitoringRoutineStatsProvinceGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                    break;
                default:
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }")));
            }

            return await EndFunctionReturn(FunctionName);
        }
    }
}
