using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactServices.Tests
{
    public partial class ContactServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IContactService ContactService { get; set; }
        private IAspNetUserService AspNetUserService { get; set; }
        private ITVItemService TVItemService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private LoginModel loginModel { get; set; } = new LoginModel();
        #endregion Properties

        #region Constructors
        public ContactServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Assert.NotNull(Configuration);

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IEnums, Enums>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();
            ServiceCollection.AddSingleton<IAspNetUserService, AspNetUserService>();
            ServiceCollection.AddSingleton<ILoginModelService, LoginModelService>();
            ServiceCollection.AddSingleton<IRegisterModelService, RegisterModelService>();
            ServiceCollection.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            ServiceCollection.AddSingleton<IContactService, ContactService>();
            ServiceCollection.AddSingleton<ITVItemService, TVItemService>();

            string DBConnString = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(DBConnString);

            loginModel.LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(loginModel.LoginEmail);

            loginModel.Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(loginModel.Password);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(DBConnString));

            ServiceCollection.AddDbContext<CSSPDBInMemoryContext>(options =>
                    options.UseInMemoryDatabase(DBConnString));

            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            ServiceCollection.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLocalFileName);

            ServiceCollection.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ServiceCollection.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            ServiceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnString));

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactService = ServiceProvider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            AspNetUserService = ServiceProvider.GetService<IAspNetUserService>();
            Assert.NotNull(AspNetUserService);

            TVItemService = ServiceProvider.GetService<ITVItemService>();
            Assert.NotNull(TVItemService);

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
