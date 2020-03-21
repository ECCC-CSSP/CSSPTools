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
                options.UseSqlServer("Server=.\\sqlexpress;Database=CSSPDB2;Trusted_Connection=True;MultipleActiveResultSets=true");
            }, );

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