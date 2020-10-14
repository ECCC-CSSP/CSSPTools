using CSSPModels;
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
using LocalServices;
using CSSPDBLoginServices;
using CSSPEnums;

namespace PreferenceServices.Tests
{
    public partial class PreferenceServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IPreferenceService PreferenceService { get; set; }
        private ILocalService LocalService { get; set; }
        private string CSSPDBLoginFileName { get; set; }
        #endregion Properties

        #region Constructors
        public PreferenceServicesTests()
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
                .AddJsonFile("appsettings_csspdbLoginservicestests.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IEnums, Enums>();
            ServiceCollection.AddSingleton<ILocalService, LocalService>();
            ServiceCollection.AddSingleton<IPreferenceService, PreferenceService>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);
            Assert.True(fiCSSPDBLogin.Exists);

            ServiceCollection.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ServiceCollection.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            PreferenceService = ServiceProvider.GetService<IPreferenceService>();
            Assert.NotNull(PreferenceService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
