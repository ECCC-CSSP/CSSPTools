/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IReportTypeController
    {
        Task<ActionResult<List<ReportType>>> Get();
        Task<ActionResult<ReportType>> Get(int ReportTypeID);
        Task<ActionResult<ReportType>> Post(ReportType reportType);
        Task<ActionResult<ReportType>> Put(ReportType reportType);
        Task<ActionResult<bool>> Delete(int ReportTypeID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ReportTypeController : ControllerBase, IReportTypeController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IReportTypeService reportTypeService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ReportTypeController(IReportTypeService reportTypeService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.reportTypeService = reportTypeService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ReportType>>> Get()
        {
            return await reportTypeService.GetReportTypeList();
        }
        [HttpGet("{ReportTypeID}")]
        public async Task<ActionResult<ReportType>> Get(int ReportTypeID)
        {
            return await reportTypeService.GetReportTypeWithReportTypeID(ReportTypeID);
        }
        [HttpPost]
        public async Task<ActionResult<ReportType>> Post(ReportType reportType)
        {
            return await reportTypeService.Add(reportType);
        }
        [HttpPut]
        public async Task<ActionResult<ReportType>> Put(ReportType reportType)
        {
            return await reportTypeService.Update(reportType);
        }
        [HttpDelete("{ReportTypeID}")]
        public async Task<ActionResult<bool>> Delete(int ReportTypeID)
        {
            return await reportTypeService.Delete(ReportTypeID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}