using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface ILogController
    {
        Task<ActionResult<List<Log>>> Get();
        Task<ActionResult<Log>> Get(int LogID);
        Task<ActionResult<Log>> Post(Log log);
        Task<ActionResult<Log>> Put(Log log);
        Task<ActionResult<Log>> Delete(Log log);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class LogController : ControllerBase, ILogController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ILogService logService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public LogController(ILogService logService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.logService = logService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Log>>> Get()
        {
            return await logService.GetLogList();
        }
        [HttpGet("{LogID}")]
        public async Task<ActionResult<Log>> Get(int LogID)
        {
            return await logService.GetLogWithLogID(LogID);
        }
        [HttpPost]
        public async Task<ActionResult<Log>> Post(Log log)
        {
            return await logService.Add(log);
        }
        [HttpPut]
        public async Task<ActionResult<Log>> Put(Log log)
        {
            return await logService.Update(log);
        }
        [HttpDelete]
        public async Task<ActionResult<Log>> Delete(Log log)
        {
            return await logService.Delete(log);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
