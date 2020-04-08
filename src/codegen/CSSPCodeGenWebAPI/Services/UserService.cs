using CSSPCodeGenWebAPI.Controllers;
using CSSPModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CSSPCodeGenWebAPI.Services.Resources;

namespace CSSPCodeGenWebAPI.Model
{
    public class UserService : IUserService
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public CSSPDBContext _csspDBContext;

        public UserService(UserManager<ApplicationUser> userManager, CSSPDBContext csspDBContext)
        {
            _userManager = userManager;
            _csspDBContext = csspDBContext;
        }

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

        public async Task<UserModel> CheckPassword(LoginModel loginModel)
        {
            try
            {
                ApplicationUser appUser = await _userManager.FindByNameAsync(loginModel.LoginEmail);

                if (appUser == null)
                {
                    return new UserModel() { Error = String.Format(ServicesRes.__CouldNotBeFound, ServicesRes.Email, loginModel.LoginEmail) };
                }

                bool HasPassword = await _userManager.CheckPasswordAsync(appUser, loginModel.Password);
                if (!HasPassword)
                {
                    return new UserModel() { Error = String.Format(ServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail) };
                }

                if (HasPassword == true)
                {
                    Contact contact = (from c in _csspDBContext.Contacts
                                       where c.Id == appUser.Id
                                       select c).AsNoTracking().FirstOrDefault();
                    if (contact == null)
                    {
                        return null;
                    }

                    return new UserModel()
                    {
                        ContactID = contact.ContactID,
                        Id = contact.Id,
                        ContactTVItemID = contact.ContactTVItemID,
                        LoginEmail = contact.LoginEmail,
                        FirstName = contact.FirstName,
                        Initial = contact.Initial,
                        LastName = contact.LastName
                    };
                }
            }
            catch (Exception ex)
            {
                return new UserModel() { Error = String.Format(ServicesRes.Error_, ex.Message) };
            }

            return null;
        }
    }
}