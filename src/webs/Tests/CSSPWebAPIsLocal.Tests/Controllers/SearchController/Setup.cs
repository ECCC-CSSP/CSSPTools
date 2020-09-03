/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
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

namespace SearchControllers.Tests
{
    public partial class SearchControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private IAspNetUserService AspNetUserService { get; set; }
        private IContactService ContactService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPLocalUrl { get; set; }
        private LoginModel loginModel { get; set; }
        #endregion Properties

        #region Constructors
        public SearchControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void LoginTest()
        {
            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            Password = Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            Assert.NotNull(LoginEmail);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPLocalUrl }api/en-CA/auth/tokenlocal", contentData).Result;
                Assert.True((int)response.StatusCode == 200);

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("9d65c001-b7bc-4922-a0fc-1558b9ef927e")
               .Build();

            Services = new ServiceCollection();

            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearchFileName);

            string DBConnStr = Configuration.GetValue<string>("CSSPDB2");
            Assert.NotNull(DBConnStr);

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(DBConnStr);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(DBConnStr);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnStr));

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IDownloadGzFileService, DownloadGzFileService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ITVItemService, TVItemService>();
            Services.AddSingleton<ITVItemLanguageService, TVItemLanguageService>();
            Services.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPDBSearchService = Provider.GetService<ICSSPDBSearchService>();
            Assert.NotNull(CSSPDBSearchService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
