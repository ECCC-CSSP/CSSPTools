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
        Task<ActionResult<ReportType>> Delete(ReportType reportType);
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
        [HttpDelete]
        public async Task<ActionResult<ReportType>> Delete(ReportType reportType)
        {
            return await reportTypeService.Delete(reportType);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
