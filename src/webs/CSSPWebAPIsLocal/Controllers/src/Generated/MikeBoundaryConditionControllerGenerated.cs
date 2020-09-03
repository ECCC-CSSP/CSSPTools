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

namespace CSSPWebAPIsLocal.Controllers
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
        private IMikeBoundaryConditionService MikeBoundaryConditionService { get; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IMikeBoundaryConditionService MikeBoundaryConditionService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.MikeBoundaryConditionService = MikeBoundaryConditionService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MikeBoundaryCondition>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionService.GetMikeBoundaryConditionList();
        }
        [HttpGet("{MikeBoundaryConditionID}")]
        public async Task<ActionResult<MikeBoundaryCondition>> Get(int MikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);
        }
        [HttpPost]
        public async Task<ActionResult<MikeBoundaryCondition>> Post(MikeBoundaryCondition MikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionService.Post(MikeBoundaryCondition);
        }
        [HttpPut]
        public async Task<ActionResult<MikeBoundaryCondition>> Put(MikeBoundaryCondition MikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionService.Put(MikeBoundaryCondition);
        }
        [HttpDelete("{MikeBoundaryConditionID}")]
        public async Task<ActionResult<bool>> Delete(int MikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await MikeBoundaryConditionService.Delete(MikeBoundaryConditionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
