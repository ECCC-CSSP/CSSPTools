/*
 * Manually edited
 * 
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPServerLoggedInServices;
using CSSPDBServices;
using CSSPHelperModels;
using CSSPWebModels;
using CSSPAzureAppTaskServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAppTaskController
    {
        Task<ActionResult<List<AppTaskLocalModel>>> Get();
        Task<ActionResult<AppTaskLocalModel>> Post(AppTaskLocalModel appTaskModel);
        Task<ActionResult<bool>> Delete(int AppTaskID);
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
        public async Task<ActionResult<List<AppTaskLocalModel>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.GetAllAzureAppTask();
        }
        [HttpPost]
        public async Task<ActionResult<AppTaskLocalModel>> Post(AppTaskLocalModel appTaskModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.AddOrModifyAzureAppTask(appTaskModel);
        }
        [Route("{AppTaskID:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskService.DeleteAzureAppTask(AppTaskID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
