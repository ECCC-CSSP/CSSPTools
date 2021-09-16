/* 
 *  Manually Edited
 *  
 */

using CSSPAzureAppTaskServices.Models;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using CSSPHelperModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace CSSPAzureAppTaskServices.Tests
{
    public partial class AzureAppTaskServiceTest
    {
        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAzureAppTaskService AzureAppTaskService { get; set; }
        private CSSPAzureAppTaskServiceConfigModel config { get; set; }
        private CSSPDBContext dbTempAzureTest { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private LoginModel loginModel { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public AzureAppTaskServiceTest()
        {

        }
        #endregion Constructors

        private async Task<bool> CSSPAzureAppTaskServiceSetup(string culture)
        {
            config = new CSSPAzureAppTaskServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspAzureAppTaskservicestests.json")
               .AddUserSecrets("8d884ed8-5f30-45e9-a33d-c37d20a2323d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            // --------- Reading Configuration Variables
            // -----------------------------------------
            config.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(config.APISecret);

            config.AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(config.AzureCSSPDB);
            config.AzureCSSPDB = config.AzureCSSPDB.Replace("Initial Catalog=CSSPTemporaryDB;", "Initial Catalog=CSSPTemporaryDBTest;");
            Assert.Contains("CSSPTemporaryDBTest", config.AzureCSSPDB);

            config.AzureStore = Configuration.GetValue<string>("AzureStore");
            Assert.NotNull(config.AzureStore);

            config.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(config.CSSPAzureUrl);
            Assert.Contains("localhost:", config.CSSPAzureUrl);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();

            Services.AddSingleton<IAzureAppTaskService, AzureAppTaskService>();

            /* ---------------------------------------------------------------------------------
             * using AzureCSSPDB
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(config.AzureCSSPDB);
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInContactInfo(LoginEmail);
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            config.AzureStore = LoggedInService.Descramble(config.AzureStore);

            AzureAppTaskService = Provider.GetService<IAzureAppTaskService>();
            Assert.NotNull(AzureAppTaskService);

            var res = await AzureAppTaskService.FillConfigModel(config);
            Assert.True(res);

            loginModel = new LoginModel()
            {
                LoginEmail = LoginEmail,
                Password = Password
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ config.CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                Assert.True((int)response.StatusCode == 200);

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }

            dbTempAzureTest = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(dbTempAzureTest);

            AzureAppTaskService = Provider.GetService<IAzureAppTaskService>();
            Assert.NotNull(AzureAppTaskService);

            List<AppTask> appTaskToDeleteList = (from c in dbTempAzureTest.AppTasks
                                                 select c).ToList();

            try
            {
                dbTempAzureTest.AppTasks.RemoveRange(appTaskToDeleteList);
                dbTempAzureTest.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all AppTasks from db. Ex: { ex.Message }");
            }

            return await Task.FromResult(true);
        }
    }
}
