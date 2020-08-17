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
    public partial interface ICreateGzFileController
    {
        Task<ActionResult<bool>> CreateGzFile(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class CreateGzFileController : ControllerBase, ICreateGzFileController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICreateGzFileService CSSPWebService { get; }
        #endregion Properties

        #region Constructors
        public CreateGzFileController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ICreateGzFileService CSSPWebService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.CSSPWebService = CSSPWebService;
        }
        #endregion Constructors

        #region Functions public
        [Route("{WebType:int}/{TVItemID:int}/{WebTypeYear:int}")]
        [HttpGet]
        public async Task<ActionResult<bool>> CreateGzFile(WebTypeEnum WebType, int TVItemID, WebTypeYearEnum WebTypeYear)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await CSSPWebService.CreateGzFile(WebType, TVItemID, WebTypeYear);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
