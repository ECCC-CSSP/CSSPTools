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

namespace CSSPServices.Tests
{
    public class CSSPDBSearchServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private CSSPDBSearchContext dbSearch { get; set; }
        private FileInfo fiCSSPDBSearch { get; set; }
        private FileInfo fiCSSPDBFilesManagement { get; set; }
        private string CSSPAzureUrl { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBSearchServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(LoggedInService);
            Assert.NotNull(CSSPDBSearchService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Good_Test(string culture)
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
                    foreach(string term in TermList)
                    {
                        Assert.Contains(term, tvItemLanguage.TVText);
                    }
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBSearch_Search_Under_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "Canada", "canada"
            };

            foreach (string SearchText in SearchTermList)
            {
                var actionRes = await CSSPDBSearchService.Search(SearchText, 7 /* 7 = New Brunswick */);
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
        public async Task CSSPDBSearch_Search_NotFound_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> SearchTermList = new List<string>()
            {
                "", "             ", "lsiefjlsiejfilsjfilj", "ljliefjlijsilejflsiejf"
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
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IEnums, Enums>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();
            ServiceCollection.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();
            ServiceCollection.AddSingleton<ICSSPFileService, CSSPFileService>();
            ServiceCollection.AddSingleton<IDownloadGzFileService, DownloadGzFileService>();
            ServiceCollection.AddSingleton<IReadGzFileService, ReadGzFileService>();
            ServiceCollection.AddSingleton<ITVItemService, TVItemService>();
            ServiceCollection.AddSingleton<ITVItemLanguageService, TVItemLanguageService>();

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB2");
            Assert.NotNull(CSSPDBConnString);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            ServiceCollection.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            ServiceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(CSSPDBConnString));

            ServiceCollection.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // doing CSSPDBSearch
            string CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearch);

            fiCSSPDBSearch = new FileInfo(CSSPDBSearch);

            ServiceCollection.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            // doing CSSPDBFilesManagement
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBSearch);

            fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagement);

            ServiceCollection.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            if (contact != null)
            {
                Assert.True(true);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                // trying to login
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    Assert.True(false, ((int)response.StatusCode).ToString());
                }

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInContactInfo(contact.Id);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            LoggedInService.RunningOn = RunningOnEnum.Local;
            Assert.Equal(RunningOnEnum.Local, LoggedInService.RunningOn);

            CSSPDBSearchService = ServiceProvider.GetService<ICSSPDBSearchService>();
            Assert.NotNull(CSSPDBSearchService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
