using CSSPModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using UserServices.Models;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Configuration;
using ActionCommandDBServices.Services;
using ActionCommandDBServices.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using CultureServices.Resources;

namespace UserServices.Services
{
    public class UserService : ControllerBase, IUserService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        private UserManager<ApplicationUser> userManager { get; }
        private CSSPDBContext csspDBContext { get; }
        private ApiSettingsModel appSettings { get; }
        #endregion Properties

        #region Constructors
        public UserService(IConfiguration configuration, IOptions<ApiSettingsModel> appSettings, UserManager<ApplicationUser> userManager, CSSPDBContext csspDBContext)
        {
            this.configuration = configuration;
            this.appSettings = appSettings.Value;
            this.userManager = userManager;
            this.csspDBContext = csspDBContext;
        }
        #endregion Constructors

        #region Functions public
        //public async Task CreateUser()
        //{
        //    var user = new ApplicationUser { UserName = "TestUser", Email = "test@example.com" };
        //    var result = await _userManager.CreateAsync(user, "Test@123");

        //    if (result.Succeeded == false)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            Console.WriteLine(error.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Done.");
        //    }
        //}

        public async Task<ActionResult<UserModel>> CheckPassword(LoginModel loginModel)
        {
            try
            {
                ApplicationUser appUser = await userManager.FindByNameAsync(loginModel.LoginEmail);

                if (appUser == null)
                {
                    return BadRequest(String.Format(CultureServicesRes.__CouldNotBeFound, CultureServicesRes.Email, loginModel.LoginEmail));
                }

                bool HasPassword = await userManager.CheckPasswordAsync(appUser, loginModel.Password);
                if (!HasPassword)
                {
                    return BadRequest(String.Format(CultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                }

                if (HasPassword == true)
                {
                    Contact contact = (from c in csspDBContext.Contacts
                                       where c.Id == appUser.Id
                                       select c).AsNoTracking().FirstOrDefault();
                    if (contact == null)
                    {
                        return BadRequest(String.Format(CultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                    }

                    UserModel userModel = new UserModel()
                    {
                        ContactID = contact.ContactID,
                        Id = contact.Id,
                        ContactTVItemID = contact.ContactTVItemID,
                        LoginEmail = contact.LoginEmail,
                        FirstName = contact.FirstName,
                        Initial = contact.Initial,
                        LastName = contact.LastName
                    };

                    byte[] key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("ApiSettings:APISecret"));

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userModel.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    userModel.Token = tokenHandler.WriteToken(token);

                    return userModel;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(String.Format(CultureServicesRes.Error_, ex.Message));
            }

            return BadRequest(String.Format(CultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}