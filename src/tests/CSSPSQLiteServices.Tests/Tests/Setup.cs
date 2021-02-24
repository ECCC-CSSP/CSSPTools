using CSSPEnums;
using CSSPDBModels;
using CSSPSQLiteServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CSSPDBCommandLogModels;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using CSSPDBSearchModels;

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private CSSPDBContext dbLocal { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBCommandLog { get; set; }
        private FileInfo fiCSSPDBPreference { get; set; }
        private FileInfo fiCSSPDBFilesManagement { get; set; }
        private FileInfo fiCSSPDBSearch { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspsqliteservicestests.json")
               .AddUserSecrets("bffe2152-6c6e-4e4f-944e-dce6d07efd1e")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

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
             * using CSSPDBLocal
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBSearch
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearch);

            fiCSSPDBSearch = new FileInfo(CSSPDBSearch);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBCommandLog
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBCommandLog = Configuration.GetValue<string>("CSSPDBCommandLog");
            Assert.NotNull(CSSPDBCommandLog);

            fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLog);

            Services.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBCommandLog.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFilesManagement
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagement);

            fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreference);

            fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
