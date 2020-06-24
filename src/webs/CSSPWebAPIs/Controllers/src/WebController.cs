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
        [HttpGet("GetWebCountry")]
        public async Task<ActionResult<WebCountry>> GetWebCountry()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebCountry();
        }
        [HttpGet("GetWebArea")]
        public async Task<ActionResult<WebArea>> GetWebArea()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebArea();
        }
        [HttpGet("GetWebSector")]
        public async Task<ActionResult<WebSector>> GetWebSector()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSector();
        }
        [HttpGet("GetWebSubsector")]
        public async Task<ActionResult<WebSubsector>> GetWebSubsector()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await WebService.GetWebSubsector();
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
