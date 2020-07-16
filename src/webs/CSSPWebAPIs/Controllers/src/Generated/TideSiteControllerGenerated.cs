/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITideSiteController
    {
        Task<ActionResult<List<TideSite>>> Get();
        Task<ActionResult<TideSite>> Get(int TideSiteID);
        Task<ActionResult<TideSite>> Post(TideSite TideSite);
        Task<ActionResult<TideSite>> Put(TideSite TideSite);
        Task<ActionResult<bool>> Delete(int TideSiteID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TideSiteController : ControllerBase, ITideSiteController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITideSiteService TideSiteService { get; }
        #endregion Properties

        #region Constructors
        public TideSiteController(ICultureService CultureService, ILoggedInService LoggedInService, ITideSiteService TideSiteService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.TideSiteService = TideSiteService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideSite>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteService.GetTideSiteList();
        }
        [HttpGet("{TideSiteID}")]
        public async Task<ActionResult<TideSite>> Get(int TideSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteService.GetTideSiteWithTideSiteID(TideSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<TideSite>> Post(TideSite TideSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteService.Post(TideSite);
        }
        [HttpPut]
        public async Task<ActionResult<TideSite>> Put(TideSite TideSite)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteService.Put(TideSite);
        }
        [HttpDelete("{TideSiteID}")]
        public async Task<ActionResult<bool>> Delete(int TideSiteID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteService.Delete(TideSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
