/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPDBSearchServices;
using Microsoft.Extensions.Configuration;
using LoggedInServices;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ISearchController
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID);
        //Task<ActionResult<List<TVItemLanguage>>> SearchByTVItemID(string SearchTerm, int TVItemID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class SearchController : ControllerBase, ISearchController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPDBSearchService CSSPDBSearchService { get; }
        #endregion Properties

        #region Constructors
        public SearchController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ICSSPDBSearchService CSSPDBSearchService)
        {
            this.Configuration = Configuration;
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
            await LoggedInService.SetLoggedInLocalContactInfo();

            return await CSSPDBSearchService.Search(SearchTerm, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
