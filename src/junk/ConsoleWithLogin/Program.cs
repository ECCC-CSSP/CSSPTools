using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ConsoleWithLogin.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWithLogin
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            //setup our DI
            // Add framework services.            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=tcp:fpk3qgefkk.database.windows.net,1433;Initial Catalog=CSSPDB2;Persist Security Info=False;User ID=CSSP_user;Password=Veronique93!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
                //.AddDefaultTokenProviders();

            services.AddScoped<IUserCreationService, UserCreationService>();

            // Build the IoC from the service collection
            var provider = services.BuildServiceProvider();

            var userService = provider.GetService<IUserCreationService>();

            userService.CheckPassword().GetAwaiter().GetResult();
            //userService.CreateUser().GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}