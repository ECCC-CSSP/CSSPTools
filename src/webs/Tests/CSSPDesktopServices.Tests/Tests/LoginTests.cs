using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CSSPDesktopServices.Tests
{
    public class LoginTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Login_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            string Password = Configuration.GetValue<string>("Password");

            bool retBool = await CSSPDesktopService.Login(LoginEmail, Password);
            Assert.True(retBool);
        }
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task Scramble_Descramble_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    string ExtreamChar = "";
        //    for (int i = 0; i < 40; i++)
        //    {
        //        ExtreamChar += ((char)254).ToString() + ((char)1).ToString();
        //    }
        //    List<string> testStrList = new List<string>()
        //    {
        //        "abc", "XYZ", "laisjefliahefilsafeailhslefilh", "hsefl834", "lsehfhi!!@#$%", "18764517836", "lsjfijslfj'lsefjlsj`lsjeflijsef", "abc       XYZ", ExtreamChar
        //    };

        //    foreach (string s in testStrList)
        //    {
        //        string retStr = CSSPDesktopService.Scramble(s);
        //        string retStr2 = CSSPDesktopService.Descramble(retStr);
        //        Assert.Equal(s, retStr2);
        //    }
        //}
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdesktopservices.json")
               .AddUserSecrets("6277018e-7198-41f3-9906-f8a6ccfa30e5")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagement);

            FileInfo fiCSSPDBFileManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFileManagement.FullName }");
            });

            string CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLogin);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLogin);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
            Assert.NotNull(CSSPDesktopService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            CSSPDesktopService.IsEnglish = true;

            if (!CSSPDesktopService.ReadConfiguration().GetAwaiter().GetResult()) return false;

            // should remove the line below to test with Azure app server
            CSSPDesktopService.CSSPAzureUrl = "https://localhost:44342/";

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
