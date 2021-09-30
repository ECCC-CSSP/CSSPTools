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
using CSSPServerLoggedInServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSSPHelperModels;
using CSSPScrambleServices;

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
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public ContactDBService(IConfiguration Configuration, ICSSPScrambleService CSSPScrambleService,
           ICSSPCultureService CSSPCultureService, IEnums enums,
           ICSSPServerLoggedInService CSSPServerLoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<string>> AzureStore()
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
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
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
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
            if (string.IsNullOrWhiteSpace(loginModel.LoginEmail))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"));
            }

            if (!string.IsNullOrWhiteSpace(loginModel.LoginEmail) && (loginModel.LoginEmail.Length < 5 || loginModel.LoginEmail.Length > 100))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "5", "100"));
            }

            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Password"));
            }

            if (!string.IsNullOrWhiteSpace(loginModel.Password) && (loginModel.Password.Length < 5 || loginModel.Password.Length > 50))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "5", "50"));
            }

            if (errRes.ErrList.Count > 0)
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

                if (loginModel.Password == CSSPScrambleService.Descramble(contact.PasswordHash))
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
