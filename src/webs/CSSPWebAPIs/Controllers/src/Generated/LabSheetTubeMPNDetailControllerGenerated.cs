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
    public partial interface ILabSheetTubeMPNDetailController
    {
        Task<ActionResult<List<LabSheetTubeMPNDetail>>> Get();
        Task<ActionResult<LabSheetTubeMPNDetail>> Get(int LabSheetTubeMPNDetailID);
        Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail LabSheetTubeMPNDetail);
        Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail LabSheetTubeMPNDetail);
        Task<ActionResult<bool>> Delete(int LabSheetTubeMPNDetailID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetTubeMPNDetailController : ControllerBase, ILabSheetTubeMPNDetailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ILabSheetTubeMPNDetailDBService LabSheetTubeMPNDetailDBService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ILabSheetTubeMPNDetailDBService LabSheetTubeMPNDetailDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.LabSheetTubeMPNDetailDBService = LabSheetTubeMPNDetailDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetTubeMPNDetail>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailList();
        }
        [HttpGet("{LabSheetTubeMPNDetailID}")]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Get(int LabSheetTubeMPNDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailDBService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail LabSheetTubeMPNDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailDBService.Post(LabSheetTubeMPNDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail LabSheetTubeMPNDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailDBService.Put(LabSheetTubeMPNDetail);
        }
        [HttpDelete("{LabSheetTubeMPNDetailID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetTubeMPNDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailDBService.Delete(LabSheetTubeMPNDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
