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
    public partial interface ITVTypeUserAuthorizationController
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> Get();
        Task<ActionResult<TVTypeUserAuthorization>> Get(int TVTypeUserAuthorizationID);
        Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization TVTypeUserAuthorization);
        Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization TVTypeUserAuthorization);
        Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService { get; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TVTypeUserAuthorizationDBService = TVTypeUserAuthorizationDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationList();
        }
        [HttpGet("{TVTypeUserAuthorizationID}")]
        public async Task<ActionResult<TVTypeUserAuthorization>> Get(int TVTypeUserAuthorizationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(TVTypeUserAuthorizationID);
        }
        [HttpPost]
        public async Task<ActionResult<TVTypeUserAuthorization>> Post(TVTypeUserAuthorization TVTypeUserAuthorization)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.Post(TVTypeUserAuthorization);
        }
        [HttpPut]
        public async Task<ActionResult<TVTypeUserAuthorization>> Put(TVTypeUserAuthorization TVTypeUserAuthorization)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.Put(TVTypeUserAuthorization);
        }
        [HttpDelete("{TVTypeUserAuthorizationID}")]
        public async Task<ActionResult<bool>> Delete(int TVTypeUserAuthorizationID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.Delete(TVTypeUserAuthorizationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
