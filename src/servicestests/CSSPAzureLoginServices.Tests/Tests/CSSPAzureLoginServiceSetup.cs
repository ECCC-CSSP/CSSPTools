using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPAzureLoginServices.Services;
using CSSPEnums;
using CSSPFileServices;
using CSSPLogServices;
using CSSPSQLiteServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPScrambleServices;
using System.Collections.Generic;

namespace CSSPAzureLoginServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPAzureLoginServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }

        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CSSPAzureLoginServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_CSSPAzureLoginServicestests.json")
               .AddUserSecrets("69cfb7e1-1420-4305-b51c-a64cf27091bb")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["LoginEmail"]);
            Assert.NotNull(Configuration["Password"]);

            CheckRequiredDirectories();

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

            await GetProviderServices();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
