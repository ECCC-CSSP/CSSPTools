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
    public partial interface ILocalEmailDistributionListContactLanguageController
    {
        Task<ActionResult<List<LocalEmailDistributionListContactLanguage>>> Get();
        Task<ActionResult<LocalEmailDistributionListContactLanguage>> Get(int LocalEmailDistributionListContactLanguageID);
        Task<ActionResult<LocalEmailDistributionListContactLanguage>> Post(LocalEmailDistributionListContactLanguage LocalEmailDistributionListContactLanguage);
        Task<ActionResult<LocalEmailDistributionListContactLanguage>> Put(LocalEmailDistributionListContactLanguage LocalEmailDistributionListContactLanguage);
        Task<ActionResult<bool>> Delete(int LocalEmailDistributionListContactLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalEmailDistributionListContactLanguageController : ControllerBase, ILocalEmailDistributionListContactLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalEmailDistributionListContactLanguageDBService LocalEmailDistributionListContactLanguageDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalEmailDistributionListContactLanguageController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalEmailDistributionListContactLanguageDBService LocalEmailDistributionListContactLanguageDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalEmailDistributionListContactLanguageDBService = LocalEmailDistributionListContactLanguageDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalEmailDistributionListContactLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalEmailDistributionListContactLanguageDBService.GetLocalEmailDistributionListContactLanguageList();
        }
        [HttpGet("{LocalEmailDistributionListContactLanguageID}")]
        public async Task<ActionResult<LocalEmailDistributionListContactLanguage>> Get(int EmailDistributionListContactLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalEmailDistributionListContactLanguageDBService.GetLocalEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(EmailDistributionListContactLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalEmailDistributionListContactLanguage>> Post(LocalEmailDistributionListContactLanguage LocalEmailDistributionListContactLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalEmailDistributionListContactLanguageDBService.Post(LocalEmailDistributionListContactLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<LocalEmailDistributionListContactLanguage>> Put(LocalEmailDistributionListContactLanguage LocalEmailDistributionListContactLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalEmailDistributionListContactLanguageDBService.Put(LocalEmailDistributionListContactLanguage);
        }
        [HttpDelete("{LocalEmailDistributionListContactLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int LocalEmailDistributionListContactLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalEmailDistributionListContactLanguageDBService.Delete(LocalEmailDistributionListContactLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
