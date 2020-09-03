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
    public partial interface ILabSheetController
    {
        Task<ActionResult<List<LabSheet>>> Get();
        Task<ActionResult<LabSheet>> Get(int LabSheetID);
        Task<ActionResult<LabSheet>> Post(LabSheet LabSheet);
        Task<ActionResult<LabSheet>> Put(LabSheet LabSheet);
        Task<ActionResult<bool>> Delete(int LabSheetID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LabSheetController : ControllerBase, ILabSheetController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ILabSheetService LabSheetService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ILabSheetService LabSheetService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.LabSheetService = LabSheetService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheet>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetService.GetLabSheetList();
        }
        [HttpGet("{LabSheetID}")]
        public async Task<ActionResult<LabSheet>> Get(int LabSheetID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetService.GetLabSheetWithLabSheetID(LabSheetID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheet>> Post(LabSheet LabSheet)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetService.Post(LabSheet);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheet>> Put(LabSheet LabSheet)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetService.Put(LabSheet);
        }
        [HttpDelete("{LabSheetID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LabSheetService.Delete(LabSheetID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
