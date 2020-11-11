/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPWebAPIsLocalTestsController.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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

namespace CSSPWebAPIsLocalControllerTests
{
    public partial class LocalRainExceedanceControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalRainExceedanceDBService LocalRainExceedanceDBService { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string LocalUrl { get; set; }
        private ILocalRainExceedanceController LocalRainExceedanceController { get; set; }
        #endregion Properties

        #region Constructors
        public LocalRainExceedanceControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalRainExceedanceController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LocalService);
            Assert.NotNull(LocalRainExceedanceDBService);
            Assert.NotNull(LocalRainExceedanceController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalRainExceedanceController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);

                // testing Get
                string url = $"{ LocalUrl }api/{ culture }/LocalRainExceedance";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<LocalRainExceedance> localRainExceedanceList = JsonSerializer.Deserialize<List<LocalRainExceedance>>(responseContent);
                Assert.True(localRainExceedanceList.Count > 0);

                // testing Get(RainExceedanceID)
                string urlID = url + "/" + localRainExceedanceList[0].RainExceedanceID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                LocalRainExceedance localRainExceedance = JsonSerializer.Deserialize<LocalRainExceedance>(responseContent);
                Assert.Equal(localRainExceedanceList[0].RainExceedanceID, localRainExceedance.RainExceedanceID);

                // testing Post(LocalRainExceedance)
                localRainExceedance.RainExceedanceID = 0;
                string content = JsonSerializer.Serialize<LocalRainExceedance>(localRainExceedance);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                localRainExceedance = JsonSerializer.Deserialize<LocalRainExceedance>(responseContent);
                Assert.NotNull(localRainExceedance);

                // testing Put(LocalRainExceedance)
                content = JsonSerializer.Serialize<LocalRainExceedance>(localRainExceedance);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                localRainExceedance = JsonSerializer.Deserialize<LocalRainExceedance>(responseContent);
                Assert.NotNull(localRainExceedance);

                // testing Delete(RainExceedanceID)
                urlID = url + "/" + localRainExceedance.RainExceedanceID;
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
            Services.AddSingleton<ILocalContactDBService, LocalContactDBService>();
            Services.AddSingleton<ILocalRainExceedanceDBService, LocalRainExceedanceDBService>();
            Services.AddSingleton<ILocalRainExceedanceController, LocalRainExceedanceController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            LocalRainExceedanceDBService = Provider.GetService<ILocalRainExceedanceDBService>();
            Assert.NotNull(LocalRainExceedanceDBService);

            LocalRainExceedanceController = Provider.GetService<ILocalRainExceedanceController>();
            Assert.NotNull(LocalRainExceedanceController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
