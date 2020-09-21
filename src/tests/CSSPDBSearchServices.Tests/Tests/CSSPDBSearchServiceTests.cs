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
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Linq;
using LocalServices;
using DownloadGzFileServices;
using CSSPDBSearchServices;
using ReadGzFileServices;

namespace CSSPSearchServices.Tests
{
    public class CSSPSearchServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ILocalService LocalService { get; set; }
        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSearchServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSearch_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LocalService);
            Assert.NotNull(CSSPDBSearchService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSearch_Search_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Canada", "canada", "User1", "Charles", "Charles LeBlanc", "New Brunswick",
                "BIG TRACADIE RIVER", "BIG TRACADIE RIVER AT",
                "BIG TRACADIE RIVER AT MURCHY",
                "BIG TRACADIE RIVER AT MURCHY CROSSING",
                "Canada Canada"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count > 0);

                List<string> TermList = SearchText.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
                {
                    foreach (string term in TermList)
                    {
                        Assert.Contains(term.ToLower(), tvItemLanguage.TVText.ToLower());
                    }
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSearch_Search_Under_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Caraquet"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 10 /* 10 = Newfoundland and Labrador */);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count == 0);
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSearch_Search_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "", "lsiefjlsiejfilsjfilj", "ljliefjlijsilejflsiejf"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 0);
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
                List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionRes.Result).Value;
                Assert.NotNull(tvItemLanguageList);
                Assert.True(tvItemLanguageList.Count == 0);
            }

        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbsearchservicestests.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IEnums, Enums>();
            ServiceCollection.AddSingleton<ILocalService, LocalService>();
            ServiceCollection.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();

            string CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLogin);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLogin);

            ServiceCollection.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            ServiceCollection.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearchFileName);

            FileInfo fiCSSPDBSearchFileName = new FileInfo(CSSPDBSearchFileName);
            Assert.True(fiCSSPDBSearchFileName.Exists);

            ServiceCollection.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearchFileName.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            LocalService = ServiceProvider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            CSSPDBSearchService = ServiceProvider.GetService<ICSSPDBSearchService>();
            Assert.NotNull(CSSPDBSearchService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
