using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DownloadFileServices;
using CSSPDBFilesManagementModels;
using CSSPDBPreferenceModels;
using CSSPScrambleServices;
using LoggedInServices;
using FilesManagementServices;

namespace ReadGzFileServices.Tests
{
    public partial class ReadGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IFilesManagementService FilesManagementService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBContext db { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPAzureUrl { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspreadgzfileservicestests.json")
               .AddUserSecrets("7f7f83c1-bbc1-4805-9cae-163ec6952d6d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(CSSPJSONPath);

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            //Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(CSSPDBConnString));

            //Services.AddIdentityCore<ApplicationUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocalFileName = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocalFileName.FullName }");
            });

            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            });

            string CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreferenceFileName);

            FileInfo fiCSSPDBPreferenceFileName = new FileInfo(CSSPDBPreferenceFileName);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreferenceFileName.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IFilesManagementService, FilesManagementService>();
            Services.AddSingleton<IDownloadFileService, DownloadFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            FilesManagementService = Provider.GetService<IFilesManagementService>();
            Assert.NotNull(FilesManagementService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
