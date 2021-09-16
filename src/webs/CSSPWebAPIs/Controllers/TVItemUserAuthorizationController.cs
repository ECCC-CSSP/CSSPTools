/*
 * Manually edited
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
    public partial interface ITVItemUserAuthorizationController
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    //[Authorize]
    public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService { get; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.TVItemUserAuthorizationDBService = TVItemUserAuthorizationDBService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetWithContactTVItemID/{ContactTVItemID}")]
        [HttpGet]
        public async Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationDBService.GetTVItemUserAuthorizationWithContactTVItemID(ContactTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
