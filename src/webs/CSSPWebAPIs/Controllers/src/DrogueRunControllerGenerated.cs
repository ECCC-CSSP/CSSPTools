using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IDrogueRunController
    {
        Task<ActionResult<List<DrogueRun>>> Get();
        Task<ActionResult<DrogueRun>> Get(int DrogueRunID);
        Task<ActionResult<DrogueRun>> Post(DrogueRun drogueRun);
        Task<ActionResult<DrogueRun>> Put(DrogueRun drogueRun);
        Task<ActionResult<DrogueRun>> Delete(DrogueRun drogueRun);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class DrogueRunController : ControllerBase, IDrogueRunController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDrogueRunService drogueRunService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public DrogueRunController(IDrogueRunService drogueRunService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.drogueRunService = drogueRunService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<DrogueRun>>> Get()
        {
            return await drogueRunService.GetDrogueRunList();
        }
        [HttpGet("{DrogueRunID}")]
        public async Task<ActionResult<DrogueRun>> Get(int DrogueRunID)
        {
            return await drogueRunService.GetDrogueRunWithDrogueRunID(DrogueRunID);
        }
        [HttpPost]
        public async Task<ActionResult<DrogueRun>> Post(DrogueRun drogueRun)
        {
            return await drogueRunService.Add(drogueRun);
        }
        [HttpPut]
        public async Task<ActionResult<DrogueRun>> Put(DrogueRun drogueRun)
        {
            return await drogueRunService.Update(drogueRun);
        }
        [HttpDelete]
        public async Task<ActionResult<DrogueRun>> Delete(DrogueRun drogueRun)
        {
            return await drogueRunService.Delete(drogueRun);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
