/*
 * manually edited
 *
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using CSSPHelperModels;
using CSSPHelperServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPWebAPIs.AuthController.Tests
{
    public partial class CSSPWebAPIsAuthControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ITVItemDBService TVItemDBService { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPAzureUrl { get; set; }
        private LoginModel loginModel { get; set; }

        #endregion Properties

        #region Constructors
        public CSSPWebAPIsAuthControllerTests()
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
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            /* ---------------------------------------------------------------------------------
             * CSSPDBContext
             * ---------------------------------------------------------------------------------      
             */
            string DBConnString = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(DBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(DBConnString);
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);
            Assert.True(fiCSSPDBLocal.Exists);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactDBService = Provider.GetService<IContactDBService>();
            Assert.NotNull(ContactDBService);

            TVItemDBService = Provider.GetService<ITVItemDBService>();
            Assert.NotNull(TVItemDBService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                Assert.True((int)response.StatusCode == 200);

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
