using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IPolSourceObservationIssueController
    {
        Task<ActionResult<List<PolSourceObservationIssue>>> Get();
        Task<ActionResult<PolSourceObservationIssue>> Get(int PolSourceObservationIssueID);
        Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue polSourceObservationIssue);
        Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue polSourceObservationIssue);
        Task<ActionResult<PolSourceObservationIssue>> Delete(PolSourceObservationIssue polSourceObservationIssue);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class PolSourceObservationIssueController : ControllerBase, IPolSourceObservationIssueController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IPolSourceObservationIssueService polSourceObservationIssueService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueController(IPolSourceObservationIssueService polSourceObservationIssueService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.polSourceObservationIssueService = polSourceObservationIssueService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<PolSourceObservationIssue>>> Get()
        {
            return await polSourceObservationIssueService.GetPolSourceObservationIssueList();
        }
        [HttpGet("{PolSourceObservationIssueID}")]
        public async Task<ActionResult<PolSourceObservationIssue>> Get(int PolSourceObservationIssueID)
        {
            return await polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(PolSourceObservationIssueID);
        }
        [HttpPost]
        public async Task<ActionResult<PolSourceObservationIssue>> Post(PolSourceObservationIssue polSourceObservationIssue)
        {
            return await polSourceObservationIssueService.Add(polSourceObservationIssue);
        }
        [HttpPut]
        public async Task<ActionResult<PolSourceObservationIssue>> Put(PolSourceObservationIssue polSourceObservationIssue)
        {
            return await polSourceObservationIssueService.Update(polSourceObservationIssue);
        }
        [HttpDelete]
        public async Task<ActionResult<PolSourceObservationIssue>> Delete(PolSourceObservationIssue polSourceObservationIssue)
        {
            return await polSourceObservationIssueService.Delete(polSourceObservationIssue);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
