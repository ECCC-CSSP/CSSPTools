using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLogServices.Models;
using CSSPReadGzFileServices.Models;
using CSSPFileServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPFileServices.Models;

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
        private IManageFileService ManageFileService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPFileService CSSPFileService { get; set; }
        private CSSPReadGzFileServiceConfigModel configReadGzfile { get; set; }
        private CSSPFileServiceConfigModel configFileService { get; set; }
        private CSSPLogServiceConfigModel configLogService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> ReadGzFileServiceSetup(string culture)
        {
            configReadGzfile = new CSSPReadGzFileServiceConfigModel();
            configFileService = new CSSPFileServiceConfigModel();
            configLogService = new CSSPLogServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspreadgzfileservicestests.json")
               .AddUserSecrets("7f7f83c1-bbc1-4805-9cae-163ec6952d6d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            // --------- Reading Configuration Variables
            // --------- configReadGzfile
            // --------------------------------
            configReadGzfile.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(configReadGzfile.APISecret);

            configReadGzfile.AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(configReadGzfile.AzureCSSPDB);

            configReadGzfile.AzureStore = Configuration.GetValue<string>("AzureStore");
            Assert.NotNull(configReadGzfile.AzureStore);

            configReadGzfile.AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(configReadGzfile.AzureStoreCSSPJSONPath);

            configReadGzfile.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(configReadGzfile.CSSPAzureUrl);
            Assert.Contains("csspwebapis.", configReadGzfile.CSSPAzureUrl);

            configReadGzfile.CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            Assert.NotNull(configReadGzfile.CSSPLocalUrl);
            Assert.Contains("localhost:", configReadGzfile.CSSPLocalUrl);

            configReadGzfile.CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(configReadGzfile.CSSPDB);

            configReadGzfile.CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(configReadGzfile.CSSPDBLocal);
            Assert.DoesNotContain("_test", configReadGzfile.CSSPDBLocal);

            configReadGzfile.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(configReadGzfile.CSSPDBManage);
            Assert.DoesNotContain("_test", configReadGzfile.CSSPDBManage);

            configReadGzfile.CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(configReadGzfile.CSSPJSONPath);

            configReadGzfile.CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(configReadGzfile.CSSPJSONPathLocal);

            configReadGzfile.CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(configReadGzfile.CSSPFilesPath);


            // --------- Reading Configuration Variables
            // --------- configLogService
            // --------------------------------
            configLogService.ComputerName = Configuration.GetValue<string>("ComputerName");
            Assert.NotNull(configLogService.ComputerName);

            configLogService.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(configLogService.CSSPDBManage);
            Assert.DoesNotContain("_test", configLogService.CSSPDBManage);


            // --------- Reading Configuration Variables
            // --------- configFileService
            // --------------------------------
            configFileService.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(configFileService.APISecret);

            configFileService.AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(configFileService.AzureCSSPDB);

            configFileService.AzureStore = Configuration.GetValue<string>("AzureStore");
            Assert.NotNull(configFileService.AzureStore);

            configFileService.AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            Assert.NotNull(configFileService.AzureStoreCSSPFilesPath);

            configFileService.AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(configFileService.AzureStoreCSSPJSONPath);

            configFileService.AzureStoreCSSPWebAPIsPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsPath");
            Assert.NotNull(configFileService.AzureStoreCSSPWebAPIsPath);

            configFileService.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(configFileService.CSSPAzureUrl);
            Assert.Contains("csspwebapis.", configFileService.CSSPAzureUrl);

            configFileService.CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(configFileService.CSSPDB);

            configFileService.CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(configFileService.CSSPDBLocal);

            configFileService.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(configFileService.CSSPDBManage);
            Assert.DoesNotContain("_test", configFileService.CSSPDBManage);

            configFileService.CSSPDesktopPath = Configuration.GetValue<string>("CSSPDesktopPath");
            Assert.NotNull(configFileService.CSSPDesktopPath);

            configFileService.CSSPDatabasesPath = Configuration.GetValue<string>("CSSPDatabasesPath");
            Assert.NotNull(configFileService.CSSPDatabasesPath);

            configFileService.CSSPWebAPIsPath = Configuration.GetValue<string>("CSSPWebAPIsPath");
            Assert.NotNull(configFileService.CSSPWebAPIsPath);

            configFileService.CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(configFileService.CSSPJSONPath);

            configFileService.CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(configFileService.CSSPFilesPath);

            configFileService.CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
            Assert.NotNull(configFileService.CSSPTempFilesPath);

            configFileService.CSSPOtherFilesPath = Configuration.GetValue<string>("CSSPOtherFilesPath");
            Assert.NotNull(configFileService.CSSPOtherFilesPath);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();

            /* ---------------------------------------------------------------------------------
             * CSSPDBContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(configReadGzfile.CSSPDB);
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */

            FileInfo fiCSSPDBLocalFileName = new FileInfo(configReadGzfile.CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocalFileName.FullName }");
            });


            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */

            FileInfo fiCSSPDBManageFileName = new FileInfo(configReadGzfile.CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManageFileName.FullName }");
            });


            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            CSSPLogService.FillConfigModel(configLogService);

            CSSPFileService = Provider.GetService<ICSSPFileService>();
            Assert.NotNull(CSSPFileService);

            configFileService.AzureStore = LoggedInService.Descramble(configFileService.AzureStore);

            await CSSPFileService.FillConfigModel(configFileService);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            configReadGzfile.AzureStore = LoggedInService.Descramble(configReadGzfile.AzureStore);

            await ReadGzFileService.FillConfigModel(configReadGzfile);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
