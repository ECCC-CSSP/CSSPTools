/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsTestsController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPDBServices;
using CSSPWebAPIs.Controllers;
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using LoggedInServices;
using CSSPHelperModels;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class AppTaskLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAppTaskLanguageDBService AppTaskLanguageDBService { get; set; }
        private Contact contact { get; set; }
        private string CSSPAzureUrl { get; set; }
        private IAppTaskLanguageController AppTaskLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LoggedInService);
            Assert.NotNull(AppTaskLanguageDBService);
            Assert.NotNull(AppTaskLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLanguageController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                // testing Get
                string url = $"{ CSSPAzureUrl }api/{ culture }/AppTaskLanguage";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<AppTaskLanguage> appTaskLanguageList = JsonSerializer.Deserialize<List<AppTaskLanguage>>(responseContent);
                Assert.True(appTaskLanguageList.Count > 0);

                // testing Get(AppTaskLanguageID)
                string urlID = url + "/" + appTaskLanguageList[0].AppTaskLanguageID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                AppTaskLanguage appTaskLanguage = JsonSerializer.Deserialize<AppTaskLanguage>(responseContent);
                Assert.Equal(appTaskLanguageList[0].AppTaskLanguageID, appTaskLanguage.AppTaskLanguageID);

                // testing Post(AppTaskLanguage)
                appTaskLanguage.AppTaskLanguageID = 0;
                string content = JsonSerializer.Serialize<AppTaskLanguage>(appTaskLanguage);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                appTaskLanguage = JsonSerializer.Deserialize<AppTaskLanguage>(responseContent);
                Assert.NotNull(appTaskLanguage);

                // testing Put(AppTaskLanguage)
                content = JsonSerializer.Serialize<AppTaskLanguage>(appTaskLanguage);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                appTaskLanguage = JsonSerializer.Deserialize<AppTaskLanguage>(responseContent);
                Assert.NotNull(appTaskLanguage);

                // testing Delete(AppTaskLanguageID)
                urlID = url + "/" + appTaskLanguage.AppTaskLanguageID;
                response = await httpClient.DeleteAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                bool retBool = JsonSerializer.Deserialize<bool>(responseContent);
                Assert.True(retBool);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            CSSPAzureUrl = Config.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            string TestDB = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDB);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<IAppTaskLanguageDBService, AppTaskLanguageDBService>();
            Services.AddSingleton<IAppTaskLanguageController, AppTaskLanguageController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Config.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ CSSPAzureUrl }api/{ culture}/Auth/Token";

                string content = JsonSerializer.Serialize<LoginModel>(loginModel);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                contact = JsonSerializer.Deserialize<Contact>(responseContent);
                Assert.NotNull(contact);
                Assert.NotEmpty(contact.Token);
            }

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInContactInfo(contact.Id);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            AppTaskLanguageDBService = Provider.GetService<IAppTaskLanguageDBService>();
            Assert.NotNull(AppTaskLanguageDBService);

            AppTaskLanguageController = Provider.GetService<IAppTaskLanguageController>();
            Assert.NotNull(AppTaskLanguageController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
