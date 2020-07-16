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
    public partial interface IMikeScenarioResultController
    {
        Task<ActionResult<List<MikeScenarioResult>>> Get();
        Task<ActionResult<MikeScenarioResult>> Get(int MikeScenarioResultID);
        Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult MikeScenarioResult);
        Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult MikeScenarioResult);
        Task<ActionResult<bool>> Delete(int MikeScenarioResultID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeScenarioResultController : ControllerBase, IMikeScenarioResultController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeScenarioResultService MikeScenarioResultService { get; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultController(ICultureService CultureService, ILoggedInService LoggedInService, IMikeScenarioResultService MikeScenarioResultService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.MikeScenarioResultService = MikeScenarioResultService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeScenarioResult>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioResultService.GetMikeScenarioResultList();
        }
        [HttpGet("{MikeScenarioResultID}")]
        public async Task<ActionResult<MikeScenarioResult>> Get(int MikeScenarioResultID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioResultService.GetMikeScenarioResultWithMikeScenarioResultID(MikeScenarioResultID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeScenarioResult>> Post(MikeScenarioResult MikeScenarioResult)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioResultService.Post(MikeScenarioResult);
        }
        [HttpPut]
        public async Task<ActionResult<MikeScenarioResult>> Put(MikeScenarioResult MikeScenarioResult)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioResultService.Put(MikeScenarioResult);
        }
        [HttpDelete("{MikeScenarioResultID}")]
        public async Task<ActionResult<bool>> Delete(int MikeScenarioResultID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeScenarioResultService.Delete(MikeScenarioResultID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
