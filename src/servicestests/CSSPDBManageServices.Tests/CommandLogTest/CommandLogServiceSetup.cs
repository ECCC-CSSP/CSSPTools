using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPSQLiteServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    [Collection("Sequential")]
    public partial class CommandLogServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private ICommandLogService CommandLogService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        public CommandLogServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CommandLogServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbmanageservicestests.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["CSSPDBLocal"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICommandLogService, CommandLogService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

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

            await GetProviderServices(culture);

            ClearCommandLogs();
            ClearManageFiles();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
