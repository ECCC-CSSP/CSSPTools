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
        [HttpGet("GetWeb10YearOfSample1980_1989FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample1980_1989FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample1980_1989FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample1990_1999FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample1990_1999FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample1990_1999FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2000_2009FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2000_2009FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2000_2009FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2010_2019FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2010_2019FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2010_2019FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2020_2029FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2020_2029FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2020_2029FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2030_2039FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2030_2039FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2030_2039FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2040_2049FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2040_2049FromSubsector(int TVItemID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWeb10YearOfSample2040_2049FromSubsector(TVItemID);
        }
        [HttpGet("GetWeb10YearOfSample2050_2059FromSubsector/{TVItemID:int}")]
        public async Task<ActionResult<WebSample>> GetWeb10YearOfSample2050_2059FromSubsector(int TVItemID)
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
