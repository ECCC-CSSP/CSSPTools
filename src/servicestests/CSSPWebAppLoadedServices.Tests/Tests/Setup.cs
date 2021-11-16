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
//using CSSPDBPreferenceModels;

//namespace WebAppLoadedServices.Tests
//{
//    public partial class WebAppLoadedServicesTests
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Configuration { get; set; }
//        private IServiceCollection Services { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private string FirstName { get; set; }
//        private string Initial { get; set; }
//        private string LastName { get; set; }
//        private string LoginEmail { get; set; }
//        private string Password { get; set; }
//        private string CSSPDBPreferenceFileName { get; set; }
//        #endregion Properties

//        #region Constructors
//        public WebAppLoadedServicesTests()
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
//                .AddJsonFile("appsettings_cssplocalservicestests.json")
//                .AddUserSecrets("bbf8e532-7685-4d08-a552-9cb1b5482267")
//                .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Configuration);
//            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();

//            /* ---------------------------------------------------------------------------------
//             * using CSSPDBPreference
//             * ---------------------------------------------------------------------------------      
//             */
//            CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");

//            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);

//            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
//            });

//            ///* ---------------------------------------------------------------------------------
//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            FirstName = Configuration.GetValue<string>("FirstName");
//            Assert.NotEmpty(FirstName);

//            Initial = Configuration.GetValue<string>("Initial");
//            Assert.NotEmpty(Initial);

//            LastName = Configuration.GetValue<string>("LastName");
//            Assert.NotEmpty(LastName);

//            LoginEmail = Configuration.GetValue<string>("LoginEmail");
//            Assert.NotEmpty(LoginEmail);

//            Password = Configuration.GetValue<string>("Password");
//            Assert.NotEmpty(Password);

//            return await Task.FromResult(true);
//        }
//        #endregion Functions private
//    }
//}
