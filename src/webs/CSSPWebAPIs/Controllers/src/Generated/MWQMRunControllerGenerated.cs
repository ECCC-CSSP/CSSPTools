/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
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
    public partial interface IMWQMRunController
    {
        Task<ActionResult<List<MWQMRun>>> Get();
        Task<ActionResult<MWQMRun>> Get(int MWQMRunID);
        Task<ActionResult<MWQMRun>> Post(MWQMRun MWQMRun);
        Task<ActionResult<MWQMRun>> Put(MWQMRun MWQMRun);
        Task<ActionResult<bool>> Delete(int MWQMRunID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMRunController : ControllerBase, IMWQMRunController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMWQMRunDBService MWQMRunDBService { get; }
        #endregion Properties

        #region Constructors
        public MWQMRunController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMWQMRunDBService MWQMRunDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MWQMRunDBService = MWQMRunDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMRun>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunDBService.GetMWQMRunList();
        }
        [HttpGet("{MWQMRunID}")]
        public async Task<ActionResult<MWQMRun>> Get(int MWQMRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunDBService.GetMWQMRunWithMWQMRunID(MWQMRunID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMRun>> Post(MWQMRun MWQMRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunDBService.Post(MWQMRun);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMRun>> Put(MWQMRun MWQMRun)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunDBService.Put(MWQMRun);
        }
        [HttpDelete("{MWQMRunID}")]
        public async Task<ActionResult<bool>> Delete(int MWQMRunID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MWQMRunDBService.Delete(MWQMRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
