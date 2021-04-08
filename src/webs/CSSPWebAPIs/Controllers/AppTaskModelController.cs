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
using LoggedInServices;
using CSSPDBServices;
using CSSPHelperModels;
using CSSPWebModels;
using CSSPAzureAppTaskModelServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAppTaskController
    {
        Task<ActionResult<List<AppTaskModel>>> Get();
        Task<ActionResult<AppTaskModel>> Post(AppTaskModel appTaskModel);
        Task<ActionResult<bool>> Delete(int AppTaskID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class AppTaskModelController : ControllerBase, IAppTaskController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ILoggedInService LoggedInService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IAzureAppTaskModelService AzureAppTaskModelService { get; }
        #endregion Properties

        #region Constructors
        public AppTaskModelController(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IAzureAppTaskModelService AzureAppTaskModelService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.AzureAppTaskModelService = AzureAppTaskModelService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<AppTaskModel>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskModelService.GetAllAzureAppTaskModel();
        }
        [HttpPost]
        public async Task<ActionResult<AppTaskModel>> Post(AppTaskModel appTaskModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskModelService.AddOrModifyAzureAppTaskModel(appTaskModel);
        }
        [Route("{AppTaskID:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int AppTaskID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await AzureAppTaskModelService.DeleteAzureAppTaskModel(AppTaskID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
