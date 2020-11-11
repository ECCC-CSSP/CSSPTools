/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IVPScenarioLanguageController
    {
        Task<ActionResult<List<VPScenarioLanguage>>> Get();
        Task<ActionResult<VPScenarioLanguage>> Get(int VPScenarioLanguageID);
        Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage VPScenarioLanguage);
        Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage VPScenarioLanguage);
        Task<ActionResult<bool>> Delete(int VPScenarioLanguageID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPScenarioLanguageController : ControllerBase, IVPScenarioLanguageController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IVPScenarioLanguageDBService VPScenarioLanguageDBService { get; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IVPScenarioLanguageDBService VPScenarioLanguageDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.VPScenarioLanguageDBService = VPScenarioLanguageDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPScenarioLanguage>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioLanguageDBService.GetVPScenarioLanguageList();
        }
        [HttpGet("{VPScenarioLanguageID}")]
        public async Task<ActionResult<VPScenarioLanguage>> Get(int VPScenarioLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioLanguageDBService.GetVPScenarioLanguageWithVPScenarioLanguageID(VPScenarioLanguageID);
        }
        [HttpPost]
        public async Task<ActionResult<VPScenarioLanguage>> Post(VPScenarioLanguage VPScenarioLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioLanguageDBService.Post(VPScenarioLanguage);
        }
        [HttpPut]
        public async Task<ActionResult<VPScenarioLanguage>> Put(VPScenarioLanguage VPScenarioLanguage)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioLanguageDBService.Put(VPScenarioLanguage);
        }
        [HttpDelete("{VPScenarioLanguageID}")]
        public async Task<ActionResult<bool>> Delete(int VPScenarioLanguageID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioLanguageDBService.Delete(VPScenarioLanguageID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
