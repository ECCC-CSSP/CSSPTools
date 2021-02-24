using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPDBPreferenceModels;
using CSSPDBCommandLogModels;
using LoggedInServices;

namespace CSSPDBCommandLogServices.Tests
{
    public partial class CSSPDBCommandLogServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBCommandLogService CSSPDBCommandLogService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private string CSSPDBCommandLogFileName { get; set; }
        private string CSSPDBPreferenceFileName { get; set; }
        private string Id { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBCommandLogServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbcommandlogservicestests.json")
                .AddUserSecrets("48e29e5a-1f36-42a7-ad09-cc1f51c56c46")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();
            ServiceCollection.AddSingleton<ICSSPDBCommandLogService, CSSPDBCommandLogService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocal
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);
            Assert.True(fiCSSPDBLocal.Exists);

            ServiceCollection.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreferenceFileName);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);
            Assert.True(fiCSSPDBPreference.Exists);

            ServiceCollection.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            ///* ---------------------------------------------------------------------------------
            CSSPDBCommandLogFileName = Configuration.GetValue<string>("CSSPDBCommandLog");
            Assert.NotNull(CSSPDBCommandLogFileName);

            FileInfo fiCSSPDBCommandLogFileName = new FileInfo(CSSPDBCommandLogFileName);
            Assert.True(fiCSSPDBCommandLogFileName.Exists);

            ServiceCollection.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBCommandLogFileName.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            CSSPDBCommandLogService = ServiceProvider.GetService<ICSSPDBCommandLogService>();
            Assert.NotNull(CSSPDBCommandLogService);


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
