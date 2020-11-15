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
    public partial interface ILocalInfrastructureLanguageController
    {
        Task<ActionResult<List<LocalInfrastructureLanguage>>> Get();
        Task<ActionResult<LocalInfrastructureLanguage>> Get(int LocalInfrastructureLanguageID);
        Task<ActionResult<LocalInfrastructureLanguage>> Post(LocalInfrastructureLanguage LocalInfrastructureLanguage);
        Task<ActionResult<LocalInfrastructureLanguage>> Put(LocalInfrastructureLanguage LocalInfrastructureLanguage);
        Task<ActionResult<bool>> Delete(int LocalInfrastructureLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalInfrastructureLanguageController : ControllerBase, ILocalInfrastructureLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalInfrastructureLanguageDBService LocalInfrastructureLanguageDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalInfrastructureLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalInfrastructureLanguageDBService LocalInfrastructureLanguageDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalInfrastructureLanguageDBService = LocalInfrastructureLanguageDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalInfrastructureLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalInfrastructureLanguageDBService.GetLocalInfrastructureLanguageList();
        }
        [HttpGet("{LocalInfrastructureLanguageID}")]
        public async Task<ActionResult<LocalInfrastructureLanguage>> Get(int InfrastructureLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalInfrastructureLanguageDBService.GetLocalInfrastructureLanguageWithInfrastructureLanguageID(InfrastructureLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalInfrastructureLanguage>> Post(LocalInfrastructureLanguage LocalInfrastructureLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalInfrastructureLanguageDBService.Post(LocalInfrastructureLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<LocalInfrastructureLanguage>> Put(LocalInfrastructureLanguage LocalInfrastructureLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalInfrastructureLanguageDBService.Put(LocalInfrastructureLanguage);
        }
        [HttpDelete("{LocalInfrastructureLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int LocalInfrastructureLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalInfrastructureLanguageDBService.Delete(LocalInfrastructureLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}