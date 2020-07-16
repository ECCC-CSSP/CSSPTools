/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeScenarioService MikeScenarioService { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioController(ICultureService CultureService, ILoggedInService LoggedInService, IMikeScenarioService MikeScenarioService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.MikeScenarioService = MikeScenarioService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeScenario>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.GetMikeScenarioList();
        }
        [HttpGet("{MikeScenarioID}")]
        public async Task<ActionResult<MikeScenario>> Get(int MikeScenarioID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.GetMikeScenarioWithMikeScenarioID(MikeScenarioID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeScenario>> Post(MikeScenario MikeScenario)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Post(MikeScenario);
        }
        [HttpPut]
        public async Task<ActionResult<MikeScenario>> Put(MikeScenario MikeScenario)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Put(MikeScenario);
        }
        [HttpDelete("{MikeScenarioID}")]
        public async Task<ActionResult<bool>> Delete(int MikeScenarioID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioService.Delete(MikeScenarioID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
