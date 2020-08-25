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
        private Contact contact { get; set; }
        private IReadController ReadController { get; set; }
        private string RunningOn { get; set; }
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

            //string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");
            //Assert.NotNull(CSSPDBLocalFileName);

            //string TestDB = Configuration.GetValue<string>("CSSPDB2");
            //Assert.NotNull(TestDB);

            //Services.AddSingleton<IConfiguration>(Configuration);

            //Services.AddDbContext<CSSPDBContext>(options =>
            //{
            //    options.UseSqlServer(TestDB);
            //});

            //Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            //{
            //    options.UseInMemoryDatabase(TestDB);
            //});

            //FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            //Services.AddDbContext<CSSPDBLocalContext>(options =>
            //{
            //    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            //});

            //FileInfo fiAppDataPath = new FileInfo(CSSPDBLoginFileName);

            //Services.AddDbContext<CSSPDBLocalContext>(options =>
            //{
            //    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            //});

            //Services.AddIdentityCore<ApplicationUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(TestDB));

            //Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            //Services.AddSingleton<IEnums, Enums>();
            //Services.AddSingleton<ILoggedInService, LoggedInService>();
            //Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            //Services.AddSingleton<ILoginModelService, LoginModelService>();
            //Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            //Services.AddSingleton<IContactService, ContactService>();

            //Provider = Services.BuildServiceProvider();
            //Assert.NotNull(Provider);

            //CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            //Assert.NotNull(CSSPCultureService);

            //CSSPCultureService.SetCulture(culture);

            //ContactService = Provider.GetService<IContactService>();
            //Assert.NotNull(ContactService);

            //string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            //Assert.NotNull(LoginEmail);

            //string Password = Password = Configuration.GetValue<string>("Password");
            //Assert.NotNull(Password);

            //LoginModel loginModel = new LoginModel()
            //{
            //    LoginEmail = LoginEmail,
            //    Password = Password
            //};

            //var actionUserModel = await ContactService.Login(loginModel);
            //Assert.NotNull(actionUserModel.Value);
            //contact = actionUserModel.Value;

            //LoggedInService = Provider.GetService<ILoggedInService>();
            //Assert.NotNull(LoggedInService);

            //await LoggedInService.SetLoggedInContactInfo(contact.Id);
            //Assert.NotNull(LoggedInService.LoggedInContactInfo);



            Services.AddCors();
            Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            string APISecret = Configuration.GetValue<string>("APISecret");
            byte[] key = Encoding.ASCII.GetBytes(APISecret);

            Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            RunningOn = Configuration.GetValue<string>("RunningOn"); // either "Local", "Azure"

            string DBConnStr = "";

            if (RunningOn == "Azure")
            {
                DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

            }
            else
            {
                string DBToUse = Configuration.GetValue<string>("DBToUse");

                if (DBToUse == "CSSPDB")
                {
                    DBConnStr = Configuration.GetValue<string>("CSSPDB");
                }

                if (DBToUse == "CSSPDB2")
                {
                    DBConnStr = Configuration.GetValue<string>("CSSPDB2");
                }

                if (DBToUse == "TestDB")
                {
                    DBConnStr = Configuration.GetValue<string>("TestDB");

                }
            }

            /* ---------------------------------------------------------------------------------
             * Setting up the required CSSPDB, CSSPDB2, TestDB or AzureCSSPDB with ApplicationUser
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(DBConnStr));

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
                    options.UseInMemoryDatabase(DBConnStr));

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnStr));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocal 
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFileManagement
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");

            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            Services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            Services.AddScoped<IEnums, Enums>();
            Services.AddScoped<ILoginModelService, LoginModelService>();
            Services.AddScoped<IRegisterModelService, RegisterModelService>();
            Services.AddScoped<ILoggedInService, LoggedInService>();
            Services.AddScoped<IContactService, ContactService>();

            Startup startup = new Startup(Configuration); 
            startup.LoadAllDBServices(Services);

            Services.AddScoped<ICreateGzFileService, CreateGzFileService>();
            Services.AddScoped<ICSSPFileService, CSSPFileService>();
            Services.AddScoped<IDownloadGzFileService, DownloadGzFileService>();
            Services.AddScoped<IReadGzFileService, ReadGzFileService>();

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
