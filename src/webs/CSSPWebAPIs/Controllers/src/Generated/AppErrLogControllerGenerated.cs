/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAppErrLogController
    {
        Task<ActionResult<List<AppErrLog>>> Get();
        Task<ActionResult<AppErrLog>> Get(int AppErrLogID);
        Task<ActionResult<AppErrLog>> Post(AppErrLog AppErrLog);
        Task<ActionResult<AppErrLog>> Put(AppErrLog AppErrLog);
        Task<ActionResult<bool>> Delete(int AppErrLogID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AppErrLogController : ControllerBase, IAppErrLogController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IAppErrLogService AppErrLogService { get; }
        #endregion Properties

        #region Constructors
        public AppErrLogController(ICultureService CultureService, ILoggedInService LoggedInService, IAppErrLogService AppErrLogService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.AppErrLogService = AppErrLogService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppErrLog>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppErrLogService.GetAppErrLogList();
        }
        [HttpGet("{AppErrLogID}")]
        public async Task<ActionResult<AppErrLog>> Get(int AppErrLogID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppErrLogService.GetAppErrLogWithAppErrLogID(AppErrLogID);
        }
        [HttpPost]
        public async Task<ActionResult<AppErrLog>> Post(AppErrLog AppErrLog)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppErrLogService.Post(AppErrLog);
        }
        [HttpPut]
        public async Task<ActionResult<AppErrLog>> Put(AppErrLog AppErrLog)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppErrLogService.Put(AppErrLog);
        }
        [HttpDelete("{AppErrLogID}")]
        public async Task<ActionResult<bool>> Delete(int AppErrLogID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppErrLogService.Delete(AppErrLogID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
