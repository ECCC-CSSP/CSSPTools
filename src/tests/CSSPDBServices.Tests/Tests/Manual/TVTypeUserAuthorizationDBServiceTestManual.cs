/* 
 * Manually edited
 */ 

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LoggedInServices;
using CSSPDBPreferenceModels;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class TVTypeUserAuthorizationDBServiceManualTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private TVTypeUserAuthorization tvTypeUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationDBServiceManualTests()
        {

        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationServiceManual_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(TVTypeUserAuthorizationDBService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationServiceManual_GetTVTypeUserAuthorizationWithContactTVItemID_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationWithContactTVItemID(2);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorization.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorization.Result).Value);
            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorization.Result).Value;
            Assert.NotNull(TVTypeUserAuthorizationList);
            Assert.True(TVTypeUserAuthorizationList.Count > 0);
        }
        #endregion Tests


        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("a79b4a81-ba75-4dfc-8d95-46259f73f055")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVTypeUserAuthorizationDBService, TVTypeUserAuthorizationDBService>();

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
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

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

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(LoginEmail));

            TVTypeUserAuthorizationDBService = Provider.GetService<ITVTypeUserAuthorizationDBService>();
            Assert.NotNull(TVTypeUserAuthorizationDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
