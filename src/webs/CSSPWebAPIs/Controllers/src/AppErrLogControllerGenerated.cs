using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IAppErrLogController
    {
        Task<ActionResult<List<AppErrLog>>> Get();
        Task<ActionResult<AppErrLog>> Get(int AppErrLogID);
        Task<ActionResult<AppErrLog>> Post(AppErrLog appErrLog);
        Task<ActionResult<AppErrLog>> Put(AppErrLog appErrLog);
        Task<ActionResult<AppErrLog>> Delete(AppErrLog appErrLog);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AppErrLogController : ControllerBase, IAppErrLogController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAppErrLogService appErrLogService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public AppErrLogController(IAppErrLogService appErrLogService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.appErrLogService = appErrLogService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppErrLog>>> Get()
        {
            return await appErrLogService.GetAppErrLogList();
        }
        [HttpGet("{AppErrLogID}")]
        public async Task<ActionResult<AppErrLog>> Get(int AppErrLogID)
        {
            return await appErrLogService.GetAppErrLogWithAppErrLogID(AppErrLogID);
        }
        [HttpPost]
        public async Task<ActionResult<AppErrLog>> Post(AppErrLog appErrLog)
        {
            return await appErrLogService.Add(appErrLog);
        }
        [HttpPut]
        public async Task<ActionResult<AppErrLog>> Put(AppErrLog appErrLog)
        {
            return await appErrLogService.Update(appErrLog);
        }
        [HttpDelete]
        public async Task<ActionResult<AppErrLog>> Delete(AppErrLog appErrLog)
        {
            return await appErrLogService.Delete(appErrLog);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
