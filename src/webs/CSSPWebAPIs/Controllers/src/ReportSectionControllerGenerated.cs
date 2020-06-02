using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IReportSectionController
    {
        Task<ActionResult<List<ReportSection>>> Get();
        Task<ActionResult<ReportSection>> Get(int ReportSectionID);
        Task<ActionResult<ReportSection>> Post(ReportSection reportSection);
        Task<ActionResult<ReportSection>> Put(ReportSection reportSection);
        Task<ActionResult<ReportSection>> Delete(ReportSection reportSection);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class ReportSectionController : ControllerBase, IReportSectionController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IReportSectionService reportSectionService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public ReportSectionController(IReportSectionService reportSectionService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.reportSectionService = reportSectionService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<ReportSection>>> Get()
        {
            return await reportSectionService.GetReportSectionList();
        }
        [HttpGet("{ReportSectionID}")]
        public async Task<ActionResult<ReportSection>> Get(int ReportSectionID)
        {
            return await reportSectionService.GetReportSectionWithReportSectionID(ReportSectionID);
        }
        [HttpPost]
        public async Task<ActionResult<ReportSection>> Post(ReportSection reportSection)
        {
            return await reportSectionService.Add(reportSection);
        }
        [HttpPut]
        public async Task<ActionResult<ReportSection>> Put(ReportSection reportSection)
        {
            return await reportSectionService.Update(reportSection);
        }
        [HttpDelete]
        public async Task<ActionResult<ReportSection>> Delete(ReportSection reportSection)
        {
            return await reportSectionService.Delete(reportSection);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
