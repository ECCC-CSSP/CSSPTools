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
    public partial interface ITVFileLanguageController
    {
        Task<ActionResult<List<TVFileLanguage>>> Get();
        Task<ActionResult<TVFileLanguage>> Get(int TVFileLanguageID);
        Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage TVFileLanguage);
        Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage TVFileLanguage);
        Task<ActionResult<bool>> Delete(int TVFileLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class TVFileLanguageController : ControllerBase, ITVFileLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ITVFileLanguageDBLocalService TVFileLanguageDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ITVFileLanguageDBLocalService TVFileLanguageDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.TVFileLanguageDBLocalService = TVFileLanguageDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<TVFileLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVFileLanguageDBLocalService.GetTVFileLanguageList();
        }
        [HttpGet("{TVFileLanguageID}")]
        public async Task<ActionResult<TVFileLanguage>> Get(int TVFileLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVFileLanguageDBLocalService.GetTVFileLanguageWithTVFileLanguageID(TVFileLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<TVFileLanguage>> Post(TVFileLanguage TVFileLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVFileLanguageDBLocalService.Post(TVFileLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<TVFileLanguage>> Put(TVFileLanguage TVFileLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVFileLanguageDBLocalService.Put(TVFileLanguage);
        }
        [HttpDelete("{TVFileLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int TVFileLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await TVFileLanguageDBLocalService.Delete(TVFileLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
