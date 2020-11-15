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
    public partial interface ILocalReportSectionController
    {
        Task<ActionResult<List<LocalReportSection>>> Get();
        Task<ActionResult<LocalReportSection>> Get(int LocalReportSectionID);
        Task<ActionResult<LocalReportSection>> Post(LocalReportSection LocalReportSection);
        Task<ActionResult<LocalReportSection>> Put(LocalReportSection LocalReportSection);
        Task<ActionResult<bool>> Delete(int LocalReportSectionID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class LocalReportSectionController : ControllerBase, ILocalReportSectionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private ILocalReportSectionDBService LocalReportSectionDBService { get; }
        #endregion Properties

        #region Constructors
        public LocalReportSectionController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, ILocalReportSectionDBService LocalReportSectionDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.LocalReportSectionDBService = LocalReportSectionDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<LocalReportSection>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalReportSectionDBService.GetLocalReportSectionList();
        }
        [HttpGet("{LocalReportSectionID}")]
        public async Task<ActionResult<LocalReportSection>> Get(int ReportSectionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalReportSectionDBService.GetLocalReportSectionWithReportSectionID(ReportSectionID);
        }
        [HttpPost]
        public async Task<ActionResult<LocalReportSection>> Post(LocalReportSection LocalReportSection)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalReportSectionDBService.Post(LocalReportSection);
        }
        [HttpPut]
        public async Task<ActionResult<LocalReportSection>> Put(LocalReportSection LocalReportSection)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalReportSectionDBService.Put(LocalReportSection);
        }
        [HttpDelete("{LocalReportSectionID}")]
        public async Task<ActionResult<bool>> Delete(int LocalReportSectionID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await LocalReportSectionDBService.Delete(LocalReportSectionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}