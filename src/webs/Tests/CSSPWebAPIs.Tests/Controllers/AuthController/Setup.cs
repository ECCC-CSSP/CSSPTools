/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIs.Controllers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CSSPWebAPIs;
using LoggedInServices;
using CreateGzFileServices;

namespace AuthController.Tests
{
    public partial class AuthControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ITVItemDBService TVItemDBService { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public AuthControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        protected async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string DBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(DBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(DBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(DBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnString));

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactDBService = Provider.GetService<IContactDBService>();
            Assert.NotNull(ContactDBService);

            TVItemDBService = Provider.GetService<ITVItemDBService>();
            Assert.NotNull(TVItemDBService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
