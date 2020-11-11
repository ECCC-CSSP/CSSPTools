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
    public partial interface ILocalMikeBoundaryConditionController
    {
        Task<ActionResult<List<LocalMikeBoundaryCondition>>> Get();
        Task<ActionResult<LocalMikeBoundaryCondition>> Get(int LocalMikeBoundaryConditionID);
        Task<ActionResult<LocalMikeBoundaryCondition>> Post(LocalMikeBoundaryCondition LocalMikeBoundaryCondition);
        Task<ActionResult<LocalMikeBoundaryCondition>> Put(LocalMikeBoundaryCondition LocalMikeBoundaryCondition);
        Task<ActionResult<bool>> Delete(int LocalMikeBoundaryConditionID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalMikeBoundaryConditionController : ControllerBase, ILocalMikeBoundaryConditionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalMikeBoundaryConditionDBService LocalMikeBoundaryConditionDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalMikeBoundaryConditionController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalMikeBoundaryConditionDBService LocalMikeBoundaryConditionDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalMikeBoundaryConditionDBService = LocalMikeBoundaryConditionDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalMikeBoundaryCondition>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeBoundaryConditionDBService.GetLocalMikeBoundaryConditionList();
        }
        [HttpGet("{LocalMikeBoundaryConditionID}")]
        public async Task<ActionResult<LocalMikeBoundaryCondition>> Get(int MikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeBoundaryConditionDBService.GetLocalMikeBoundaryConditionWithMikeBoundaryConditionID(MikeBoundaryConditionID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalMikeBoundaryCondition>> Post(LocalMikeBoundaryCondition LocalMikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeBoundaryConditionDBService.Post(LocalMikeBoundaryCondition);
        }
        [HttpPut]
        public async Task<ActionResult<LocalMikeBoundaryCondition>> Put(LocalMikeBoundaryCondition LocalMikeBoundaryCondition)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeBoundaryConditionDBService.Put(LocalMikeBoundaryCondition);
        }
        [HttpDelete("{LocalMikeBoundaryConditionID}")]
        public async Task<ActionResult<bool>> Delete(int LocalMikeBoundaryConditionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalMikeBoundaryConditionDBService.Delete(LocalMikeBoundaryConditionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
