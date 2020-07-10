/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
    public partial interface ITVItemUserAuthorizationController
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> Get();
        Task<ActionResult<TVItemUserAuthorization>> Get(int TVItemUserAuthorizationID);
        Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization TVItemUserAuthorization);
        Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization TVItemUserAuthorization);
        Task<ActionResult<bool>> Delete(int TVItemUserAuthorizationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVItemUserAuthorizationService TVItemUserAuthorizationService { get; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationController(ICultureService CultureService, ILoggedInService LoggedInService, ITVItemUserAuthorizationService TVItemUserAuthorizationService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.TVItemUserAuthorizationService = TVItemUserAuthorizationService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemUserAuthorization>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationService.GetTVItemUserAuthorizationList();
        }
        [HttpGet("{TVItemUserAuthorizationID}")]
        public async Task<ActionResult<TVItemUserAuthorization>> Get(int TVItemUserAuthorizationID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(TVItemUserAuthorizationID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemUserAuthorization>> Post(TVItemUserAuthorization TVItemUserAuthorization)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationService.Post(TVItemUserAuthorization);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemUserAuthorization>> Put(TVItemUserAuthorization TVItemUserAuthorization)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationService.Put(TVItemUserAuthorization);
        }
        [HttpDelete("{TVItemUserAuthorizationID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemUserAuthorizationID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationService.Delete(TVItemUserAuthorizationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
