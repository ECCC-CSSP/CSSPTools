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

namespace LoggedInServices.Tests
{
    public partial class LoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private string LoginEmail { get; set; }
        private string FirstName1 { get; set; }
        private string Initial1 { get; set; }
        private string LastName1 { get; set; }
        private string LoginEmail2 { get; set; }
        private string FirstName2 { get; set; }
        private string LastName2 { get; set; }
        private string LoginEmail3 { get; set; }
        private string CSSPDBPreferenceFileName { get; set; }
        #endregion Properties

        #region Constructors
        public LoggedInServicesTests()
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
                .AddJsonFile("appsettings_cssploggedinservicestests.json")
                .AddUserSecrets("88fc6657-c426-4796-95bb-ca3d0daf2ff0")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();

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
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreferenceFileName);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);
            Assert.True(fiCSSPDBPreference.Exists);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotEmpty(LoginEmail);

            FirstName1 = Configuration.GetValue<string>("FirstName1");
            Assert.NotEmpty(FirstName1);

            Initial1 = Configuration.GetValue<string>("Initial1");
            Assert.NotEmpty(Initial1);

            LastName1 = Configuration.GetValue<string>("LastName1");
            Assert.NotEmpty(LastName1);

            LoginEmail3 = Configuration.GetValue<string>("LoginEmail3");
            Assert.NotEmpty(LoginEmail3);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
