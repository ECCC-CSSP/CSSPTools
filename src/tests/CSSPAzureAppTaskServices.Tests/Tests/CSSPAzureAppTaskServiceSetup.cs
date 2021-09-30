/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPServerLoggedInServices;
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
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
        private IAzureAppTaskService AzureAppTaskService { get; set; }
        private CSSPDBContext dbTempAzureTest { get; set; }
        //private string LoginEmail { get; set; }
        //private string Password { get; set; }
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
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspAzureAppTaskservicestests.json")
               .AddUserSecrets("8d884ed8-5f30-45e9-a33d-c37d20a2323d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["AzureCSSPDB"]);
            Assert.Contains("CSSPTemporaryDBTest", Configuration["AzureCSSPDB"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.Contains("localhost:", Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["LoginEmail"]);
            Assert.NotNull(Configuration["Password"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
            Services.AddSingleton<IEnums, Enums>();

            Services.AddSingleton<IAzureAppTaskService, AzureAppTaskService>();

            /* ---------------------------------------------------------------------------------
             * using AzureCSSPDB
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["AzureCSSPDB"]);
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPServerLoggedInService = Provider.GetService<ICSSPServerLoggedInService>();
            Assert.NotNull(CSSPServerLoggedInService);

            await CSSPServerLoggedInService.SetLoggedInContactInfo(Configuration["LoginEmail"]);
            Assert.NotNull(CSSPServerLoggedInService.LoggedInContactInfo);

            //config.AzureStore = CSSPServerLoggedInService.Descramble(config.AzureStore);

            AzureAppTaskService = Provider.GetService<IAzureAppTaskService>();
            Assert.NotNull(AzureAppTaskService);

            loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"]
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/auth/token", contentData).Result;
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
