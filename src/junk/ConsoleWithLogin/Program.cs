using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ConsoleWithLogin.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ConsoleWithLogin
{
    class Program
    {

        static void Main(string[] args)
        {
            IConfiguration Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_consolewithlogin.json")
                .AddUserSecrets("1db435fb-226b-4b0f-a0fe-1088769aff08")
                .Build();

            string AzureCSSPDB = Config.GetValue<string>("AzureCSSPDB");

            var services = new ServiceCollection();

            //setup our DI
            // Add framework services.            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(AzureCSSPDB);
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
                //.AddDefaultTokenProviders();

            services.AddScoped<IUserCreationService, UserCreationService>();

            // Build the IoC from the service collection
            var provider = services.BuildServiceProvider();

            var userService = provider.GetService<IUserCreationService>();

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            string Password = Config.GetValue<string>("Password");

            userService.CheckPassword(LoginEmail, Password).GetAwaiter().GetResult();
            //userService.CreateUser().GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}