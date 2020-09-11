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
    public partial interface IInfrastructureLanguageController
    {
        Task<ActionResult<List<InfrastructureLanguage>>> Get();
        Task<ActionResult<InfrastructureLanguage>> Get(int InfrastructureLanguageID);
        Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage InfrastructureLanguage);
        Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage InfrastructureLanguage);
        Task<ActionResult<bool>> Delete(int InfrastructureLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class InfrastructureLanguageController : ControllerBase, IInfrastructureLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IInfrastructureLanguageDBLocalService InfrastructureLanguageDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IInfrastructureLanguageDBLocalService InfrastructureLanguageDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.InfrastructureLanguageDBLocalService = InfrastructureLanguageDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<InfrastructureLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureLanguageDBLocalService.GetInfrastructureLanguageList();
        }
        [HttpGet("{InfrastructureLanguageID}")]
        public async Task<ActionResult<InfrastructureLanguage>> Get(int InfrastructureLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureLanguageDBLocalService.GetInfrastructureLanguageWithInfrastructureLanguageID(InfrastructureLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<InfrastructureLanguage>> Post(InfrastructureLanguage InfrastructureLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureLanguageDBLocalService.Post(InfrastructureLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<InfrastructureLanguage>> Put(InfrastructureLanguage InfrastructureLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureLanguageDBLocalService.Put(InfrastructureLanguage);
        }
        [HttpDelete("{InfrastructureLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int InfrastructureLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await InfrastructureLanguageDBLocalService.Delete(InfrastructureLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
