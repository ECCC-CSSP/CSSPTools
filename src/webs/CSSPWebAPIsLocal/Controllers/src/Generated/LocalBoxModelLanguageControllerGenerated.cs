/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsLocalController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBLocalModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILocalBoxModelLanguageController
    {
        Task<ActionResult<List<LocalBoxModelLanguage>>> Get();
        Task<ActionResult<LocalBoxModelLanguage>> Get(int LocalBoxModelLanguageID);
        Task<ActionResult<LocalBoxModelLanguage>> Post(LocalBoxModelLanguage LocalBoxModelLanguage);
        Task<ActionResult<LocalBoxModelLanguage>> Put(LocalBoxModelLanguage LocalBoxModelLanguage);
        Task<ActionResult<bool>> Delete(int LocalBoxModelLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalBoxModelLanguageController : ControllerBase, ILocalBoxModelLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalBoxModelLanguageDBService LocalBoxModelLanguageDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalBoxModelLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalBoxModelLanguageDBService LocalBoxModelLanguageDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalBoxModelLanguageDBService = LocalBoxModelLanguageDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalBoxModelLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalBoxModelLanguageDBService.GetLocalBoxModelLanguageList();
        }
        [HttpGet("{LocalBoxModelLanguageID}")]
        public async Task<ActionResult<LocalBoxModelLanguage>> Get(int BoxModelLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalBoxModelLanguageDBService.GetLocalBoxModelLanguageWithBoxModelLanguageID(BoxModelLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalBoxModelLanguage>> Post(LocalBoxModelLanguage LocalBoxModelLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalBoxModelLanguageDBService.Post(LocalBoxModelLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<LocalBoxModelLanguage>> Put(LocalBoxModelLanguage LocalBoxModelLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalBoxModelLanguageDBService.Put(LocalBoxModelLanguage);
        }
        [HttpDelete("{LocalBoxModelLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int LocalBoxModelLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalBoxModelLanguageDBService.Delete(LocalBoxModelLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}