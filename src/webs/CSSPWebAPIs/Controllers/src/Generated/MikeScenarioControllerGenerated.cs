/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IMikeScenarioController
    {
        Task<ActionResult<List<MikeScenario>>> Get();
        Task<ActionResult<MikeScenario>> Get(int MikeScenarioID);
        Task<ActionResult<MikeScenario>> Post(MikeScenario MikeScenario);
        Task<ActionResult<MikeScenario>> Put(MikeScenario MikeScenario);
        Task<ActionResult<bool>> Delete(int MikeScenarioID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeScenarioController : ControllerBase, IMikeScenarioController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeScenarioService MikeScenarioService { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMikeScenarioService MikeScenarioService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MikeScenarioService = MikeScenarioService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeScenario>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.GetMikeScenarioList();
        }
        [HttpGet("{MikeScenarioID}")]
        public async Task<ActionResult<MikeScenario>> Get(int MikeScenarioID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.GetMikeScenarioWithMikeScenarioID(MikeScenarioID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeScenario>> Post(MikeScenario MikeScenario)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Post(MikeScenario);
        }
        [HttpPut]
        public async Task<ActionResult<MikeScenario>> Put(MikeScenario MikeScenario)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Put(MikeScenario);
        }
        [HttpDelete("{MikeScenarioID}")]
        public async Task<ActionResult<bool>> Delete(int MikeScenarioID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Delete(MikeScenarioID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
