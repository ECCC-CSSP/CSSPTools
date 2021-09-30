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
using CSSPServerLoggedInServices;

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
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService { get; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.TVItemUserAuthorizationDBService = TVItemUserAuthorizationDBService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetWithContactTVItemID/{ContactTVItemID}")]
        [HttpGet]
        public async Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemUserAuthorizationDBService.GetTVItemUserAuthorizationWithContactTVItemID(ContactTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
