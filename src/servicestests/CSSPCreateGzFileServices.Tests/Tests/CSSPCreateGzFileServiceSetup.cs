using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CSSPScrambleServices;
using CSSPSQLiteServices;
using CSSPAzureLoginServices.Services;

namespace CSSPCreateGzFileServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPCreateGzFileServiceTests
    {
        #region Variables
        DateTime LastTime = DateTime.Now;
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions private
        private async Task<bool> CSSPCreateGzFileServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspcreategzfileservicestests.json")
               .AddUserSecrets("8d884ed8-5f30-45e9-a33d-c37d20a2323d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["CSSPDB"]);
            Assert.Contains("Server=.", Configuration["CSSPDB"]);
            Assert.NotNull(Configuration["CSSPDBLocal"]);
            Assert.Contains("Test", Configuration["CSSPDBLocal"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.Contains("Test", Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
            Assert.Contains("_test", Configuration["azure_csspjson_backup_uncompress"]);
            Assert.NotNull(Configuration["azure_csspjson_backup"]);
            Assert.Contains("_test", Configuration["azure_csspjson_backup"]);
            Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
            Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
            Assert.Contains("Test", Configuration["CSSPJSONPathLocal"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.Contains("csspwebapis.", Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["LoginEmail"]);
            Assert.NotNull(Configuration["Password"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

            CheckRequiredDirectories();

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
            });

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            await GetProviderServices(culture);

            ClearCommandLogs();
            ClearManageFiles();

            DeleteAllJsonFilesInAzureTestStore();

            DeleteAllJsonFilesLocal();

            DeleteAllBackupFilesLocal();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
