﻿/*
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
using CSSPDBFilesManagementModels;
using CSSPDBPreferenceServices;
using CSSPDBPreferenceModels;
using CSSPScrambleServices;

namespace CreateGzFileLocalServices
{
    public interface ICreateGzFileLocalService
    {
        Task<bool> CreateAllGzFilesLocal();
        Task<ActionResult<bool>> CreateGzFileLocal(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
        Task<ActionResult<bool>> DeleteGzFileLocal(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
    }
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private string AzureStore { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService,
            IScrambleService ScrambleService, IEnums enums, CSSPDBLocalContext dbLocal)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.dbLocal = dbLocal;

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateAllGzFilesLocal()
        {
            //return await Task.FromResult(false);
            return await DoCreateAllGzFilesLocal();
        }
        public async Task<ActionResult<bool>> CreateGzFileLocal(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    return await DoCreateWebAllAddressesGzFileLocal();
                case WebTypeEnum.WebAllContacts:
                    return await DoCreateWebAllContactsGzFileLocal();
                case WebTypeEnum.WebAllCountries:
                    return await DoCreateWebAllCountriesGzFileLocal();
                case WebTypeEnum.WebAllEmails:
                    return await DoCreateWebAllEmailsGzFileLocal();
                case WebTypeEnum.WebAllHelpDocs:
                    return await DoCreateWebAllHelpDocsGzFileLocal();
                case WebTypeEnum.WebAllMunicipalities:
                    return await DoCreateWebAllMunicipalitiesGzFileLocal();
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    return await DoCreateWebAllMWQMLookupMPNsGzFileLocal();
                case WebTypeEnum.WebAllPolSourceGroupings:
                    return await DoCreateWebAllPolSourceGroupingsGzFileLocal();
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    return await DoCreateWebAllPolSourceSiteEffectTermsGzFileLocal();
                case WebTypeEnum.WebAllProvinces:
                    return await DoCreateWebAllProvincesGzFileLocal();
                case WebTypeEnum.WebAllReportTypes:
                    return await DoCreateWebAllReportTypesGzFileLocal();
                case WebTypeEnum.WebAllTels:
                    return await DoCreateWebAllTelsGzFileLocal();
                case WebTypeEnum.WebAllTideLocations:
                    return await DoCreateWebAllTideLocationsGzFileLocal();
                case WebTypeEnum.WebAllTVItems:
                    return await DoCreateWebAllTVItemsGzFileLocal();
                case WebTypeEnum.WebAllTVItemLanguages:
                    return await DoCreateWebAllTVItemLanguagesGzFileLocal();
                case WebTypeEnum.WebArea:
                    return await DoCreateWebAreaGzFileLocal(TVItemID); // TVItemID = AreaTVItemID
                case WebTypeEnum.WebClimateDataValue:
                    return await DoCreateWebClimateDataValueGzFileLocal(TVItemID); // TVItemID = ClimateSiteTVItemID
                case WebTypeEnum.WebClimateSite:
                    return await DoCreateWebClimateSiteGzFileLocal(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebCountry:
                    return await DoCreateWebCountryGzFileLocal(TVItemID); // TVItemID = CountryTVItemID
                case WebTypeEnum.WebDrogueRun:
                    return await DoCreateWebDrogueRunGzFileLocal(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebHydrometricDataValue:
                    return await DoCreateWebHydrometricDataValueGzFileLocal(TVItemID); // TVItemID = HydrometricSiteTVItemID
                case WebTypeEnum.WebHydrometricSite:
                    return await DoCreateWebHydrometricSiteGzFileLocal(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebMikeScenario:
                    return await DoCreateWebMikeScenarioGzFileLocal(TVItemID); // TVItemID = MikeScenarioTVItemID
                case WebTypeEnum.WebMunicipalities:
                    return await DoCreateWebMunicipalitiesGzFileLocal(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebMunicipality:
                    return await DoCreateWebMunicipalityGzFileLocal(TVItemID); // TVItemID = MunicipalityTVItemID
                case WebTypeEnum.WebMWQMRun:
                    return await DoCreateWebMWQMRunGzFileLocal(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSample:
                    {
                        switch (webTypeYear)
                        {
                            case WebTypeYearEnum.Year1980:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 1980); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year1990:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 1990); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2000:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2000); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2010:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2010); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2020:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2020); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2030:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2030); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2040:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2040); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2050:
                                return await DoCreateWebMWQMSampleGzFileLocal(TVItemID, 2050); // TVItemID = SubsectorTVItemID
                            default:
                                return await Task.FromResult(BadRequest($"{ webTypeYear } not implemented yet"));
                        }
                    }
                case WebTypeEnum.WebMWQMSite:
                    return await DoCreateWebMWQMSiteGzFileLocal(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebPolSourceSite:
                    return await DoCreateWebPolSourceSiteGzFileLocal(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebProvince:
                    return await DoCreateWebProvinceGzFileLocal(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebRoot:
                    return await DoCreateWebRootGzFileLocal();
                case WebTypeEnum.WebSamplingPlan:
                    return await DoCreateWebSamplingPlanGzFileLocal(TVItemID); // TVItemID = SamplingPlanID
                case WebTypeEnum.WebSector:
                    return await DoCreateWebSectorGzFileLocal(TVItemID); // TVItemID = SectorTVItemID
                case WebTypeEnum.WebSubsector:
                    return await DoCreateWebSubsectorGzFileLocal(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebTideDataValue:
                    return await DoCreateWebTideDataValueGzFileLocal(TVItemID); // TVItemID = ClimateSiteTVItemID
                case WebTypeEnum.WebTideSite:
                    return await DoCreateWebTideSiteGzFileLocal(TVItemID); // TVItemID = ProvinceTVItemID
                default:
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }")));
            }
        }
        public async Task<ActionResult<bool>> DeleteGzFileLocal(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            return await DoDeleteGzFileLocal(webType, TVItemID, webTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
