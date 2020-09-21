/*
 * Manually edited
 * 
 */
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSSPEnums;
using CSSPCultureServices.Resources;
using LocalServices;
using CSSPDBSearchServices;
using Microsoft.Extensions.Configuration;

namespace CSSPWebAPIsLocal.Controllers
{
    public partial interface ISearchController
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID);
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
        private ILocalService LocalService { get; }
        private ICSSPDBSearchService CSSPDBSearchService { get; }
        #endregion Properties

        #region Constructors
        public SearchController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, ICSSPDBSearchService CSSPDBSearchService)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.CSSPDBSearchService = CSSPDBSearchService;
        }
        #endregion Constructors

        #region Functions public
        [Route("{SearchTerm}/{TVItemID:int}")]
        [HttpGet]
        public async Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await CSSPDBSearchService.Search(SearchTerm, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
