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
using CSSPScrambleServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemDBServiceManualTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemDBService TVItemDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private TVItem tvItem { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemDBServiceManualTests()
        {

        }
        #endregion Constructors

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemServiceManual_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(TVItemDBService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemServiceManual_GetTVItemRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionTVItem = await TVItemDBService.GetTVItemRoot();
            Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
            TVItem TVItem = (TVItem)((OkObjectResult)actionTVItem.Result).Value;
            Assert.NotNull(TVItem);
            Assert.True(TVItem.TVItemID > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemServiceManual_GetTVItemStartDateList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionTVItem = await TVItemDBService.GetTVItemStartDateList(2018, 5, 26);
            Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
            List<TVItem> TVItemList = (List<TVItem>)((OkObjectResult)actionTVItem.Result).Value;
            Assert.NotNull(TVItemList);
            Assert.True(TVItemList[0].TVItemID > 0);
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();

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

            TVItemDBService = Provider.GetService<ITVItemDBService>();
            Assert.NotNull(TVItemDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
