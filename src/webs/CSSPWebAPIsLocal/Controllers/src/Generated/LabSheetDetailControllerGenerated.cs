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
        private ILabSheetDetailService LabSheetDetailService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ILabSheetDetailService LabSheetDetailService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.LabSheetDetailService = LabSheetDetailService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheetDetail>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailService.GetLabSheetDetailList();
        }
        [HttpGet("{LabSheetDetailID}")]
        public async Task<ActionResult<LabSheetDetail>> Get(int LabSheetDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(LabSheetDetailID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheetDetail>> Post(LabSheetDetail LabSheetDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailService.Post(LabSheetDetail);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheetDetail>> Put(LabSheetDetail LabSheetDetail)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailService.Put(LabSheetDetail);
        }
        [HttpDelete("{LabSheetDetailID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetDetailID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetDetailService.Delete(LabSheetDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
