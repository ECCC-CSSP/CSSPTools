using CSSPModels;
using CSSPWebAPIs.Entities;
using CSSPWebAPIs.Helpers;
using CSSPWebAPIs.Models;
using CSSPWebAPIs.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Services
{
    public interface IContactService
    {
        Task<Contact> Login(LoginModel loginModel);
        Task<Contact> Register(RegisterModel registerModel);
        Task CreateUser();
        Task CheckPassword();
        Task SetCulture(CultureInfo culture);
    }

    public class ContactService : IContactService
    {
        #region Variables
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly CSSPDBContext _db;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactService(CSSPDBContext db, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings) : base()
        {
            _db = db;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }
        #endregion Constructors

        #region Functions public
        public async Task SetCulture(CultureInfo culture)
        {
            WebSite.Culture = culture;
        }

        public async Task<Contact> Login(LoginModel loginModel)
        {
            var appUser = await _userManager.FindByNameAsync(loginModel.LoginEmail);
            if (appUser == null)
            {
                return new Contact() { HasErrors = true, ValidationResults = new[] { new ValidationResult($"{WebSite.test}Could not find parameter", new[] { "LoginEmail" }) } };
            }

            var HasPassword = await _userManager.CheckPasswordAsync(appUser, loginModel.Password);

            if (HasPassword == false)
            {
                return new Contact() { HasErrors = true, ValidationResults = new[] { new ValidationResult($"{WebSite.test}Could not find parameter", new[] { "Password" }) } };
            }

            Contact contact = new Contact();
            try
            {
                contact = _db.Contacts.Where(c => c.Id == appUser.Id).FirstOrDefault();
                if (contact == null)
                {
                    return new Contact() { HasErrors = true, ValidationResults = new[] { new ValidationResult($"{WebSite.test}Could not find parameter", new[] { "Id" }) } };
                }
            }
            catch (Exception ex)
            {
                return new Contact() { HasErrors = true, ValidationResults = new[] { new ValidationResult($"{WebSite.test}Unexpected Error occured: Err: { ex.Message }", new[] { "" }) } };
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, contact.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            contact.Token = tokenHandler.WriteToken(token);

            return contact.Cleaned();
        }
        public async Task<Contact> Register(RegisterModel registerModel)
        {

            //var user = new ApplicationUser { UserName = registerModel.LoginEmail, Email = registerModel.LoginEmail };
            //var result = await _userManager.CreateAsync(user, registerModel.Password);

            //if (result.Succeeded == false)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    Contact contactNew = new Contact()
            //    {
            //        ContactTVItemID = tvItemContact.TVItemID,

            //    };
            //    var contact = _db.Contacts.Add()
            //    Console.WriteLine("Done.");
            //}

            return null;
        }
        #endregion Function public

        #region Functions private
        private string CreateTVText(Contact contact)
        {
            return MakeFullName(contact.FirstName, contact.Initial, contact.LastName);
        }
        private string MakeFullName(string FirstName, string Initial, string LastName)
        {
            return LastName + ", " + FirstName + (string.IsNullOrWhiteSpace(Initial) ? "" : " " + Initial + ".");
        }
        #endregion Functions private

        public async Task CreateUser()
        {
            var user = new ApplicationUser { UserName = "TestUser", Email = "test@example.com" };
            var result = await _userManager.CreateAsync(user, "Test@123");

            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
            else
            {
                Console.WriteLine("Done.");
            }
        }

        public async Task CheckPassword()
        {
            string email = "Charles.LeBlanc2@canada.ca";
            string password = "Charles2!";

            //var user = new ApplicationUser { UserName = email, Email = email };

            var appUser = await _userManager.FindByNameAsync(email);

            var HasPassword = await _userManager.CheckPasswordAsync(appUser, password);

            if (HasPassword == true)
            {
                Console.WriteLine($"Yes {email} with {password} exist in DB");
            }
            else
            {
                Console.WriteLine($"No {email} with {password} does not exist in DB");
            }
        }

    }
}
