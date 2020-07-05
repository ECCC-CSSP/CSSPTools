/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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

namespace CSSPWebAPI.Controllers
{
    public partial interface IAppTaskController
    {
        Task<ActionResult<List<AppTask>>> Get();
        Task<ActionResult<AppTask>> Get(int AppTaskID);
        Task<ActionResult<AppTask>> Post(AppTask AppTask);
        Task<ActionResult<AppTask>> Put(AppTask AppTask);
        Task<ActionResult<bool>> Delete(int AppTaskID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AppTaskController : ControllerBase, IAppTaskController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IAppTaskService AppTaskService { get; }
        #endregion Properties

        #region Constructors
        public AppTaskController(ICultureService CultureService, ILoggedInService LoggedInService, IAppTaskService AppTaskService)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.AppTaskService = AppTaskService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppTask>>> Get()
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppTaskService.GetAppTaskList();
        }
        [HttpGet("{AppTaskID}")]
        public async Task<ActionResult<AppTask>> Get(int AppTaskID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppTaskService.GetAppTaskWithAppTaskID(AppTaskID);
        }
        [HttpPost]
        public async Task<ActionResult<AppTask>> Post(AppTask AppTask)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppTaskService.Post(AppTask);
        }
        [HttpPut]
        public async Task<ActionResult<AppTask>> Put(AppTask AppTask)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppTaskService.Put(AppTask);
        }
        [HttpDelete("{AppTaskID}")]
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            CultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AppTaskService.Delete(AppTaskID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
