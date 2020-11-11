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
    public partial interface IMikeBoundaryConditionController
    {
        Task<ActionResult<List<MikeBoundaryCondition>>> Get();
        Task<ActionResult<MikeBoundaryCondition>> Get(int MikeBoundaryConditionID);
        Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition MikeBoundaryCondition);
        Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition MikeBoundaryCondition);
        Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MikeBoundaryConditionController : ControllerBase, IMikeBoundaryConditionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IMikeBoundaryConditionDBService MikeBoundaryConditionDBService { get; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMikeBoundaryConditionDBService MikeBoundaryConditionDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MikeBoundaryConditionDBService = MikeBoundaryConditionDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeBoundaryCondition>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionDBService.GetMikeBoundaryConditionList();
        }
        [HttpGet("{MikeBoundaryConditionID}")]
        public async Task<ActionResult<MikeBoundaryCondition>> Get(int MikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionDBService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition MikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionDBService.Post(MikeBoundaryCondition);
        }
        [HttpPut]
        public async Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition MikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionDBService.Put(MikeBoundaryCondition);
        }
        [HttpDelete("{MikeBoundaryConditionID}")]
        public async Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionDBService.Delete(MikeBoundaryConditionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
