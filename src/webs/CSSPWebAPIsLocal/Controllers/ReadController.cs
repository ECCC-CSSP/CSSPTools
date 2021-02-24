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
using LoggedInServices;
using WebAppLoadedServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface IReadController
    {
        Task<ActionResult<WebArea>> WebArea(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebClimateDataValue>> WebClimateDataValue(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebClimateSite>> WebClimateSite(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebContact>> WebContact(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebCountry>> WebCountry(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebDrogueRun>> WebDrogueRun(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHelpDoc>> WebHelpDoc(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHydrometricDataValue>> WebHydrometricDataValue(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHydrometricSite>> WebHydrometricSite(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMikeScenario>> WebMikeScenario(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMunicipalities>> WebMunicipalities(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMunicipality>> WebMunicipality(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMLookupMPN>> WebMWQMLookupMPN(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMRun>> WebMWQMRun(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMSample>> WebMWQMSample(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMSite>> WebMWQMSite(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebPolSourceGrouping>> WebPolSourceGrouping(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebPolSourceSite>> WebPolSourceSite(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebPolSourceSiteEffectTerm>> WebPolSourceSiteEffectTerm(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebProvince>> WebProvince(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebReportType>> WebReportType(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebRoot>> WebRoot(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSamplingPlan>> WebSamplingPlan(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSector>> WebSector(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSubsector>> WebSubsector(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebTideLocation>> WebTideLocation(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebAllTVItem>> WebAllTVItem(int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebAllTVItemLanguage>> WebAllTVItemLanguage(int TVItemID, WebTypeYearEnum WebTypeYear);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class ReadController : ControllerBase, IReadController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IReadGzFileService ReadGzFileService { get; }
        #endregion Properties

        #region Constructors
        public ReadController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IReadGzFileService ReadGzFileService, IWebAppLoadedService WebAppLoadedService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ReadGzFileService = ReadGzFileService;

        }
        #endregion Constructors

        #region Functions public
        [Route("WebArea/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebArea>> WebArea(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebArea>(WebTypeEnum.WebArea, TVItemID, WebTypeYear);
        }
        [Route("WebClimateDataValue/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebClimateDataValue>> WebClimateDataValue(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ClimateSiteTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebClimateDataValue>(WebTypeEnum.WebClimateDataValue, TVItemID, WebTypeYear);
        }
        [Route("WebClimateSite/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebClimateSite>> WebClimateSite(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, TVItemID, WebTypeYear);
        }
        [Route("WebContact/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebContact>> WebContact(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebContact>(WebTypeEnum.WebContact, TVItemID, WebTypeYear);
        }
        [Route("WebCountry/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebCountry>> WebCountry(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = CountryTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID, WebTypeYear);
        }
        [Route("WebDrogueRun/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebDrogueRun>> WebDrogueRun(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebDrogueRun>(WebTypeEnum.WebDrogueRun, TVItemID, WebTypeYear);
        }
        [Route("WebHelpDoc/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHelpDoc>> WebHelpDoc(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebHelpDoc>(WebTypeEnum.WebHelpDoc, TVItemID, WebTypeYear);
        }
        [Route("WebHydrometricDataValue/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHydrometricDataValue>> WebHydrometricDataValue(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = HydrometricSiteTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(WebTypeEnum.WebHydrometricDataValue, TVItemID, WebTypeYear);
        }
        [Route("WebHydrometricSite/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHydrometricSite>> WebHydrometricSite(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, TVItemID, WebTypeYear);
        }
        [Route("WebMikeScenario/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMikeScenario>> WebMikeScenario(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = MikeScenarioTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, TVItemID, WebTypeYear);
        }
        [Route("WebMunicipalities/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMunicipalities>> WebMunicipalities(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, TVItemID, WebTypeYear);
        }
        [Route("WebMunicipality/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMunicipality>> WebMunicipality(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMLookupMPN/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMLookupMPN>> WebMWQMLookupMPN(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMLookupMPN>(WebTypeEnum.WebMWQMLookupMPN, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMRun/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMRun>> WebMWQMRun(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMRun>(WebTypeEnum.WebMWQMRun, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMSample/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSample>> WebMWQMSample(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMSample>(WebTypeEnum.WebMWQMSample, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMSite/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSite>> WebMWQMSite(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, TVItemID, WebTypeYear);
        }
        [Route("WebPolSourceGrouping/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceGrouping>> WebPolSourceGrouping(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebPolSourceGrouping>(WebTypeEnum.WebPolSourceGrouping, TVItemID, WebTypeYear);
        }
        [Route("WebPolSourceSite/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceSite>> WebPolSourceSite(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, TVItemID, WebTypeYear);
        }
        [Route("WebPolSourceSiteEffectTerm/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceSiteEffectTerm>> WebPolSourceSiteEffectTerm(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebPolSourceSiteEffectTerm>(WebTypeEnum.WebPolSourceSiteEffectTerm, TVItemID, WebTypeYear);
        }
        [Route("WebProvince/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebProvince>> WebProvince(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID, WebTypeYear);
        }
        [Route("WebReportType/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebReportType>> WebReportType(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebReportType>(WebTypeEnum.WebReportType, TVItemID, WebTypeYear);
        }
        [Route("WebRoot/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebRoot>> WebRoot(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebRoot>(WebTypeEnum.WebRoot, TVItemID, WebTypeYear);
        }
        [Route("WebSamplingPlan/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSamplingPlan>> WebSamplingPlan(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SamplingPlanID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebSamplingPlan>(WebTypeEnum.WebSamplingPlan, TVItemID, WebTypeYear);
        }
        [Route("WebSector/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSector>> WebSector(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebSector>(WebTypeEnum.WebSector, TVItemID, WebTypeYear);
        }
        [Route("WebSubsector/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSubsector>> WebSubsector(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID, WebTypeYear);
        }
        [Route("WebTideLocation/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebTideLocation>> WebTideLocation(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebTideLocation>(WebTypeEnum.WebTideLocation, TVItemID, WebTypeYear);
        }
        [Route("WebAllTVItem/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebAllTVItem>> WebAllTVItem(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllTVItem>(WebTypeEnum.WebAllTVItem, TVItemID, WebTypeYear);
        }
        [Route("WebAllTVItemLanguage/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebAllTVItemLanguage>> WebAllTVItemLanguage(int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await ReadGzFileService.ReadJSON<WebAllTVItemLanguage>(WebTypeEnum.WebAllTVItemLanguage, TVItemID, WebTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
