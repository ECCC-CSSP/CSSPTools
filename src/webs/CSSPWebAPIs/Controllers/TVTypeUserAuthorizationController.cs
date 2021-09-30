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
    public partial interface ITVTypeUserAuthorizationController
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    //[Authorize]
    public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService { get; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.TVTypeUserAuthorizationDBService = TVTypeUserAuthorizationDBService;
        }
        #endregion Constructors

        #region Functions public
        [Route("GetWithContactTVItemID/{ContactTVItemID}")]
        [HttpGet]
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationWithContactTVItemID(ContactTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
