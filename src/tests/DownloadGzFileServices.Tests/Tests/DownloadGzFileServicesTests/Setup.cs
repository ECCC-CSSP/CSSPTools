using CSSPEnums;
using CSSPModels;
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
using CSSPDBFilesManagementServices;
using LocalServices;

namespace DownloadGzFileServices.Tests
{
    public partial class DownloadGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; set; }
        private IDownloadGzFileService DownloadGzFileService { get; set; }
        private ILocalService LocalService { get; set; }
        private CSSPDBContext db { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string LocalCSSPJSONPath { get; set; }
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
               .AddJsonFile("appsettings_downloadgzfileservicestests.json")
               .AddUserSecrets("82e4fd10-d824-4d2a-afef-8a95e0902d75")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            LocalCSSPJSONPath = Configuration.GetValue<string>("LocalCSSPJSONPath");
            Assert.NotNull(LocalCSSPJSONPath);

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB2");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDBConnString));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

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

            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLoginFileName = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLoginFileName.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLoginFileName.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();
            Services.AddSingleton<IDownloadGzFileService, DownloadGzFileService>();
            Services.AddSingleton<ILocalService, LocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            CSSPDBFilesManagementService = Provider.GetService<ICSSPDBFilesManagementService>();
            Assert.NotNull(CSSPDBFilesManagementService);

            DownloadGzFileService = Provider.GetService<IDownloadGzFileService>();
            Assert.NotNull(DownloadGzFileService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
