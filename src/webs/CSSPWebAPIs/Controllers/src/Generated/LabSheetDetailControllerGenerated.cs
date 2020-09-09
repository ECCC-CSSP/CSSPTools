/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILabSheetDetailController
    {
        Task<ActionResult<List<LabSheetDetail>>> Get();
        Task<ActionResult<LabSheetDetail>> Get(int LabSheetDetailID);
        Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail LabSheetDetail);
        Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail LabSheetDetail);
        Task<ActionResult<bool>> Delete(int LabSheetDetailID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetDetailController : ControllerBase, ILabSheetDetailController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ILabSheetDetailDBService LabSheetDetailDBService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ILabSheetDetailDBService LabSheetDetailDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.LabSheetDetailDBService = LabSheetDetailDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetDetail>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailDBService.GetLabSheetDetailList();
        }
        [HttpGet("{LabSheetDetailID}")]
        public async Task<ActionResult<LabSheetDetail>> Get(int LabSheetDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailDBService.GetLabSheetDetailWithLabSheetDetailID(LabSheetDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail LabSheetDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailDBService.Post(LabSheetDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail LabSheetDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailDBService.Put(LabSheetDetail);
        }
        [HttpDelete("{LabSheetDetailID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailDBService.Delete(LabSheetDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
