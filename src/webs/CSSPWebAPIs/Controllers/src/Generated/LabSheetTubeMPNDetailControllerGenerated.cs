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

namespace CSSPWebAPI.Controllers
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
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ILabSheetTubeMPNDetailService LabSheetTubeMPNDetailService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailController(ICultureService CultureService, ILoggedInService LoggedInService, ILabSheetTubeMPNDetailService LabSheetTubeMPNDetailService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.LabSheetTubeMPNDetailService = LabSheetTubeMPNDetailService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetTubeMPNDetail>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailList();
        }
        [HttpGet("{LabSheetTubeMPNDetailID}")]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Get(int LabSheetTubeMPNDetailID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(LabSheetTubeMPNDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Post(LabSheetTubeMPNDetail LabSheetTubeMPNDetail)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailService.Post(LabSheetTubeMPNDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetTubeMPNDetail>> Put(LabSheetTubeMPNDetail LabSheetTubeMPNDetail)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailService.Put(LabSheetTubeMPNDetail);
        }
        [HttpDelete("{LabSheetTubeMPNDetailID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetTubeMPNDetailID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetTubeMPNDetailService.Delete(LabSheetTubeMPNDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
