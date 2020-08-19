/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IReadController
    {
        Task<ActionResult<WebRoot>> WebRoot(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ReadController : ControllerBase, IReadController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IGzFileService GzFileService { get; }
        #endregion Properties

        #region Constructors
        public ReadController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IGzFileService GzFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.GzFileService = GzFileService;
        }
        #endregion Constructors

        #region Functions public
        [Route("WebRoot/{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<WebRoot>> WebRoot(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await GzFileService.ReadJSON<WebRoot>(WebType, TVItemID, WebTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
