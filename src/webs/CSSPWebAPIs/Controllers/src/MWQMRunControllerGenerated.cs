using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IMWQMRunController
    {
        Task<ActionResult<List<MWQMRun>>> Get();
        Task<ActionResult<MWQMRun>> Get(int MWQMRunID);
        Task<ActionResult<MWQMRun>> Post(MWQMRun mwqmRun);
        Task<ActionResult<MWQMRun>> Put(MWQMRun mwqmRun);
        Task<ActionResult<MWQMRun>> Delete(MWQMRun mwqmRun);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class MWQMRunController : ControllerBase, IMWQMRunController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IMWQMRunService mwqmRunService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public MWQMRunController(IMWQMRunService mwqmRunService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.mwqmRunService = mwqmRunService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<MWQMRun>>> Get()
        {
            return await mwqmRunService.GetMWQMRunList();
        }
        [HttpGet("{MWQMRunID}")]
        public async Task<ActionResult<MWQMRun>> Get(int MWQMRunID)
        {
            return await mwqmRunService.GetMWQMRunWithMWQMRunID(MWQMRunID);
        }
        [HttpPost]
        public async Task<ActionResult<MWQMRun>> Post(MWQMRun mwqmRun)
        {
            return await mwqmRunService.Add(mwqmRun);
        }
        [HttpPut]
        public async Task<ActionResult<MWQMRun>> Put(MWQMRun mwqmRun)
        {
            return await mwqmRunService.Update(mwqmRun);
        }
        [HttpDelete]
        public async Task<ActionResult<MWQMRun>> Delete(MWQMRun mwqmRun)
        {
            return await mwqmRunService.Delete(mwqmRun);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
