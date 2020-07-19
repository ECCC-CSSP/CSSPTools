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
        private ICSSPCultureService CSSPCultureService { get; }
        private IContactService ContactService { get; }
        #endregion Properties

        #region Constructors
        public AuthController(ICSSPCultureService CSSPCultureService, IContactService ContactService)
        {
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
            return await ContactService.Login(loginModel);
        }
        //[Route("Register")]
        //[HttpPost]
        //public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        //{
        //    //Thread.Sleep(1000);

        //    await userService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

        //    return await userService.Register(registerModel);
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
