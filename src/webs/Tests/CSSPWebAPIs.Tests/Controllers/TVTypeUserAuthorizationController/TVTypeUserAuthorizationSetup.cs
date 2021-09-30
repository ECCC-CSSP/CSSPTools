/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPDBServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIs.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using CSSPServerLoggedInServices;
using CSSPHelperModels;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPIs.TVTypeUserAuthorizationManualController.Tests
{
    public partial class CSSPWebAPIsTVTypeUserAuthorizationManualControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext dbTempAzureTest { get; set; }
        private IContactDBService ContactDBService { get; set; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private Contact contact { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPAzureUrl { get; set; }
        private LoginModel loginModel { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWebAPIsTVTypeUserAuthorizationManualControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> TVTypeUserAuthorizationSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
               .Build();

            Services = new ServiceCollection();

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

            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in dbTempAzureTest.TVTypeUserAuthorizations
                                                                         select c).ToList();

            try
            {
                dbTempAzureTest.TVTypeUserAuthorizations.RemoveRange(tvTypeUserAuthorizationList);
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
