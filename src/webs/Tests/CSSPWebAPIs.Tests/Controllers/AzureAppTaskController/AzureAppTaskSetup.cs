/*
 * manually edited
 *
 */

using CSSPAzureAppTaskServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using CSSPHelperModels;
using CSSPServerLoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CSSPWebAPIs.AppTaskModelController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsAppTaskControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext dbTempAzureTest { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IAzureAppTaskService AzureAppTaskService { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPAzureUrl { get; set; }
        private LoginModel loginModel { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebAPIsAppTaskControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> AzureAppTaskSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            string AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(AzureCSSPDB);

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(AzureCSSPDB);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
            //Services.AddSingleton<ILoginModelService, LoginModelService>();
            //Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<IAzureAppTaskService, AzureAppTaskService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotNull(LoginEmail);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

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
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
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
        #endregion Functions private

    }
}
