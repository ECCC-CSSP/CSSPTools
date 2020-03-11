using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithLogin.Model
{
    public class UserCreationService : IUserCreationService
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public UserCreationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

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