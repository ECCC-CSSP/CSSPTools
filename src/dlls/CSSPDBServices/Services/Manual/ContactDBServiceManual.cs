/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSSPHelperModels;
using CSSPHelperServices;

namespace CSSPDBServices
{
    public partial interface IContactDBService
    {
        Task<ActionResult<Contact>> Login(LoginModel loginModel);
        Task<ActionResult<string>> AzureStore();
        Task<ActionResult<string>> GoogleMapKey();
    }

    public partial class ContactDBService : ControllerBase, IContactDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILoginModelService LoginModelService { get; }
        private IRegisterModelService RegisterModelService { get; }
        private ILoggedInService LoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public ContactDBService(IConfiguration Configuration,
           ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoginModelService LoginModelService,
           IRegisterModelService RegisterModelService,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LoginModelService = LoginModelService;
            this.RegisterModelService = RegisterModelService;
            this.LoggedInService = LoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<string>> AzureStore()
        {
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            string sto = Configuration.GetValue<string>("AzureStore");
            if (string.IsNullOrWhiteSpace(sto))
            {
                errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, "Configuration", "AzureStore"));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(sto));
        }
        public async Task<ActionResult<string>> GoogleMapKey()
        {
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            string sto = Configuration.GetValue<string>("GoogleMapKey");
            if (string.IsNullOrWhiteSpace(sto))
            {
                errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, "Configuration", "GoogleMapKey"));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(sto));
        }
        public async Task<ActionResult<Contact>> Login(LoginModel loginModel)
        {
            if (!LoginModelService.Validate(new ValidationContext(loginModel)))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                Contact contact = (from c in db.Contacts
                                   where c.LoginEmail == loginModel.LoginEmail
                                   select c).FirstOrDefault();

                if (contact == null)
                {
                    errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                    return await Task.FromResult(BadRequest(errRes));
                }

                if (loginModel.Password == LoggedInService.Descramble(contact.PasswordHash))
                {

                    byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("APISecret"));

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, contact.LoginEmail)
                        }),
                        Expires = DateTime.UtcNow.AddDays(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    contact.Token = tokenHandler.WriteToken(token);

                    return await Task.FromResult(Ok(contact));
                }
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.Error_, ex.Message));
                return await Task.FromResult(BadRequest(errRes));
            }

            errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
            return await Task.FromResult(BadRequest(errRes));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
