/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using ReadGzFileServices;
using System.Threading;
using CSSPWebModels;
using CSSPLocalLoggedInServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IReadController
    {
        Task<ActionResult<WebAllAddresses>> WebAllAddresses();
        Task<ActionResult<WebAllContacts>> WebAllContacts();
        Task<ActionResult<WebAllCountries>> WebAllCountries();
        Task<ActionResult<WebAllEmails>> WebAllEmails();
        Task<ActionResult<WebAllHelpDocs>> WebAllHelpDocs();
        Task<ActionResult<WebAllMunicipalities>> WebAllMunicipalities();
        Task<ActionResult<WebAllMWQMLookupMPNs>> WebAllMWQMLookupMPNs();
        Task<ActionResult<WebAllPolSourceGroupings>> WebAllPolSourceGroupings();
        Task<ActionResult<WebAllPolSourceSiteEffectTerms>> WebAllPolSourceSiteEffectTerms();
        Task<ActionResult<WebAllProvinces>> WebAllProvinces();
        Task<ActionResult<WebAllReportTypes>> WebAllReportTypes();
        Task<ActionResult<WebAllTels>> WebAllTels();
        Task<ActionResult<WebAllTideLocations>> WebAllTideLocations();
        Task<ActionResult<WebArea>> WebArea(int TVItemID);
        Task<ActionResult<WebClimateSites>> WebClimateSites(int TVItemID);
        Task<ActionResult<WebCountry>> WebCountry(int TVItemID);
        Task<ActionResult<WebDrogueRuns>> WebDrogueRuns(int TVItemID);
        Task<ActionResult<WebHydrometricSites>> WebHydrometricSites(int TVItemID);
        Task<ActionResult<WebLabSheets>> WebLabSheets(int TVItemID);
        Task<ActionResult<WebMikeScenarios>> WebMikeScenarios(int TVItemID);
        Task<ActionResult<WebMonitoringOtherStatsCountry>> WebMonitoringOtherStatsCountry(int TVItemID);
        Task<ActionResult<WebMonitoringRoutineStatsCountry>> WebMonitoringRoutineStatsCountry(int TVItemID);
        Task<ActionResult<WebMonitoringOtherStatsProvince>> WebMonitoringOtherStatsProvince(int TVItemID);
        Task<ActionResult<WebMonitoringRoutineStatsProvince>> WebMonitoringRoutineStatsProvince(int TVItemID);
        Task<ActionResult<WebMunicipality>> WebMunicipality(int TVItemID);
        Task<ActionResult<WebMWQMRuns>> WebMWQMRuns(int TVItemID);
        Task<ActionResult<WebMWQMSamples>> WebMWQMSamples1980_2020(int TVItemID);
        Task<ActionResult<WebMWQMSamples>> WebMWQMSamples2021_2060(int TVItemID);
        Task<ActionResult<WebMWQMSites>> WebMWQMSites(int TVItemID);
        Task<ActionResult<WebPolSourceSites>> WebPolSourceSites(int TVItemID);
        Task<ActionResult<WebProvince>> WebProvince(int TVItemID);
        Task<ActionResult<WebRoot>> WebRoot();
        Task<ActionResult<WebAllSearch>> WebAllSearch();
        Task<ActionResult<WebSector>> WebSector(int TVItemID);
        Task<ActionResult<WebSubsector>> WebSubsector(int TVItemID);
        Task<ActionResult<WebTideSites>> WebTideSites(int TVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class ReadController : ControllerBase, IReadController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private IReadGzFileService ReadGzFileService { get; }
        #endregion Properties

        #region Constructors
        public ReadController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
            IReadGzFileService ReadGzFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.ReadGzFileService = ReadGzFileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("WebAllAddresses")]
        [HttpGet]
        public async Task<ActionResult<WebAllAddresses>> WebAllAddresses()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses);
        }
        [Route("WebAllContacts")]
        [HttpGet]
        public async Task<ActionResult<WebAllContacts>> WebAllContacts()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllContacts>(WebTypeEnum.WebAllContacts);
        }
        [Route("WebAllCountries")]
        [HttpGet]
        public async Task<ActionResult<WebAllCountries>> WebAllCountries()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllCountries>(WebTypeEnum.WebAllCountries);
        }
        [Route("WebAllEmails")]
        [HttpGet]
        public async Task<ActionResult<WebAllEmails>> WebAllEmails()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllEmails>(WebTypeEnum.WebAllEmails);
        }
        [Route("WebAllHelpDocs")]
        [HttpGet]
        public async Task<ActionResult<WebAllHelpDocs>> WebAllHelpDocs()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs);
        }
        [Route("WebAllMunicipalities")]
        [HttpGet]
        public async Task<ActionResult<WebAllMunicipalities>> WebAllMunicipalities()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities);
        }
        [Route("WebAllMWQMLookupMPNs")]
        [HttpGet]
        public async Task<ActionResult<WebAllMWQMLookupMPNs>> WebAllMWQMLookupMPNs()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs);
        }
        [Route("WebAllPolSourceGroupings")]
        [HttpGet]
        public async Task<ActionResult<WebAllPolSourceGroupings>> WebAllPolSourceGroupings()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllPolSourceGroupings>(WebTypeEnum.WebAllPolSourceGroupings);
        }
        [Route("WebAllPolSourceSiteEffectTerms")]
        [HttpGet]
        public async Task<ActionResult<WebAllPolSourceSiteEffectTerms>> WebAllPolSourceSiteEffectTerms()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllPolSourceSiteEffectTerms>(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
        }
        [Route("WebAllProvinces")]
        [HttpGet]
        public async Task<ActionResult<WebAllProvinces>> WebAllProvinces()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces);
        }
        [Route("WebAllReportTypes")]
        [HttpGet]
        public async Task<ActionResult<WebAllReportTypes>> WebAllReportTypes()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllReportTypes>(WebTypeEnum.WebAllReportTypes);
        }
        [Route("WebAllTels")]
        [HttpGet]
        public async Task<ActionResult<WebAllTels>> WebAllTels()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllTels>(WebTypeEnum.WebAllTels);
        }
        [Route("WebAllTideLocations")]
        [HttpGet]
        public async Task<ActionResult<WebAllTideLocations>> WebAllTideLocations()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllTideLocations>(WebTypeEnum.WebAllTideLocations);
        }
        [Route("WebArea/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebArea>> WebArea(int TVItemID)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);
        }
        [Route("WebClimateSites/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebClimateSites>> WebClimateSites(int TVItemID)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);
        }
        [Route("WebCountry/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebCountry>> WebCountry(int TVItemID)
        {
            // TVItemID = CountryTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);
        }
        [Route("WebDrogueRuns/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebDrogueRuns>> WebDrogueRuns(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebDrogueRuns>(WebTypeEnum.WebDrogueRuns, TVItemID);
        }
        [Route("WebHydrometricSites/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHydrometricSites>> WebHydrometricSites(int TVItemID)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);
        }
        [Route("WebLabSheets/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebLabSheets>> WebLabSheets(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebLabSheets>(WebTypeEnum.WebLabSheets, TVItemID);
        }
        [Route("WebMikeScenarios/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMikeScenarios>> WebMikeScenarios(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);
        }
        [Route("WebMonitoringOtherStatsCountry/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMonitoringOtherStatsCountry>> WebMonitoringOtherStatsCountry(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMonitoringOtherStatsCountry>(WebTypeEnum.WebMonitoringOtherStatsCountry, TVItemID);
        }
        [Route("WebMonitoringRoutineStatsCountry/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMonitoringRoutineStatsCountry>> WebMonitoringRoutineStatsCountry(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMonitoringRoutineStatsCountry>(WebTypeEnum.WebMonitoringRoutineStatsCountry, TVItemID);
        }
        [Route("WebMonitoringOtherStatsProvince/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMonitoringOtherStatsProvince>> WebMonitoringOtherStatsProvince(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMonitoringOtherStatsProvince>(WebTypeEnum.WebMonitoringOtherStatsProvince, TVItemID);
        }
        [Route("WebMonitoringRoutineStatsProvince/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMonitoringRoutineStatsProvince>> WebMonitoringRoutineStatsProvince(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMonitoringRoutineStatsProvince>(WebTypeEnum.WebMonitoringRoutineStatsProvince, TVItemID);
        }
        [Route("WebMunicipality/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMunicipality>> WebMunicipality(int TVItemID)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);
        }
        [Route("WebMWQMRuns/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMRuns>> WebMWQMRuns(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);
        }
        [Route("WebMWQMSamples1980_2020/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSamples>> WebMWQMSamples1980_2020(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMSamples>(WebTypeEnum.WebMWQMSamples1980_2020, TVItemID);
        }
        [Route("WebMWQMSamples2021_2060/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSamples>> WebMWQMSamples2021_2060(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMSamples>(WebTypeEnum.WebMWQMSamples2021_2060, TVItemID);
        }
        [Route("WebMWQMSites/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSites>> WebMWQMSites(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);
        }
        [Route("WebPolSourceSites/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceSites>> WebPolSourceSites(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);
        }
        [Route("WebProvince/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebProvince>> WebProvince(int TVItemID)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);
        }
        [Route("WebRoot")]
        [HttpGet]
        public async Task<ActionResult<WebRoot>> WebRoot()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebRoot>(WebTypeEnum.WebRoot);
        }
        [Route("WebAllSearch")]
        [HttpGet]
        public async Task<ActionResult<WebAllSearch>> WebAllSearch()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllSearch>(WebTypeEnum.WebAllSearch);
        }
        [Route("WebSector/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSector>> WebSector(int TVItemID)
        {
            // TVItemID = SectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);
        }
        [Route("WebSubsector/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSubsector>> WebSubsector(int TVItemID)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);
        }
        [Route("WebTideSites/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<WebTideSites>> WebTideSites(int TVItemID)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPLocalLoggedInService.SetLoggedInContactInfo();

            return await ReadGzFileService.ReadJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
