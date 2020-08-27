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
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using CSSPEnums;
using CSSPCultureServices.Resources;

namespace CSSPWebAPIs.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IContactService ContactService { get; }
        #endregion Properties

        #region Constructors
        public AuthController(IConfiguration Configuration, ILoggedInService LoggedInService, ICSSPCultureService CSSPCultureService, IContactService ContactService)
        {
            this.Configuration = Configuration;
            this.LoggedInService = LoggedInService;
            this.CSSPCultureService = CSSPCultureService;
            this.ContactService = ContactService;
        }
        #endregion Constructors

        #region Functions public
        [Route("token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Contact>> Token(LoginModel loginModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);

            if (LoggedInService.RunningOn != RunningOnEnum.Azure)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnAzure, "Token")));
            }

            return await ContactService.Login(loginModel);
        }
        [Route("azurestore")]
        [HttpGet]
        public async Task<ActionResult<string>> AzureStore()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            if (LoggedInService.RunningOn != RunningOnEnum.Azure)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnAzure, "AzureStore")));
            }

            return await ContactService.AzureStore();
        }
        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);

            if (LoggedInService.RunningOn != RunningOnEnum.Azure)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnAzure, "Register")));
            }

            return await Task.FromResult(true);
            //return await ContactService.Register(registerModel);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
