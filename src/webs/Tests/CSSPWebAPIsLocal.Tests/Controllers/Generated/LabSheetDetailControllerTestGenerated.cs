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
    public partial class LabSheetDetailControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILabSheetDetailDBService LabSheetDetailDBService { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string LocalUrl { get; set; }
        private ILabSheetDetailController LabSheetDetailController { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetDetailController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(LocalService);
            Assert.NotNull(LabSheetDetailDBService);
            Assert.NotNull(LabSheetDetailController);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LabSheetDetailController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalService.LoggedInContactInfo.LoggedInContact.Token);

                // testing Get
                string url = $"{ LocalUrl }api/{ culture }/LabSheetDetail";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                List<LabSheetDetail> labSheetDetailList = JsonSerializer.Deserialize<List<LabSheetDetail>>(responseContent);
                Assert.True(labSheetDetailList.Count > 0);

                // testing Get(LabSheetDetailID)
                string urlID = url + "/" + labSheetDetailList[0].LabSheetDetailID;
                response = await httpClient.GetAsync(urlID);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                LabSheetDetail labSheetDetail = JsonSerializer.Deserialize<LabSheetDetail>(responseContent);
                Assert.Equal(labSheetDetailList[0].LabSheetDetailID, labSheetDetail.LabSheetDetailID);

                // testing Post(LabSheetDetail)
                labSheetDetail.LabSheetDetailID = 0;
                string content = JsonSerializer.Serialize<LabSheetDetail>(labSheetDetail);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PostAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                labSheetDetail = JsonSerializer.Deserialize<LabSheetDetail>(responseContent);
                Assert.NotNull(labSheetDetail);

                // testing Put(LabSheetDetail)
                content = JsonSerializer.Serialize<LabSheetDetail>(labSheetDetail);
                httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await httpClient.PutAsync(url, httpContent);
                Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
                responseContent = await response.Content.ReadAsStringAsync();
                Assert.NotEmpty(responseContent);
                labSheetDetail = JsonSerializer.Deserialize<LabSheetDetail>(responseContent);
                Assert.NotNull(labSheetDetail);

                // testing Delete(LabSheetDetailID)
                urlID = url + "/" + labSheetDetail.LabSheetDetailID;
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
            Services.AddSingleton<ILabSheetDetailDBService, LabSheetDetailDBService>();
            Services.AddSingleton<ILabSheetDetailController, LabSheetDetailController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);

            LabSheetDetailDBService = Provider.GetService<ILabSheetDetailDBService>();
            Assert.NotNull(LabSheetDetailDBService);

            LabSheetDetailController = Provider.GetService<ILabSheetDetailController>();
            Assert.NotNull(LabSheetDetailController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}