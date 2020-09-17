/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ITVItemLanguageController
    {
        Task<ActionResult<List<TVItemLanguage>>> Get();
        Task<ActionResult<TVItemLanguage>> Get(int TVItemLanguageID);
        Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage TVItemLanguage);
        Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage TVItemLanguage);
        Task<ActionResult<bool>> Delete(int TVItemLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TVItemLanguageController : ControllerBase, ITVItemLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITVItemLanguageDBLocalService TVItemLanguageDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITVItemLanguageDBLocalService TVItemLanguageDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TVItemLanguageDBLocalService = TVItemLanguageDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVItemLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLanguageDBLocalService.GetTVItemLanguageList();
        }
        [HttpGet("{TVItemLanguageID}")]
        public async Task<ActionResult<TVItemLanguage>> Get(int TVItemLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLanguageDBLocalService.GetTVItemLanguageWithTVItemLanguageID(TVItemLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<TVItemLanguage>> Post(TVItemLanguage TVItemLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLanguageDBLocalService.Post(TVItemLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<TVItemLanguage>> Put(TVItemLanguage TVItemLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLanguageDBLocalService.Put(TVItemLanguage);
        }
        [HttpDelete("{TVItemLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int TVItemLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVItemLanguageDBLocalService.Delete(TVItemLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}