/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using CultureServices.Services;
using LoggedInServices.Services;
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
using UserServices.Models;
using UserServices.Services;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class PolSourceSiteEffectControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private IUserService userService { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ICultureService CultureService { get; set; }
        private IPolSourceSiteEffectService polSourceSiteEffectService { get; set; }
        private IPolSourceSiteEffectController polSourceSiteEffectController { get; set; }
        private UserModel userModel { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceSiteEffectService);
            Assert.NotNull(polSourceSiteEffectController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userModel.Token);

            // testing Get
            string url = "http://localhost:4444/api/" + culture + "/PolSourceSiteEffect";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            List<PolSourceSiteEffect> polSourceSiteEffectList = JsonSerializer.Deserialize<List<PolSourceSiteEffect>>(responseContent);
            Assert.True(polSourceSiteEffectList.Count > 0);

            // testing Get(PolSourceSiteEffectID)
            string urlID = url + "/" + polSourceSiteEffectList[0].PolSourceSiteEffectID;
            response = await httpClient.GetAsync(urlID);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            PolSourceSiteEffect polSourceSiteEffect = JsonSerializer.Deserialize<PolSourceSiteEffect>(responseContent);
            Assert.Equal(polSourceSiteEffectList[0].PolSourceSiteEffectID, polSourceSiteEffect.PolSourceSiteEffectID);

                // testing Post(PolSourceSiteEffect)
                polSourceSiteEffect.PolSourceSiteEffectID = 0;
            string content = JsonSerializer.Serialize<PolSourceSiteEffect>(polSourceSiteEffect);
            HttpContent httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await httpClient.PostAsync(url, httpContent);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            polSourceSiteEffect = JsonSerializer.Deserialize<PolSourceSiteEffect>(responseContent);
            Assert.NotNull(polSourceSiteEffect);

            // testing Put(PolSourceSiteEffect)
            content = JsonSerializer.Serialize<PolSourceSiteEffect>(polSourceSiteEffect);
            httpContent = new StringContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await httpClient.PutAsync(url, httpContent);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            responseContent = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseContent);
            polSourceSiteEffect = JsonSerializer.Deserialize<PolSourceSiteEffect>(responseContent);
            Assert.NotNull(polSourceSiteEffect);

            // testing Delete(PolSourceSiteEffectID)
            urlID = url + "/" + polSourceSiteEffect.PolSourceSiteEffectID;
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
               .AddUserSecrets("f2c8c313-6393-4a24-8eff-c7218ab66ab5")
               .Build();

            Services = new ServiceCollection();

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(connectionStrings.TestDB);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IUserService, UserService>();
            Services.AddSingleton<IPolSourceSiteEffectService, PolSourceSiteEffectService>();
            Services.AddSingleton<IPolSourceSiteEffectController, PolSourceSiteEffectController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            userService = Provider.GetService<IUserService>();
            Assert.NotNull(userService);

            string LoginEmail = Config.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            string Password = Password = Config.GetValue<string>("Password");
            Assert.NotNull(Password);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            var actionUserModel = await userService.Login(loginModel);
            Assert.NotNull(actionUserModel.Value);
            userModel = actionUserModel.Value;

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            await loggedInService.SetLoggedInContactInfo(userModel.Id);
            Assert.NotNull(loggedInService.GetLoggedInContactInfo());

            polSourceSiteEffectService = Provider.GetService<IPolSourceSiteEffectService>();
            Assert.NotNull(polSourceSiteEffectService);

            polSourceSiteEffectController = Provider.GetService<IPolSourceSiteEffectController>();
            Assert.NotNull(polSourceSiteEffectController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
