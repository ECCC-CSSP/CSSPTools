/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
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
        private IAspNetUserService AspNetUserService { get; set; }
        private IContactService ContactService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ITVItemService TVItemService { get; set; }
        private Contact contact { get; set; }
        private IReadController ReadController { get; set; }
        private RunningOnEnum RunningOn { get; set; }
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
               .AddUserSecrets("9d65c001-b7bc-4922-a0fc-1558b9ef927e")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            string DBConnString = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(DBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(DBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(DBConnString);
            });

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnString));

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<ITVItemService, TVItemService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactService = Provider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            AspNetUserService = Provider.GetService<IAspNetUserService>();
            Assert.NotNull(AspNetUserService);

            TVItemService = Provider.GetService<ITVItemService>();
            Assert.NotNull(TVItemService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
