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
using CSSPDBFilesManagementModels;
using CSSPDBPreferenceModels;
using CSSPScrambleServices;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public interface ICreateGzFileService
    {
        Task<bool> CreateAllGzFiles();
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID = 0);
    }
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        //private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IScrambleService ScrambleService { get; }
        private IEnums enums { get; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        List<ValidationResult> ValidationResultList { get; set; }
        #endregion Properties

        #region Constructors
        public CreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService,
            IScrambleService ScrambleService, IEnums enums, CSSPDBContext db = null, CSSPDBLocalContext dbLocal = null)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;

            // used with db
            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));

            // used with dbLocal
            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateAllGzFiles()
        {
            if (!await ValidateDBs()) return await Task.FromResult(false);

            return await DoCreateAllGzFiles();

        }
        public async Task<ActionResult<bool>> CreateGzFile(WebTypeEnum webType, int TVItemID)
        {
            switch (webType)
            {
                case WebTypeEnum.WebAllAddresses:
                    return await DoCreateWebAllAddressesGzFile();
                case WebTypeEnum.WebAllContacts:
                    return await DoCreateWebAllContactsGzFile();
                case WebTypeEnum.WebAllCountries:
                    return await DoCreateWebAllCountriesGzFile();
                case WebTypeEnum.WebAllEmails:
                    return await DoCreateWebAllEmailsGzFile();
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
                case WebTypeEnum.WebAllTels:
                    return await DoCreateWebAllTelsGzFile();
                case WebTypeEnum.WebAllTideLocations:
                    return await DoCreateWebAllTideLocationsGzFile();
                case WebTypeEnum.WebAllTVItemLanguages1980_2020:
                    return await DoCreateWebAllTVItemLanguages1980_2020GzFile();
                case WebTypeEnum.WebAllTVItemLanguages2021_2060:
                    return await DoCreateWebAllTVItemLanguages2021_2060GzFile();
                case WebTypeEnum.WebAllTVItems1980_2020:
                    return await DoCreateWebAllTVItems1980_2020GzFile();
                case WebTypeEnum.WebAllTVItems2021_2060:
                    return await DoCreateWebAllTVItems2021_2060GzFile();
                case WebTypeEnum.WebArea:
                    return await DoCreateWebAreaGzFile(TVItemID); // TVItemID = AreaTVItemID
                case WebTypeEnum.WebClimateSites:
                    return await DoCreateWebClimateSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebCountry:
                    return await DoCreateWebCountryGzFile(TVItemID); // TVItemID = CountryTVItemID
                case WebTypeEnum.WebDrogueRuns:
                    return await DoCreateWebDrogueRunsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebHydrometricSites:
                    return await DoCreateWebHydrometricSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebLabSheets:
                    return await DoCreateWebLabSheetsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMikeScenarios:
                    return await DoCreateWebMikeScenariosGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                case WebTypeEnum.WebMunicipality:
                    return await DoCreateWebMunicipalityGzFile(TVItemID); // TVItemID = MunicipalityTVItemID
                case WebTypeEnum.WebMWQMRuns:
                    return await DoCreateWebMWQMRunsGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSamples1980_2020:
                    return await DoCreateWebMWQMSamples1980_2020GzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSamples2021_2060:
                    return await DoCreateWebMWQMSamples2021_2060GzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebMWQMSites:
                    return await DoCreateWebMWQMSitesGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebPolSourceSites:
                    return await DoCreateWebPolSourceSitesGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebProvince:
                    return await DoCreateWebProvinceGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                case WebTypeEnum.WebRoot:
                    return await DoCreateWebRootGzFile();
                case WebTypeEnum.WebSector:
                    return await DoCreateWebSectorGzFile(TVItemID); // TVItemID = SectorTVItemID
                case WebTypeEnum.WebSubsector:
                    return await DoCreateWebSubsectorGzFile(TVItemID); // TVItemID = SubsectorTVItemID
                case WebTypeEnum.WebTideSites:
                    return await DoCreateWebTideSitesGzFile(TVItemID); // TVItemID = ProvinceTVItemID
                default:
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }")));
            }
        }
        public async Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID)
        {
            return await DoDeleteGzFile(webType, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> ValidateDBs()
        {
            if (db == null && dbLocal == null)
            {
                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db || dbLocal"), new[] { "" }));
            }

            if (dbLocal != null)
            {
                if (string.IsNullOrWhiteSpace(CSSPJSONPathLocal))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPJSONPathLocal"), new[] { "" }));
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(AzureStoreCSSPJSONPath))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStoreCSSPJSONPath"), new[] { "" }));
                }

                if (string.IsNullOrWhiteSpace(AzureStore))
                {
                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStore"), new[] { "" }));
                }
            }

            return await Task.FromResult(ValidationResultList.Count == 0 ? true : false);
        }
        #endregion Functions private
    }
}
