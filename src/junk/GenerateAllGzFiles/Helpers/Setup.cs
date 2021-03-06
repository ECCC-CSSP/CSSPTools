﻿/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        private async Task<bool> Setup()
        {

            Services = new ServiceCollection();

            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocalFileName))
            {
                Console.WriteLine("CSSPDBLocalFileName is empty");
                return await Task.FromResult(false);
            }

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDB2 = Configuration.GetValue<string>("CSSPDB2");
            if (string.IsNullOrWhiteSpace(CSSPDB2))
            {
                Console.WriteLine("CSSPDB2 is empty");
                return await Task.FromResult(false);
            }

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDB2);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDB2);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDB2));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<IGzFileService, GzFileService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider is null");
                return await Task.FromResult(false);
            }

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            if (CSSPCultureService == null)
            {
                Console.WriteLine("CSSPCultureService is null");
                return await Task.FromResult(false);
            }

            CSSPCultureService.SetCulture("en-CA");

            ContactService = Provider.GetService<IContactService>();
            if (ContactService == null)
            {
                Console.WriteLine("userService is null");
                return await Task.FromResult(false);
            }

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                Console.WriteLine("LoginEmail is null");
                return await Task.FromResult(false);
            }

            string Password = Password = Configuration.GetValue<string>("Password");
            if (string.IsNullOrWhiteSpace(Password))
            {
                Console.WriteLine("Password is null");
                return await Task.FromResult(false);
            }

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            var actionContact = await ContactService.Login(loginModel);
            if (actionContact.Value == null)
            {
                Console.WriteLine("actionUserModel == null");
                return await Task.FromResult(false);
            }

            Contact contact = (Contact)actionContact.Value;
            if (contact == null)
            {
                Console.WriteLine("userModel == null");
                return await Task.FromResult(false);
            }

            LoggedInService = Provider.GetService<ILoggedInService>();
            if (LoggedInService == null)
            {
                Console.WriteLine("LoggedInService is null");
                return await Task.FromResult(false);
            }

            await LoggedInService.SetLoggedInContactInfo(contact.Id);
            if (LoggedInService.GetLoggedInContactInfo() == null)
            {
                Console.WriteLine("GetLoggedInContactInfo() is null");
                return await Task.FromResult(false);
            }

            GzFileService = Provider.GetService<IGzFileService>();
            if (GzFileService == null)
            {
                Console.WriteLine("WebService is null");
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
