/* Manually edited
 *
 */

using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVItemController
    {
        Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day);
    }

    public partial class TVItemController : ControllerBase, ITVItemController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Route("GetTVItemStartDateList/{Year}/{Month}/{Day}")]
        [HttpGet]
        public async Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await TVItemDBService.GetTVItemStartDateList(Year, Month, Day);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
