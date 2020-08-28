/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
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

namespace AuthController.Tests
{
    [Collection("Sequential")]
    public partial class AuthControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public AuthControllerTests()
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
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Token_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginTest();
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Token_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginTest();
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
                LoginTest();
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
        public async Task AuthController_AzureStore_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginTest();
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/auth/azurestore").Result;
                Assert.True((int)response.StatusCode == 200);

                string AzureStore = JsonSerializer.Deserialize<string>(response.Content.ReadAsStringAsync().Result);
                Assert.NotEmpty(AzureStore);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 200);

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            }

            await LoggedInService.SetLoggedInContactInfo(contact);
            LoggedInService.DBLocation = DBLocationEnum.Server;
            LoggedInService.RunningOn = RunningOnEnum.Azure;

            string Id = contact.Id;
            int ContactTVItemID = contact.ContactTVItemID;

            var actionRet2 = await ContactService.RemoveAspNetUserAndContact(Id);
            Assert.Equal(200, ((ObjectResult)actionRet2.Result).StatusCode);
            Assert.True((bool)((OkObjectResult)actionRet2.Result).Value);

            var actionRet3 = await TVItemService.Delete(ContactTVItemID);
            Assert.Equal(200, ((ObjectResult)actionRet3.Result).StatusCode);
            Assert.True((bool)((OkObjectResult)actionRet3.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_FirstName_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "", // "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_LastName_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "", // "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_LoginEmail_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "", // "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_Password_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = "", // Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_PasswordAndConfirmPasswordNotEqual_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password + "a",
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_FullNameAlreadyExist_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "Charles", // "AlAlAl",
                Initial = "G", // "T",
                LastName = "LeBlanc", // "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AuthController_Register_LoginEmailAlreadyExist_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Password = Configuration.GetValue<string>("Password");
            Assert.NotNull(Password);

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "Charles.LeBlanc2@canada.ca",
                Password = Password,
                ConfirmPassword = Password,
            };

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(registerModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/register", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
