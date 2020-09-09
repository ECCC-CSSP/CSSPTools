///*
// * manually edited
// *
// */

//using CSSPEnums;
//using CSSPModels;
//using CSSPServices;
//using CSSPCultureServices.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Text;

//namespace AuthController.Tests
//{
//    public partial class AuthControllerTests
//    {
//        private void LoginTest()
//        {
//            LoginEmail = Configuration.GetValue<string>("LoginEmail");
//            Assert.NotNull(LoginEmail);

//            Password =  Configuration.GetValue<string>("Password");
//            Assert.NotNull(Password);

//            LoginModel loginModelGood = new LoginModel()
//            {
//                LoginEmail = LoginEmail,
//                Password = Password
//            };

//            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
//            Assert.NotNull(CSSPAzureUrl);

//            using (HttpClient httpClient = new HttpClient())
//            {
//                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

//                string stringData = JsonSerializer.Serialize(loginModelGood);
//                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
//                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
//                Assert.True((int)response.StatusCode == 200);

//                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
//            }
//        }
//    }
//}
