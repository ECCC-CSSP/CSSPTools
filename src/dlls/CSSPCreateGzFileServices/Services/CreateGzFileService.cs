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

namespace CreateGzFileServices
{
    public interface ICreateGzFileService
    {
        Task<bool> CreateAllGzFiles();
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
        Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYearEnum);
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService,
            IScrambleService ScrambleService, IEnums enums, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateAllGzFiles()
        {
            //return await Task.FromResult(false);
            return await DoCreateAllGzFiles();
        }
        public async Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllContacts:
                    return await DoCreateWebAllContactsGzFile();
                case WebTypeEnum.WebAllCountries:
                    return await DoCreateWebAllCountriesGzFile();
                case WebTypeEnum.WebAllHelpDocs:
                    return await DoCreateWebAllHelpDocsGzFile();
                case WebTypeEnum.WebAllMunicipalities:
                    return await DoCreateWebAllMunicipalitiesGzFile();
                case WebTypeEnum.WebAllMWQMLookupMPNs:
                    return await DoCreateWebAllMWQMLookupMPNsGzFile();
                case WebTypeEnum.WebAllPolSourceGroupings:
                    return await DoCreateWebAllPolSourceGroupingsGzFile();
                case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                    return await DoCreateWebAllPolSourceSiteEffectTermsGzFile();
                case WebTypeEnum.WebAllProvinces:
                    return await DoCreateWebAllProvincesGzFile();
                case WebTypeEnum.WebAllReportTypes:
                    return await DoCreateWebAllReportTypesGzFile();
                case WebTypeEnum.WebAllTideLocations:
                    return await DoCreateWebAllTideLocationsGzFile();
                case WebTypeEnum.WebAllTVItems:
                    return await DoCreateWebAllTVItemsGzFile();
                case WebTypeEnum.WebAllTVItemLanguages:
                    return await DoCreateWebAllTVItemLanguagesGzFile();
                case WebTypeEnum.WebArea:
                    return await DoCreateWebAreaGzFile(TVItemID); // TVItemID = AreaTVItemID
                case WebTypeEnum.WebClimateDataValue:
                    return await DoCreateWebClimateDataValueGzFile(TVItemID); // TVItemID = ClimateSiteTVItemID
                case WebTypeEnum.WebClimateSite:
                    return await DoCreateWebClimateSiteGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebCountry:
                    return await DoCreateWebCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                case WebTypeEnum.WebDrogueRun:
                    return await DoCreateWebDrogueRunGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebHydrometricDataValue:
                    return await DoCreateWebHydrometricDataValueGzFile(TVItemID); // TVItemID = HydrometricSiteTVItemID
                case WebTypeEnum.WebHydrometricSite:
                    return await DoCreateWebHydrometricSiteGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebMikeScenario:
                    return await DoCreateWebMikeScenarioGzFile(TVItemID); // TVItemID = MikeScenarioTVItemID
                case WebTypeEnum.WebMunicipalities:
                    return await DoCreateWebMunicipalitiesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebMunicipality:
                    return await DoCreateWebMunicipalityGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                case WebTypeEnum.WebMWQMRun:
                    return await DoCreateWebMWQMRunGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSample:
                    {
                        switch (webTypeYear)
                        {
                            case WebTypeYearEnum.Year1980:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 1980); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year1990:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 1990); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2000:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2000); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2010:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2010); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2020:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2020); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2030:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2030); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2040:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2040); // TVItemID = SubsectorTVItemID
                            case WebTypeYearEnum.Year2050:
                                return await DoCreateWebMWQMSampleGzFile(TVItemID, 2050); // TVItemID = SubsectorTVItemID
                            default:
                                return await Task.FromResult(BadRequest($"{ webTypeYear } not implemented yet"));
                        }
                    }
                case WebTypeEnum.WebMWQMSite:
                    return await DoCreateWebMWQMSiteGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebPolSourceSite:
                    return await DoCreateWebPolSourceSiteGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebProvince:
                    return await DoCreateWebProvinceGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebRoot:
                    return await DoCreateWebRootGzFile();
                case WebTypeEnum.WebSamplingPlan:
                    return await DoCreateWebSamplingPlanGzFile(TVItemID); // TVItemID = SamplingPlanID
                case WebTypeEnum.WebSector:
                    return await DoCreateWebSectorGzFile(TVItemID); // TVItemID = SectorTVItemID
                case WebTypeEnum.WebSubsector:
                    return await DoCreateWebSubsectorGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                default:
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }")));
            }
        }
        public async Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            return await DoDeleteGzFile(webType, TVItemID, webTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
