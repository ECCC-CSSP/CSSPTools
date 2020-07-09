/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPServices;
using CSSPWebModels;
using CSSPWebServices;
using CSSPWebServices.Services;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebLocalAPIs.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class WebController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IWebService WebService { get; }
        #endregion Properties

        #region Constructors
        public WebController(ICultureService CultureService, ILoggedInService LoggedInService, IWebService WebService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.WebService = WebService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet("GetWebRoot")]
        public async Task<ActionResult<WebRoot>> GetWebRoot()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebRoot();
        }
        [HttpGet("GetWebCountry/{TVItemID:int}")]
        public async Task<ActionResult<WebCountry>> GetWebCountry(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebCountry(TVItemID);
        }
        [HttpGet("GetWebProvince/{TVItemID:int}")]
        public async Task<ActionResult<WebProvince>> GetWebProvince(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebProvince(TVItemID);
        }
        [HttpGet("GetWebArea/{TVItemID:int}")]
        public async Task<ActionResult<WebArea>> GetWebArea(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebArea(TVItemID);
        }
        [HttpGet("GetWebSector/{TVItemID:int}")]
        public async Task<ActionResult<WebSector>> GetWebSector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSector(TVItemID);
        }
        [HttpGet("GetWebSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSubsector>> GetWebSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample1980_1989FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample1980_1989FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample1980_1989FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample1990_1999FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample1990_1999FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample1990_1999FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2000_2009FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2000_2009FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2000_2009FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2010_2019FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2010_2019FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2010_2019FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2020_2029FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2020_2029FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2020_2029FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2030_2039FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2030_2039FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2030_2039FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2040_2049FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2040_2049FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2040_2049FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2050_2059FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2050_2059FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2050_2059FromSubsector(TVItemID);
        }
        [HttpGet("GetWebSamplingPlan/{SamplingPlanID:int}")]
        public async Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int SamplingPlanID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSamplingPlan(SamplingPlanID);
        }
        [HttpGet("GetWebMunicipality/{TVItemID:int}")]
        public async Task<ActionResult<WebMunicipality>> GetWebMunicipality(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMunicipality(TVItemID);
        }
        [HttpGet("GetWebMWQMRun/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMRun>> GetWebMWQMRun(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMWQMRun(TVItemID);
        }
        [HttpGet("GetWebMWQMSite/{TVItemID:int}")]
        public async Task<ActionResult<WebMWQMSite>> GetWebMWQMSite(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMWQMSite(TVItemID);
        }
        [HttpGet("GetWebContact")]
        public async Task<ActionResult<WebContact>> GetWebContact()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebContact();
        }
        [HttpGet("GetWebClimateSite/{TVItemID:int}")]
        public async Task<ActionResult<WebClimateSite>> GetWebClimateSite(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebClimateSite(TVItemID);
        }
        [HttpGet("GetWebHydrometricSite/{TVItemID:int}")]
        public async Task<ActionResult<WebHydrometricSite>> GetWebHydrometricSite(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebHydrometricSite(TVItemID);
        }
        [HttpGet("GetWebDrogueRun/{TVItemID:int}")]
        public async Task<ActionResult<WebDrogueRun>> GetWebDrogueRun(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebDrogueRun(TVItemID);
        }
        [HttpGet("GetWebMWQMLookupMPN")]
        public async Task<ActionResult<WebMWQMLookupMPN>> GetWebMWQMLookupMPN()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMWQMLookupMPN();
        }
        [HttpGet("GetWebMikeScenario/{TVItemID:int}")]
        public async Task<ActionResult<WebMikeScenario>> GetWebMikeScenario(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMikeScenario(TVItemID);
        }
        [HttpGet("GetWebClimateDataValue/{TVItemID:int}")]
        public async Task<ActionResult<WebClimateDataValue>> GetWebClimateDataValue(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebClimateDataValue(TVItemID);
        }
        [HttpGet("GetWebHydrometricDataValue/{TVItemID:int}")]
        public async Task<ActionResult<WebHydrometricDataValue>> GetWebHydrometricDataValue(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebHydrometricDataValue(TVItemID);
        }
        [HttpGet("GetWebHelpDoc")]
        public async Task<ActionResult<WebHelpDoc>> GetWebHelpDoc()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebHelpDoc();
        }
        [HttpGet("GetWebTideLocation")]
        public async Task<ActionResult<WebTideLocation>> GetWebTideLocation()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebTideLocation();
        }
        [HttpGet("GetWebPolSourceSite/{TVItemID:int}")]
        public async Task<ActionResult<WebPolSourceSite>> GetWebPolSourceSite(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebPolSourceSite(TVItemID);
        }
        [HttpGet("GetWebPolSourceGrouping")]
        public async Task<ActionResult<WebPolSourceGrouping>> GetWebPolSourceGrouping()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebPolSourceGrouping();
        }
        [HttpGet("GetWebReportType")]
        public async Task<ActionResult<WebReportType>> GetWebReportType()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebReportType();
        }
        [HttpGet("GetWebMunicipalities/{TVItemID:int}")]
        public async Task<ActionResult<WebMunicipalities>> GetWebMunicipalities(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebMunicipalities(TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
