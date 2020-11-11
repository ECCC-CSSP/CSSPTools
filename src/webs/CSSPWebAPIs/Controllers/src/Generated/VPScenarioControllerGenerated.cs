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
    public partial interface IVPScenarioController
    {
        Task<ActionResult<List<VPScenario>>> Get();
        Task<ActionResult<VPScenario>> Get(int VPScenarioID);
        Task<ActionResult<VPScenario>> Post(VPScenario VPScenario);
        Task<ActionResult<VPScenario>> Put(VPScenario VPScenario);
        Task<ActionResult<bool>> Delete(int VPScenarioID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class VPScenarioController : ControllerBase, IVPScenarioController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IVPScenarioDBService VPScenarioDBService { get; }
        #endregion Properties

        #region Constructors
        public VPScenarioController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IVPScenarioDBService VPScenarioDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.VPScenarioDBService = VPScenarioDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<VPScenario>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioDBService.GetVPScenarioList();
        }
        [HttpGet("{VPScenarioID}")]
        public async Task<ActionResult<VPScenario>> Get(int VPScenarioID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioDBService.GetVPScenarioWithVPScenarioID(VPScenarioID);
        }
        [HttpPost]
        public async Task<ActionResult<VPScenario>> Post(VPScenario VPScenario)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioDBService.Post(VPScenario);
        }
        [HttpPut]
        public async Task<ActionResult<VPScenario>> Put(VPScenario VPScenario)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioDBService.Put(VPScenario);
        }
        [HttpDelete("{VPScenarioID}")]
        public async Task<ActionResult<bool>> Delete(int VPScenarioID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await VPScenarioDBService.Delete(VPScenarioID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
