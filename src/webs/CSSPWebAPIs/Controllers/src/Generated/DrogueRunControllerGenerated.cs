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
    public partial interface IDrogueRunController
    {
        Task<ActionResult<List<DrogueRun>>> Get();
        Task<ActionResult<DrogueRun>> Get(int DrogueRunID);
        Task<ActionResult<DrogueRun>> Post(DrogueRun DrogueRun);
        Task<ActionResult<DrogueRun>> Put(DrogueRun DrogueRun);
        Task<ActionResult<bool>> Delete(int DrogueRunID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DrogueRunController : ControllerBase, IDrogueRunController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IDrogueRunService DrogueRunService { get; }
        #endregion Properties

        #region Constructors
        public DrogueRunController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IDrogueRunService DrogueRunService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.DrogueRunService = DrogueRunService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DrogueRun>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunService.GetDrogueRunList();
        }
        [HttpGet("{DrogueRunID}")]
        public async Task<ActionResult<DrogueRun>> Get(int DrogueRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunService.GetDrogueRunWithDrogueRunID(DrogueRunID);
        }
        [HttpPost]
        public async Task<ActionResult<DrogueRun>> Post(DrogueRun DrogueRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunService.Post(DrogueRun);
        }
        [HttpPut]
        public async Task<ActionResult<DrogueRun>> Put(DrogueRun DrogueRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunService.Put(DrogueRun);
        }
        [HttpDelete("{DrogueRunID}")]
        public async Task<ActionResult<bool>> Delete(int DrogueRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await DrogueRunService.Delete(DrogueRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
