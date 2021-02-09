/* Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPWebAPIsLocalTestsController.exe
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
using LocalServices;

namespace CSSPWebAPIsLocalControllerTests
{
    public partial class RainExceedanceControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IRainExceedanceDBService RainExceedanceDBService { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string LocalUrl { get; set; }
        private IRainExceedanceController RainExceedanceController { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedanceController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LocalService);
            Assert.NotNull(RainExceedanceDBService);
            Assert.NotNull(RainExceedanceController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedanceController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);

                // testing Get
                string url = $"{ LocalUrl }api/{ culture }/RainExceedance";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<RainExceedance> rainExceedanceList = JsonSerializer.Deserialize<List<RainExceedance>>(responseContent);
                Assert.True(rainExceedanceList.Count > 0);

                // testing Get(RainExceedanceID)
                string urlID = url + "/" + rainExceedanceList[0].RainExceedanceID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                RainExceedance rainExceedance = JsonSerializer.Deserialize<RainExceedance>(responseContent);
                Assert.Equal(rainExceedanceList[0].RainExceedanceID, rainExceedance.RainExceedanceID);

                // testing Post(RainExceedance)
                rainExceedance.RainExceedanceID = 0;
                string content = JsonSerializer.Serialize<RainExceedance>(rainExceedance);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                rainExceedance = JsonSerializer.Deserialize<RainExceedance>(responseContent);
                Assert.NotNull(rainExceedance);

                // testing Put(RainExceedance)
                content = JsonSerializer.Serialize<RainExceedance>(rainExceedance);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                rainExceedance = JsonSerializer.Deserialize<RainExceedance>(responseContent);
                Assert.NotNull(rainExceedance);

                // testing Delete(RainExceedanceID)
                urlID = url + "/" + rainExceedance.RainExceedanceID;
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
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<IRainExceedanceDBService, RainExceedanceDBService>();
            Services.AddSingleton<IRainExceedanceController, RainExceedanceController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            RainExceedanceDBService = Provider.GetService<IRainExceedanceDBService>();
            Assert.NotNull(RainExceedanceDBService);

            RainExceedanceController = Provider.GetService<IRainExceedanceController>();
            Assert.NotNull(RainExceedanceController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}