/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPIsLocal.Controllers;
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

namespace CSSPWebAPIsLocal.Tests.Controllers
{
    public partial class MikeScenarioControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private IContactService ContactService { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IMikeScenarioService mikeScenarioService { get; set; }
        private IMikeScenarioController mikeScenarioController { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeScenarioService);
            Assert.NotNull(mikeScenarioController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeScenarioController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            // testing Get
            string url = "https://localhost:4447/api/" + culture + "/MikeScenario";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            List<MikeScenario> mikeScenarioList = JsonSerializer.Deserialize<List<MikeScenario>>(responseContent);
            Assert.True(mikeScenarioList.Count > 0);

            // testing Get(MikeScenarioID)
            string urlID = url + "/" + mikeScenarioList[0].MikeScenarioID;
            response = await httpClient.GetAsync(urlID);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            MikeScenario mikeScenario = JsonSerializer.Deserialize<MikeScenario>(responseContent);
            Assert.Equal(mikeScenarioList[0].MikeScenarioID, mikeScenario.MikeScenarioID);

            // testing Post(MikeScenario)
            mikeScenario.MikeScenarioID = 0;
            string content = JsonSerializer.Serialize<MikeScenario>(mikeScenario);
            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await httpClient.PostAsync(url, httpContent);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            mikeScenario = JsonSerializer.Deserialize<MikeScenario>(responseContent);
            Assert.NotNull(mikeScenario);

            // testing Put(MikeScenario)
            content = JsonSerializer.Serialize<MikeScenario>(mikeScenario);
            httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await httpClient.PutAsync(url, httpContent);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            mikeScenario = JsonSerializer.Deserialize<MikeScenario>(responseContent);
            Assert.NotNull(mikeScenario);

            // testing Delete(MikeScenarioID)
            urlID = url + "/" + mikeScenario.MikeScenarioID;
            response = await httpClient.DeleteAsync(urlID);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            bool retBool = JsonSerializer.Deserialize<bool>(responseContent);
            Assert.True(retBool);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("9d65c001-b7bc-4922-a0fc-1558b9ef927e")
               .Build();

            Services = new ServiceCollection();

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
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
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<IMikeScenarioService, MikeScenarioService>();
            Services.AddSingleton<IMikeScenarioController, MikeScenarioController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ContactService = Provider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Config.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            var actionContact = await ContactService.Login(loginModel);
            Assert.NotNull(actionContact.Value);
            contact = actionContact.Value;

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            await loggedInService.SetLoggedInContactInfo(contact.Id);
            Assert.NotNull(loggedInService.LoggedInContactInfo);

            mikeScenarioService = Provider.GetService<IMikeScenarioService>();
            Assert.NotNull(mikeScenarioService);

            mikeScenarioController = Provider.GetService<IMikeScenarioController>();
            Assert.NotNull(mikeScenarioController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
