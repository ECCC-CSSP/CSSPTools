/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
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
    public partial class LabSheetController : ControllerBase, ILabSheetController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILabSheetDBLocalService LabSheetDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public LabSheetController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILabSheetDBLocalService LabSheetDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LabSheetDBLocalService = LabSheetDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LabSheet>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LabSheetDBLocalService.GetLabSheetList();
        }
        [HttpGet("{LabSheetID}")]
        public async Task<ActionResult<LabSheet>> Get(int LabSheetID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LabSheetDBLocalService.GetLabSheetWithLabSheetID(LabSheetID);
        }
        [HttpPost]
        public async Task<ActionResult<LabSheet>> Post(LabSheet LabSheet)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LabSheetDBLocalService.Post(LabSheet);
        }
        [HttpPut]
        public async Task<ActionResult<LabSheet>> Put(LabSheet LabSheet)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LabSheetDBLocalService.Put(LabSheet);
        }
        [HttpDelete("{LabSheetID}")]
        public async Task<ActionResult<bool>> Delete(int LabSheetID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LabSheetDBLocalService.Delete(LabSheetID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
