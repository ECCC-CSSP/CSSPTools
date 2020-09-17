/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
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
    public partial interface ITVItemUserAuthorizationController
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemID(int ContactTVItemID);
    }

    public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Route("GetWithContactTVItemID")]
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