﻿/*
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

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAuthController
    {
        Task<ActionResult<Contact>> Token(LoginModel loginModel);
        Task<ActionResult<string>> GoogleMapKey();
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase, IAuthController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IContactDBService ContactDBService { get; }
        #endregion Properties

        #region Constructors
        public AuthController(IConfiguration Configuration, ILoggedInService LoggedInService, ICSSPCultureService CSSPCultureService, 
            IContactDBService ContactDBService)
        {
            this.Configuration = Configuration;
            this.LoggedInService = LoggedInService;
            this.CSSPCultureService = CSSPCultureService;
            this.ContactDBService = ContactDBService;
        }
        #endregion Constructors

        #region Functions public
        [Route("Token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Contact>> Token(LoginModel loginModel)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);

            return await ContactDBService.Login(loginModel);
        }
        [Route("GoogleMapKey")]
        [HttpGet]
        public async Task<ActionResult<string>> GoogleMapKey()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LoggedInService.SetLoggedInContactInfo(User.Identity.Name);

            return await ContactDBService.GoogleMapKey();
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
