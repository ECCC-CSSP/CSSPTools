/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
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

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class VPResultControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IVPResultDBService vpResultDBService { get; set; }
        private IVPResultController vpResultController { get; set; }
        private Contact contact { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPResultController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LoggedInService);
            Assert.NotNull(vpResultDBService);
            Assert.NotNull(vpResultController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task VPResultController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                // testing Get
                string url = $"{ CSSPAzureUrl }api/{ culture }/VPResult";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<VPResult> vpResultList = JsonSerializer.Deserialize<List<VPResult>>(responseContent);
                Assert.True(vpResultList.Count > 0);

                // testing Get(VPResultID)
                string urlID = url + "/" + vpResultList[0].VPResultID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                VPResult vpResult = JsonSerializer.Deserialize<VPResult>(responseContent);
                Assert.Equal(vpResultList[0].VPResultID, vpResult.VPResultID);

                // testing Post(VPResult)
                vpResult.VPResultID = 0;
                string content = JsonSerializer.Serialize<VPResult>(vpResult);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                vpResult = JsonSerializer.Deserialize<VPResult>(responseContent);
                Assert.NotNull(vpResult);

                // testing Put(VPResult)
                content = JsonSerializer.Serialize<VPResult>(vpResult);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                vpResult = JsonSerializer.Deserialize<VPResult>(responseContent);
                Assert.NotNull(vpResult);

                // testing Delete(VPResultID)
                urlID = url + "/" + vpResult.VPResultID;
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

            CSSPAzureUrl = Config.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            string TestDB = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddSingleton<IConfiguration>(Config);

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
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<IVPResultDBService, VPResultDBService>();
            Services.AddSingleton<IVPResultController, VPResultController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactDBService = Provider.GetService<IContactDBService>();
            Assert.NotNull(ContactDBService);

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

            vpResultDBService = Provider.GetService<IVPResultDBService>();
            Assert.NotNull(vpResultDBService);

            vpResultController = Provider.GetService<IVPResultController>();
            Assert.NotNull(vpResultController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
