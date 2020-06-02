using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMAnalysisReportParameterController
    {
        Task<ActionResult<List<MWQMAnalysisReportParameter>>> Get();
        Task<ActionResult<MWQMAnalysisReportParameter>> Get(int MWQMAnalysisReportParameterID);
        Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter mwqmAnalysisReportParameter);
        Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter mwqmAnalysisReportParameter);
        Task<ActionResult<MWQMAnalysisReportParameter>> Delete(MWQMAnalysisReportParameter mwqmAnalysisReportParameter);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMAnalysisReportParameterController : ControllerBase, IMWQMAnalysisReportParameterController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMAnalysisReportParameterService mwqmAnalysisReportParameterService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterController(IMWQMAnalysisReportParameterService mwqmAnalysisReportParameterService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmAnalysisReportParameterService = mwqmAnalysisReportParameterService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMAnalysisReportParameter>>> Get()
        {
            return await mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList();
        }
        [HttpGet("{MWQMAnalysisReportParameterID}")]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Get(int MWQMAnalysisReportParameterID)
        {
            return await mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(MWQMAnalysisReportParameterID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Post(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            return await mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Put(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            return await mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMAnalysisReportParameter>> Delete(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            return await mwqmAnalysisReportParameterService.Delete(mwqmAnalysisReportParameter);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
