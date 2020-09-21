/*
 * manually edited
 *
 */

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
using CSSPWebAPIsLocal.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using LocalServices;
using CSSPDBSearchServices;

namespace CSSPWebAPIsLocal.SearchController.Tests
{
    public partial class CSSPWebAPIsLocalSearchControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ILocalService LocalService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
        private string LocalUrl { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebAPIsLocalSearchControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapislocaltests.json")
               .AddUserSecrets("61f396b6-8b79-4328-a2b7-a07921135f96")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            LocalUrl = Configuration.GetValue<string>("LocalUrl");
            Assert.NotNull(LocalUrl);

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocal 
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearchFileName);

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLoginInMemory
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ///* ---------------------------------------------------------------------------------
            // * using CSSPDBCommandLog
            // * ---------------------------------------------------------------------------------      
            // */
            //string CSSPDBCommandLogFileName = Configuration.GetValue<string>("CSSPDBCommandLog");

            //FileInfo fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLogFileName);

            //Services.AddDbContext<CSSPDBCommandLogContext>(options =>
            //{
            //    options.UseSqlite($"Data Source={ fiCSSPDBCommandLog.FullName }");
            //});

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();

            CSSPDBSearchService = Provider.GetService<ICSSPDBSearchService>();
            Assert.NotNull(CSSPDBSearchService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
