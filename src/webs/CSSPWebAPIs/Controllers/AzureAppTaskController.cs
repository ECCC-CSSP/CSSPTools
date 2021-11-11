/*
 * Manually edited
 * 
 */
using CSSPAzureAppTaskServices;
using CSSPCultureServices.Services;
using CSSPServerLoggedInServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAppTaskController
    {
        Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync();
        Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel appTaskModel);
        Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int AppTaskID);
        Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel appTaskModel);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    //[Authorize]
    public class AzureAppTaskController : ControllerBase, IAppTaskController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IAzureAppTaskService AzureAppTaskService { get; }
        #endregion Properties

        #region Constructors
        public AzureAppTaskController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, IAzureAppTaskService AzureAppTaskService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.AzureAppTaskService = AzureAppTaskService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.GetAllAzureAppTaskAsync();
        }
        [HttpPost]
        public async Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel appTaskModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        }
        [HttpPut]
        public async Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel appTaskModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
        }
        [Route("{AppTaskID:int}")]
        [HttpDelete]
        public async Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int AppTaskID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.DeleteAzureAppTaskAsync(AppTaskID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
