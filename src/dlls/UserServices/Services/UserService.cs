﻿using CSSPModels;
using CSSPServices;
using CultureServices.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserServices.Models;

namespace UserServices.Services
{
    public interface IUserService
    {
        //Task<ActionResult<bool>> RegisterUser(RegisterModel registerModel);
        Task<ActionResult<UserModel>> Login(LoginModel loginModel);
    }
    public class UserService : ControllerBase, IUserService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private UserManager<ApplicationUser> userManager { get; }
        private IAspNetUserService AspNetUserService { get; }
        private IContactService ContactService { get; }
        #endregion Properties

        #region Constructors
        public UserService(IConfiguration configuration, UserManager<ApplicationUser> userManager, IAspNetUserService AspNetUserService, IContactService ContactService)
        {
            this.Configuration = configuration;
            this.userManager = userManager;
            this.AspNetUserService = AspNetUserService;
            this.ContactService = ContactService;
        }
        #endregion Constructors

        #region Functions public
        //public async Task<ActionResult<bool>> RegisterUser(RegisterModel registerModel)
        //{
        //    // before starting ... should verify
        //    // - required FirstName, LastName, Password, ConfirmPassword, LoginEmail
        //    // - min and max lengths
        //    // - Password and ConfirmPassword are equal
        //    // - email is unique -- not already taken
        //    // - FirstName, Initial and LastName is unique -- not already taken
        //    // - Password has at least 6 characters

        //    if (string.IsNullOrWhiteSpace(registerModel.FirstName))
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CultureServicesRes.FirstName) }");
        //    }

        //    if (string.IsNullOrWhiteSpace(registerModel.LastName))
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CultureServicesRes.LastName) }");
        //    }

        //    if (string.IsNullOrWhiteSpace(registerModel.LoginEmail))
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CultureServicesRes.LoginEmail) }");
        //    }

        //    if (string.IsNullOrWhiteSpace(registerModel.Password))
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CultureServicesRes.Password) }");
        //    }

        //    if (string.IsNullOrWhiteSpace(registerModel.ConfirmPassword))
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CultureServicesRes.ConfirmPassword) }");
        //    }

        //    if (registerModel.FirstName.Trim().Length > 100)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._MaxLengthIs_, CultureServicesRes.FirstName, 100) }");
        //    }

        //    if (registerModel.Initial.Trim().Length > 50)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._MaxLengthIs_, CultureServicesRes.Initial, 100) }");
        //    }

        //    if (registerModel.LastName.Trim().Length > 100)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._MaxLengthIs_, CultureServicesRes.LastName, 100) }");
        //    }

        //    if (registerModel.LoginEmail.Trim().Length > 100)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._MaxLengthIs_, CultureServicesRes.LoginEmail, 255) }");
        //    }

        //    if (registerModel.Password.Trim().Length > 50)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._MaxLengthIs_, CultureServicesRes.Password, 50) }");
        //    }

        //    if (registerModel.Password != registerModel.ConfirmPassword)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes._And_AreNotEqual, CultureServicesRes.Password, CultureServicesRes.ConfirmPassword) }");
        //    }

        //    AspNetUser aspNetUser = (from c in csspDBContext.AspNetUsers
        //                             where c.UserName == registerModel.LoginEmail
        //                             select c).FirstOrDefault();

        //    if (aspNetUser != null)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes.UserName_AlreadyTaken, registerModel.LoginEmail) }");
        //    }

        //    Contact contact = (from c in csspDBContext.Contacts
        //                       where c.LoginEmail == registerModel.LoginEmail
        //                       select c).FirstOrDefault();

        //    if (contact != null)
        //    {
        //        return BadRequest($"{ string.Format(CSSPCultureServicesRes.UserName_AlreadyTaken, registerModel.LoginEmail) }");
        //    }

        //    if (string.IsNullOrWhiteSpace(registerModel.Initial))
        //    {
        //        contact = (from c in csspDBContext.Contacts
        //                   where c.FirstName == registerModel.FirstName
        //                   && c.LastName == registerModel.LastName
        //                   select c).FirstOrDefault();

        //        if (contact != null)
        //        {
        //            string fullName = $"{ registerModel.FirstName } { registerModel.LastName }";
        //            return BadRequest($"{ string.Format(CSSPCultureServicesRes.User_AlreadyTaken, fullName) }");
        //        }
        //    }
        //    else
        //    {
        //        contact = (from c in csspDBContext.Contacts
        //                   where c.FirstName == registerModel.FirstName
        //                   && c.Initial == registerModel.Initial
        //                   && c.LastName == registerModel.LastName
        //                   select c).FirstOrDefault();

        //        if (contact != null)
        //        {
        //            string fullName = $"{ registerModel.FirstName } { registerModel.Initial }, { registerModel.LastName }";
        //            return BadRequest($"{ string.Format(CSSPCultureServicesRes.User_AlreadyTaken, fullName) }");
        //        }
        //    }

        //    // creating user in AspNetUsers table
        //    var user = new ApplicationUser { UserName = registerModel.LoginEmail, Email = registerModel.LoginEmail };
        //    var result = await userManager.CreateAsync(user, registerModel.Password);

        //    if (result.Succeeded == false)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    // Adding more info in Contacts table
        //    Contact contactNew = new Contact()
        //    {
        //        Id = user.Id,
        //         FirstName = registerModel.FirstName,
        //         Initial = registerModel.Initial,
        //         LastName = registerModel.LastName,
        //         LoginEmail = registerModel.LoginEmail,
        //          etc...

        //    };

        //    // Adding TVItemUserAuthorization and TVTypeUserAuthorization

        //    return Ok(true);
        //}

        public async Task<ActionResult<UserModel>> Login(LoginModel loginModel)
        {
            try
            {
                ApplicationUser appUser = await userManager.FindByNameAsync(loginModel.LoginEmail);

                if (appUser == null)
                {
                    return BadRequest(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, CultureServicesRes.Email, loginModel.LoginEmail));
                }

                bool HasPassword = await userManager.CheckPasswordAsync(appUser, loginModel.Password);
                if (!HasPassword)
                {
                    return BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                }

                if (HasPassword == true)
                {
                    var actionContact = ContactService.GetContactWithId(appUser.Id);
                    //if (((ObjectResult)actionContact.Result).StatusCode != 200)
                    //{
                    //    return BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                    //}

                    Contact contact = null; // (Contact)((OkObjectResult)actionContact.Result).Value;

                    if (contact == null)
                    {
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

                    byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("APISecret"));

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
                return BadRequest(String.Format(CSSPCultureServicesRes.Error_, ex.Message));
            }

            return BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}