///*
// * manually edited
// *
// */

//using CSSPEnums;
//using CSSPModels;
//using CSSPDBServices;
//using CSSPCultureServices.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;
//using CSSPWebAPIs.Controllers;
//using System.Text;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using CSSPWebAPIs;
//using LoggedInServices;

//namespace Startup.Tests
//{
//    public partial class StartupTests
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Configuration { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private IServiceCollection Services { get; set; }
//        private CSSPDBContext db { get; set; }
//        private IContactDBService ContactDBService { get; set; }
//        private ILoggedInService LoggedInService { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private ITVItemDBService TVItemDBService { get; set; }
//        private Contact contact { get; set; }
//        private string LoginEmail { get; set; }
//        private string Password { get; set; }
//        private string CSSPAzureUrl { get; set; }
//        #endregion Properties

//        #region Constructors
//        public StartupTests()
//        {
//        }
//        #endregion Constructors

//        #region Tests
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task AuthController_Constructor_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));
            
//            Assert.NotNull(Configuration);
//            Assert.NotNull(CSSPCultureService);
//        }
//        #endregion Tests

//        #region Functions private
//        private async Task<bool> Setup(string culture)
//        {
//            Configuration = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//               .AddJsonFile("appsettings_csspwebapistests.json")
//               .AddUserSecrets("9d65c001-b7bc-4922-a0fc-1558b9ef927e")
//               .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Configuration);

//            Services.AddCors();
//            Services.AddControllers()
//                .AddJsonOptions(options =>
//                {
//                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//                });

//            string APISecret = Configuration.GetValue<string>("APISecret");
//            byte[] key = Encoding.ASCII.GetBytes(APISecret);

//            Services.AddAuthentication(x =>
//            {
//                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(x =>
//            {
//                x.RequireHttpsMetadata = false;
//                x.SaveToken = true;
//                x.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false,
//                    ValidateAudience = false
//                };
//            });

//            RunningOn = Configuration.GetValue<string>("RunningOn") == "Local" ? RunningOnEnum.Local : RunningOnEnum.Azure;

//            string DBConnStr = "";

//            if (RunningOn == RunningOnEnum.Azure)
//            {
//                DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

//            }
//            else
//            {
//                string DBToUse = Configuration.GetValue<string>("DBToUse");

//                if (DBToUse == "CSSPDB2")
//                {
//                    DBConnStr = Configuration.GetValue<string>("CSSPDB2");
//                }

//                if (DBToUse == "TestDB")
//                {
//                    DBConnStr = Configuration.GetValue<string>("TestDB");

//                }
//            }

//            /* ---------------------------------------------------------------------------------
//             * Setting up the required CSSPDB, CSSPDB2, TestDB or AzureCSSPDB with ApplicationUser
//             * ---------------------------------------------------------------------------------      
//             */

//            Services.AddDbContext<CSSPDBContext>(options =>
//                    options.UseSqlServer(DBConnStr));

//            //Services.AddDbContext<CSSPDBInMemoryContext>(options =>
//            //        options.UseInMemoryDatabase(DBConnStr));

//            Services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(DBConnStr));

//            Services.AddIdentityCore<ApplicationUser>()
//            .AddEntityFrameworkStores<ApplicationDbContext>();

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBLocal 
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

//            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

//            Services.AddDbContext<CSSPDBLocalContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
//            });

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBLogin
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

//            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

//            Services.AddDbContext<CSSPDBLoginContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
//            });

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBFileManagement
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");

//            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagementFileName);

//            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
//            });

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBSearch
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");

//            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);

//            Services.AddDbContext<CSSPDBSearchContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
//            });

//            Services.AddScoped<ICSSPCultureService, CSSPCultureService>();
//            Services.AddScoped<IEnums, Enums>();
//            Services.AddScoped<ILoginModelService, LoginModelService>();
//            Services.AddScoped<IRegisterModelService, RegisterModelService>();
//            Services.AddScoped<ILoggedInService, LoggedInService>();
//            Services.AddScoped<IContactService, ContactService>();

//            LoadAllDBServices(Services);

//            Services.AddScoped<ICreateGzFileService, CreateGzFileService>();
//            Services.AddScoped<ICSSPFileService, CSSPFileService>();
//            Services.AddScoped<IDownloadGzFileService, DownloadGzFileService>();
//            Services.AddScoped<IReadGzFileService, ReadGzFileService>();
//            Services.AddScoped<ICSSPDBSearchService, CSSPDBSearchService>();

//            if (RunningOn == RunningOnEnum.Local)
//            {
//                Services.AddSpaStaticFiles(configuration =>
//                {
//                    configuration.RootPath = "csspclient";
//                });
//            }

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            return await Task.FromResult(true);
//        }
//        #endregion Functions private

//    }
//}
