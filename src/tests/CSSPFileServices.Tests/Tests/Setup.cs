using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPScrambleServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
//using WebAppLoadedServices;

namespace FileServices.Tests
{
    [Collection("Sequential")]

    public partial class FileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private IFileService FileService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBContext db { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPFilesPath { get; set; }
        private string CSSPTempFilesPath { get; set; }
        private string CSSPAzureUrl { get; set; }
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
               .AddJsonFile("appsettings_csspFileServicestests.json")
               .AddUserSecrets("82e4fd10-d824-4d2a-afef-8a95e0902d75")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(CSSPJSONPath);

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(CSSPFilesPath);

            CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
            Assert.NotNull(CSSPTempFilesPath);

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);
            Assert.True(fiCSSPDBLocal.Exists);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            FileInfo fiCSSPDBManageFileName = new FileInfo(CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManageFileName.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<IFileService, FileService>();
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

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            FileService = Provider.GetService<IFileService>();
            Assert.NotNull(FileService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
