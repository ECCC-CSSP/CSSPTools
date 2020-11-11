/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITideSiteDBService TideSiteDBService { get; }
        #endregion Properties

        #region Constructors
        public TideSiteController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITideSiteDBService TideSiteDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TideSiteDBService = TideSiteDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TideSite>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteDBService.GetTideSiteList();
        }
        [HttpGet("{TideSiteID}")]
        public async Task<ActionResult<TideSite>> Get(int TideSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteDBService.GetTideSiteWithTideSiteID(TideSiteID);
        }
        [HttpPost]
        public async Task<ActionResult<TideSite>> Post(TideSite TideSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteDBService.Post(TideSite);
        }
        [HttpPut]
        public async Task<ActionResult<TideSite>> Put(TideSite TideSite)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteDBService.Put(TideSite);
        }
        [HttpDelete("{TideSiteID}")]
        public async Task<ActionResult<bool>> Delete(int TideSiteID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TideSiteDBService.Delete(TideSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
