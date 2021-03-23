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
////using LocalServices;
//using CSSPEnums;
//using PreferenceServices;
//using CSSPDBPreferenceModels;
//using CSSPScrambleServices;
//using LoggedInServices;

//namespace PreferenceServices.Tests
//{
//    public partial class PreferenceServicesTests
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Configuration { get; set; }
//        private IServiceCollection Services { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private IScrambleService ScrambleService { get; set; }
//        private ILoggedInService LoggedInService { get; set; }
//        private IPreferenceService PreferenceService { get; set; }
//        private CSSPDBPreferenceContext dbPreference { get; set; }
//        #endregion Properties

//        #region Constructors
//        public PreferenceServicesTests()
//        {
//        }
//        #endregion Constructors

//        #region Tests
//        #endregion Tests

//        #region Functions private
//        private async Task<bool> Setup(string culture)
//        {
//            Configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//                .AddJsonFile("appsettings_csspdbpreferenceservicestests.json")
//                .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Configuration);
//            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
//            Services.AddSingleton<IScrambleService, ScrambleService>();
//            Services.AddSingleton<ILoggedInService, LoggedInService>();
//            Services.AddSingleton<IPreferenceService, PreferenceService>();

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBPreference
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
//            Assert.NotNull(CSSPDBPreferenceFileName);

//            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);
//            Assert.True(fiCSSPDBPreference.Exists);

//            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
//            });

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            ScrambleService = Provider.GetService<IScrambleService>();
//            Assert.NotNull(ScrambleService);

//            PreferenceService = Provider.GetService<IPreferenceService>();
//            Assert.NotNull(PreferenceService);

//            dbPreference = Provider.GetService<CSSPDBPreferenceContext>();
//            Assert.NotNull(dbPreference);

//            LoggedInService = Provider.GetService<ILoggedInService>();
//            Assert.NotNull(LoggedInService);

//            await LoggedInService.SetLoggedInLocalContactInfo();
//            Assert.NotNull(LoggedInService.LoggedInContactInfo);
//            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

//            return await Task.FromResult(true);
//        }
//        #endregion Functions private
//    }
//}
