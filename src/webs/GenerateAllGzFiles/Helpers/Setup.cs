/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CSSPWebServices.Services;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using UserServices.Models;
using UserServices.Services;

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

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDB2);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDB2));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IWebService, WebService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider is null");
                return await Task.FromResult(false);
            }

            CultureService = Provider.GetService<ICultureService>();
            if (CultureService == null)
            {
                Console.WriteLine("CultureService is null");
                return await Task.FromResult(false);
            }

            CultureService.SetCulture("en-CA");

            userService = Provider.GetService<IUserService>();
            if (userService == null)
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

            var actionUserModel = await userService.Login(loginModel);
            if (actionUserModel.Value == null)
            {
                Console.WriteLine("actionUserModel == null");
                return await Task.FromResult(false);
            }

            userModel = (UserModel)actionUserModel.Value;
            if (userModel == null)
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

            await LoggedInService.SetLoggedInContactInfo(userModel.Id);
            if (LoggedInService.GetLoggedInContactInfo() == null)
            {
                Console.WriteLine("GetLoggedInContactInfo() is null");
                return await Task.FromResult(false);
            }

            WebService = Provider.GetService<IWebService>();
            if (WebService == null)
            {
                Console.WriteLine("WebService is null");
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
