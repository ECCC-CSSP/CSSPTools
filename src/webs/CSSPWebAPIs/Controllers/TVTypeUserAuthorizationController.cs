/*  
 * Manually edited
 */

using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVTypeUserAuthorizationController
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID);
    }

    public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Route("GetWithContactTVItemID/{ContactTVItemID}")]
        [HttpGet]
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationWithContactTVItemID(ContactTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
