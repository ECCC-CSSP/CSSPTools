/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IReadController
    {
        Task<ActionResult<WebArea>> WebArea(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebClimateDataValue>> WebClimateDataValue(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebClimateSite>> WebClimateSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebContact>> WebContact(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebCountry>> WebCountry(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebDrogueRun>> WebDrogueRun(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHelpDoc>> WebHelpDoc(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHydrometricDataValue>> WebHydrometricDataValue(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebHydrometricSite>> WebHydrometricSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMikeScenario>> WebMikeScenario(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMunicipalities>> WebMunicipalities(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMunicipality>> WebMunicipality(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMLookupMPN>> WebMWQMLookupMPN(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMRun>> WebMWQMRun(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMSample>> WebMWQMSample(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebMWQMSite>> WebMWQMSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebPolSourceGrouping>> WebPolSourceGrouping(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebPolSourceSite>> WebPolSourceSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebProvince>> WebProvince(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebReportType>> WebReportType(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebRoot>> WebRoot(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSamplingPlan>> WebSamplingPlan(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSector>> WebSector(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebSubsector>> WebSubsector(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
        Task<ActionResult<WebTideLocation>> WebTideLocation(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
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
        public ReadController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IReadGzFileService ReadGzFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ReadGzFileService = ReadGzFileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("WebArea/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebArea>> WebArea(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = AreaTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebArea")));
            }

            return await ReadGzFileService.ReadJSON<WebArea>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebClimateDataValue/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebClimateDataValue>> WebClimateDataValue(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ClimateSiteTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebClimateDataValue")));
            }

            return await ReadGzFileService.ReadJSON<WebClimateDataValue>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebClimateSite/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebClimateSite>> WebClimateSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebClimateSite")));
            }

            return await ReadGzFileService.ReadJSON<WebClimateSite>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebContact/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebContact>> WebContact(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebContact")));
            }

            return await ReadGzFileService.ReadJSON<WebContact>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebCountry/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebCountry>> WebCountry(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = CountryTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebCountry")));
            }

            return await ReadGzFileService.ReadJSON<WebCountry>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebDrogueRun/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebDrogueRun>> WebDrogueRun(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebDrogueRun")));
            }

            return await ReadGzFileService.ReadJSON<WebDrogueRun>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebHelpDoc/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHelpDoc>> WebHelpDoc(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebHelpDoc")));
            }

            return await ReadGzFileService.ReadJSON<WebHelpDoc>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebHydrometricDataValue/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHydrometricDataValue>> WebHydrometricDataValue(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = HydrometricSiteTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebHydrometricDataValue")));
            }

            return await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebHydrometricSite/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebHydrometricSite>> WebHydrometricSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebHydrometricSite")));
            }

            return await ReadGzFileService.ReadJSON<WebHydrometricSite>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMikeScenario/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMikeScenario>> WebMikeScenario(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = MikeScenarioTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMikeScenario")));
            }

            return await ReadGzFileService.ReadJSON<WebMikeScenario>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMunicipalities/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMunicipalities>> WebMunicipalities(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMunicipalities")));
            }

            return await ReadGzFileService.ReadJSON<WebMunicipalities>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMunicipality/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMunicipality>> WebMunicipality(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = MunicipalityTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMunicipality")));
            }

            return await ReadGzFileService.ReadJSON<WebMunicipality>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMLookupMPN/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMLookupMPN>> WebMWQMLookupMPN(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMWQMLookupMPN")));
            }

            return await ReadGzFileService.ReadJSON<WebMWQMLookupMPN>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMRun/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMRun>> WebMWQMRun(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMWQMRun")));
            }

            return await ReadGzFileService.ReadJSON<WebMWQMRun>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMSample/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSample>> WebMWQMSample(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMWQMSample")));
            }

            return await ReadGzFileService.ReadJSON<WebMWQMSample>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebMWQMSite/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebMWQMSite>> WebMWQMSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebMWQMSite")));
            }

            return await ReadGzFileService.ReadJSON<WebMWQMSite>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebPolSourceGrouping/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceGrouping>> WebPolSourceGrouping(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebPolSourceGrouping")));
            }

            return await ReadGzFileService.ReadJSON<WebPolSourceGrouping>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebPolSourceSite/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebPolSourceSite>> WebPolSourceSite(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebPolSourceSite")));
            }

            return await ReadGzFileService.ReadJSON<WebPolSourceSite>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebProvince/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebProvince>> WebProvince(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = ProvinceTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebProvince")));
            }

            return await ReadGzFileService.ReadJSON<WebProvince>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebReportType/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebReportType>> WebReportType(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebReportType")));
            }

            return await ReadGzFileService.ReadJSON<WebReportType>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebRoot/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebRoot>> WebRoot(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebRoot")));
            }

            return await ReadGzFileService.ReadJSON<WebRoot>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebSamplingPlan/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSamplingPlan>> WebSamplingPlan(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SamplingPlanID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebSamplingPlan")));
            }

            return await ReadGzFileService.ReadJSON<WebSamplingPlan>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebSector/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSector>> WebSector(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebSector")));
            }

            return await ReadGzFileService.ReadJSON<WebSector>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebSubsector/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebSubsector>> WebSubsector(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = SubsectorTVItemID
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebSubsector")));
            }

            return await ReadGzFileService.ReadJSON<WebSubsector>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebTideLocation/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebTideLocation>> WebTideLocation(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebTideLocation")));
            }

            return await ReadGzFileService.ReadJSON<WebTideLocation>(WebType, TVItemID, WebTypeYear);
        }
        [Route("WebTVItem/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebTVItem>> WebTVItem(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            // TVItemID = 0 -- not used
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "Read/WebTVItem")));
            }

            return await ReadGzFileService.ReadJSON<WebTVItem>(WebType, TVItemID, WebTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
