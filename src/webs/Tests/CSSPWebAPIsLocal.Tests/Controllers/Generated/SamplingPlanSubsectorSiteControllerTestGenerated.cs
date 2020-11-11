/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPDBLocalServices;
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
using LocalServices;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class SamplingPlanSubsectorSiteControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ISamplingPlanSubsectorSiteDBLocalService SamplingPlanSubsectorSiteDBLocalService { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string LocalUrl { get; set; }
        private ISamplingPlanSubsectorSiteController SamplingPlanSubsectorSiteController { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LocalService);
            Assert.NotNull(SamplingPlanSubsectorSiteDBLocalService);
            Assert.NotNull(SamplingPlanSubsectorSiteController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SamplingPlanSubsectorSiteController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);

                // testing Get
                string url = $"{ LocalUrl }api/{ culture }/SamplingPlanSubsectorSite";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = JsonSerializer.Deserialize<List<SamplingPlanSubsectorSite>>(responseContent);
                Assert.True(samplingPlanSubsectorSiteList.Count > 0);

                // testing Get(SamplingPlanSubsectorSiteID)
                string urlID = url + "/" + samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                SamplingPlanSubsectorSite samplingPlanSubsectorSite = JsonSerializer.Deserialize<SamplingPlanSubsectorSite>(responseContent);
                Assert.Equal(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);

                // testing Post(SamplingPlanSubsectorSite)
                samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                string content = JsonSerializer.Serialize<SamplingPlanSubsectorSite>(samplingPlanSubsectorSite);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                samplingPlanSubsectorSite = JsonSerializer.Deserialize<SamplingPlanSubsectorSite>(responseContent);
                Assert.NotNull(samplingPlanSubsectorSite);

                // testing Put(SamplingPlanSubsectorSite)
                content = JsonSerializer.Serialize<SamplingPlanSubsectorSite>(samplingPlanSubsectorSite);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                samplingPlanSubsectorSite = JsonSerializer.Deserialize<SamplingPlanSubsectorSite>(responseContent);
                Assert.NotNull(samplingPlanSubsectorSite);

                // testing Delete(SamplingPlanSubsectorSiteID)
                urlID = url + "/" + samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID;
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
               .AddJsonFile("appsettings_csspwebapislocaltests.json")
               .AddUserSecrets("61f396b6-8b79-4328-a2b7-a07921135f96")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            CSSPAzureUrl = Config.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            LocalUrl = Config.GetValue<string>("LocalUrl");
            Assert.NotNull(LocalUrl);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IContactDBLocalService, ContactDBLocalService>();
            Services.AddSingleton<ISamplingPlanSubsectorSiteDBLocalService, SamplingPlanSubsectorSiteDBLocalService>();
            Services.AddSingleton<ISamplingPlanSubsectorSiteController, SamplingPlanSubsectorSiteController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            SamplingPlanSubsectorSiteDBLocalService = Provider.GetService<ISamplingPlanSubsectorSiteDBLocalService>();
            Assert.NotNull(SamplingPlanSubsectorSiteDBLocalService);

            SamplingPlanSubsectorSiteController = Provider.GetService<ISamplingPlanSubsectorSiteController>();
            Assert.NotNull(SamplingPlanSubsectorSiteController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
