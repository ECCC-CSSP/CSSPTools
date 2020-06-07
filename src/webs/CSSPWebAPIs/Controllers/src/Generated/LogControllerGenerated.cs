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
    public partial interface ILogController
    {
        Task<ActionResult<List<Log>>> Get();
        Task<ActionResult<Log>> Get(int LogID);
        Task<ActionResult<Log>> Post(Log log);
        Task<ActionResult<Log>> Put(Log log);
        Task<ActionResult<bool>> Delete(int LogID);
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
        [HttpDelete("{LogID}")]
        public async Task<ActionResult<bool>> Delete(int LogID)
        {
            return await logService.Delete(LogID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}