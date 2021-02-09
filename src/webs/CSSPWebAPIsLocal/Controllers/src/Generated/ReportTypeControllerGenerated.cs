/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPWebAPIsLocalController.exe
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
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IReportTypeController
    {
        Task<ActionResult<List<ReportType>>> Get();
        Task<ActionResult<ReportType>> Get(int ReportTypeID);
        Task<ActionResult<ReportType>> Post(ReportType ReportType);
        Task<ActionResult<ReportType>> Put(ReportType ReportType);
        Task<ActionResult<bool>> Delete(int ReportTypeID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class ReportTypeController : ControllerBase, IReportTypeController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IReportTypeDBService ReportTypeDBService { get; }
        #endregion Properties

        #region Constructors
        public ReportTypeController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IReportTypeDBService ReportTypeDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.ReportTypeDBService = ReportTypeDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ReportType>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ReportTypeDBService.GetReportTypeList();
        }
        [HttpGet("{ReportTypeID}")]
        public async Task<ActionResult<ReportType>> Get(int ReportTypeID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ReportTypeDBService.GetReportTypeWithReportTypeID(ReportTypeID);
        }
        [HttpPost]
        public async Task<ActionResult<ReportType>> Post(ReportType ReportType)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ReportTypeDBService.Post(ReportType);
        }
        [HttpPut]
        public async Task<ActionResult<ReportType>> Put(ReportType ReportType)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ReportTypeDBService.Put(ReportType);
        }
        [HttpDelete("{ReportTypeID}")]
        public async Task<ActionResult<bool>> Delete(int ReportTypeID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await ReportTypeDBService.Delete(ReportTypeID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}