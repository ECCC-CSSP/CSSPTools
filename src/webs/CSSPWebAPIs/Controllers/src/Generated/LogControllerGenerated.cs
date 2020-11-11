/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggedInServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface ILogController
    {
        Task<ActionResult<List<Log>>> Get();
        Task<ActionResult<Log>> Get(int LogID);
        Task<ActionResult<Log>> Post(Log Log);
        Task<ActionResult<Log>> Put(Log Log);
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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ILogDBService LogDBService { get; }
        #endregion Properties

        #region Constructors
        public LogController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, ILogDBService LogDBService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.LogDBService = LogDBService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Log>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LogDBService.GetLogList();
        }
        [HttpGet("{LogID}")]
        public async Task<ActionResult<Log>> Get(int LogID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LogDBService.GetLogWithLogID(LogID);
        }
        [HttpPost]
        public async Task<ActionResult<Log>> Post(Log Log)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LogDBService.Post(Log);
        }
        [HttpPut]
        public async Task<ActionResult<Log>> Put(Log Log)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LogDBService.Put(Log);
        }
        [HttpDelete("{LogID}")]
        public async Task<ActionResult<bool>> Delete(int LogID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await LogDBService.Delete(LogID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
