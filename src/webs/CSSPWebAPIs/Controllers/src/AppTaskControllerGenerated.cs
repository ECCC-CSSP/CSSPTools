using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IAppTaskController
    {
        Task<ActionResult<List<AppTask>>> Get();
        Task<ActionResult<AppTask>> Get(int AppTaskID);
        Task<ActionResult<AppTask>> Post(AppTask appTask);
        Task<ActionResult<AppTask>> Put(AppTask appTask);
        Task<ActionResult<AppTask>> Delete(AppTask appTask);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AppTaskController : ControllerBase, IAppTaskController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAppTaskService appTaskService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public AppTaskController(IAppTaskService appTaskService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.appTaskService = appTaskService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppTask>>> Get()
        {
            return await appTaskService.GetAppTaskList();
        }
        [HttpGet("{AppTaskID}")]
        public async Task<ActionResult<AppTask>> Get(int AppTaskID)
        {
            return await appTaskService.GetAppTaskWithAppTaskID(AppTaskID);
        }
        [HttpPost]
        public async Task<ActionResult<AppTask>> Post(AppTask appTask)
        {
            return await appTaskService.Add(appTask);
        }
        [HttpPut]
        public async Task<ActionResult<AppTask>> Put(AppTask appTask)
        {
            return await appTaskService.Update(appTask);
        }
        [HttpDelete]
        public async Task<ActionResult<AppTask>> Delete(AppTask appTask)
        {
            return await appTaskService.Delete(appTask);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
