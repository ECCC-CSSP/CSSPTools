//using CSSPDBModels;
//using CSSPCultureServices.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;
//using CSSPEnums;
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Text;
//using System.Linq;
//using CSSPDBSearchServices;
//using CSSPHelperModels;
//using CSSPDBPreferenceModels;
//using CSSPDBSearchModels;
//using LoggedInServices;
//using CSSPCultureServices.Resources;
//using CSSPScrambleServices;

//namespace CSSPSearchServices.Tests
//{
//    public partial class CSSPSearchServiceTests
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Configuration { get; set; }
//        private IServiceCollection Services { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private ILoggedInService LoggedInService { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
//        #endregion Properties

//        #region Constructors
//        public CSSPSearchServiceTests()
//        {
//        }
//        #endregion Constructors

//        #region Functions public
//        #endregion Functions public

//        #region Functions private
//        private async Task<bool> Setup(string culture)
//        {
//            Configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//                .AddJsonFile("appsettings_csspdbsearchservicestests.json")
//                .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Configuration);
//            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
//            Services.AddSingleton<IEnums, Enums>();
//            Services.AddSingleton<IScrambleService, ScrambleService>();
//            Services.AddSingleton<ILoggedInService, LoggedInService>();
//            Services.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBPreference
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
//            Assert.NotNull(CSSPDBPreferenceFileName);

//            FileInfo fiCSSPDBPreferenceFileName = new FileInfo(CSSPDBPreferenceFileName);
//            Assert.True(fiCSSPDBPreferenceFileName.Exists);

//            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBPreferenceFileName.FullName }");
//            });

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBSearch
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");
//            Assert.NotNull(CSSPDBSearchFileName);

//            FileInfo fiCSSPDBSearchFileName = new FileInfo(CSSPDBSearchFileName);
//            Assert.True(fiCSSPDBSearchFileName.Exists);

//            Services.AddDbContext<CSSPDBSearchContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBSearchFileName.FullName }");
//            });

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            LoggedInService = Provider.GetService<ILoggedInService>();
//            Assert.NotNull(LoggedInService);

//            await LoggedInService.SetLoggedInLocalContactInfo();
//            Assert.NotNull(LoggedInService.LoggedInContactInfo);
//            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            CSSPDBSearchService = Provider.GetService<ICSSPDBSearchService>();
//            Assert.NotNull(CSSPDBSearchService);

//            return await Task.FromResult(true);
//        }
//        #endregion Functions private
//    }
//}
