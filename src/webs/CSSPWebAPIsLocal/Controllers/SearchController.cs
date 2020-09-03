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
using CSSPCultureServices.Resources;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ISearchController
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    //[Authorize]
    public partial class SearchController : ControllerBase, ISearchController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPDBSearchService CSSPDBSearchService { get; }
        #endregion Properties

        #region Constructors
        public SearchController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ICSSPDBSearchService CSSPDBSearchService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.CSSPDBSearchService = CSSPDBSearchService;
        }
        #endregion Constructors

        #region Functions public
        [Route("{SearchTerm}/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, $"Search/{ SearchTerm }/{ TVItemID }")));
            }

            return await CSSPDBSearchService.Search(SearchTerm, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
