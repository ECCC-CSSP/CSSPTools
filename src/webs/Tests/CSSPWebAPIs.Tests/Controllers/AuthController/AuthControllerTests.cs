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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CSSPHelperModels;

namespace CSSPWebAPIs.AuthController.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebAPIsAuthControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public CSSPWebAPIsAuthControllerTests()
        //{
        // See setup
        //}
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Token_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Token_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            List<LoginModel> loginModelList = new List<LoginModel>()
            {
                new LoginModel() { LoginEmail = "WillError", Password = Password },
                new LoginModel() { LoginEmail = LoginEmail, Password = "WillError"},
                new LoginModel() { LoginEmail = "", Password = Password },
                new LoginModel() { LoginEmail = LoginEmail, Password = ""},
            };

            foreach (LoginModel loginModel in loginModelList)
            {
                Assert.NotNull(contact);
                Assert.NotEmpty(contact.Token);

                CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
                Assert.NotNull(CSSPAzureUrl);

                using (HttpClient httpClient = new HttpClient())
                {
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                    string stringData = JsonSerializer.Serialize(loginModel);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                    Assert.True((int)response.StatusCode == 400);
                }

            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_GoogleMapKey_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKey").Result;
                Assert.True((int)response.StatusCode == 200);
                string GoogleMapKey = response.Content.ReadAsStringAsync().Result;
                Assert.NotNull(GoogleMapKey);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_GoogleMapKey_Unauthorize_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "notworking");
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKey").Result;
                Assert.True((int)response.StatusCode == 401);
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
