/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPServices;
using CSSPWebModels;
using CSSPWebServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IWebController
    {
        Task<ActionResult<WebRoot>> GetWebRoot();
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class WebController : ControllerBase, IWebController
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
        [HttpGet("GetWeb10YearOfSampleStartingIn1980FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1980FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn1980FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn1990FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1990FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn1990FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2000FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2000FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2000FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2010FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2010FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2010FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2020FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2020FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2020FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2030FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2030FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2030FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2040FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2040FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2040FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSampleStartingIn2050FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2050FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSampleStartingIn2050FromSubsector(TVItemID);
        }
        [HttpGet("GetWebSamplingPlan/{SamplingPlanID:int}")]
        public async Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int SamplingPlanID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSamplingPlan(SamplingPlanID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
