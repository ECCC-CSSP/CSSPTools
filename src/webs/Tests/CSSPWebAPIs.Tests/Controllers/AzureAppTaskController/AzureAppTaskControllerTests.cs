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
using CSSPWebModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CSSPLogServices.Models;

namespace CSSPWebAPIs.AppTaskModelController.Tests
{
    public partial class CSSPWebAPIsAppTaskControllerTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Constructor_Good_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Get_Good_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(200, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<PostAppTaskModel> appTaskModelList = JsonSerializer.Deserialize<List<PostAppTaskModel>>(jsonStr);
                Assert.Empty(appTaskModelList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Post_Add_Good_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(200, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<PostAppTaskModel> postAppTaskModelList = JsonSerializer.Deserialize<List<PostAppTaskModel>>(jsonStr);
                Assert.Empty(postAppTaskModelList);

                PostAppTaskModel appTaskModel = FillAppTaskModel();

                string stringData = JsonSerializer.Serialize(appTaskModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask", contentData).Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                PostAppTaskModel postAppTaskModel = JsonSerializer.Deserialize<PostAppTaskModel>(jsonStr);
                Assert.NotNull(postAppTaskModel);
                Assert.True(postAppTaskModel.AppTask.AppTaskID > 0);
                Assert.NotEmpty(postAppTaskModel.AppTaskLanguageList);

                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                postAppTaskModelList = JsonSerializer.Deserialize<List<PostAppTaskModel>>(jsonStr);
                Assert.NotEmpty(postAppTaskModelList);
                Assert.True(postAppTaskModelList[0].AppTask.AppTaskID > 0);
                Assert.NotEmpty(postAppTaskModelList[0].AppTaskLanguageList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Post_Modify_Good_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(200, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<PostAppTaskModel> postAppTaskModelList = JsonSerializer.Deserialize<List<PostAppTaskModel>>(jsonStr);
                Assert.Empty(postAppTaskModelList);

                PostAppTaskModel appTaskModel = FillAppTaskModel();

                string stringData = JsonSerializer.Serialize(appTaskModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask", contentData).Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                PostAppTaskModel postAppTaskModel = JsonSerializer.Deserialize<PostAppTaskModel>(jsonStr);
                Assert.NotNull(postAppTaskModel);
                Assert.True(postAppTaskModel.AppTask.AppTaskID > 0);
                Assert.NotEmpty(postAppTaskModel.AppTaskLanguageList);

                appTaskModel = FillAppTaskModel();

                appTaskModel.AppTask.TVItemID = 23;

                stringData = JsonSerializer.Serialize(appTaskModel);
                contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask", contentData).Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                postAppTaskModel = JsonSerializer.Deserialize<PostAppTaskModel>(jsonStr);
                Assert.NotNull(postAppTaskModel);
                Assert.True(postAppTaskModel.AppTask.AppTaskID > 0);
                Assert.NotEmpty(postAppTaskModel.AppTaskLanguageList);

                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                postAppTaskModelList = JsonSerializer.Deserialize<List<PostAppTaskModel>>(jsonStr);
                Assert.NotEmpty(postAppTaskModelList);
                Assert.True(postAppTaskModelList[0].AppTask.AppTaskID > 0);
                Assert.NotEmpty(postAppTaskModelList[0].AppTaskLanguageList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Unauthorized_NoTokenSent_Error_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(401, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
                Assert.NotNull(errRes);
                Assert.NotEmpty(errRes.ErrList);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskModelController_Unauthorized_BadTokenSent_Test(string culture)
        {
            Assert.True(await AzureAppTaskSetup(culture));

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BadToken");

                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
                Assert.Equal(401, (int)response.StatusCode);
                string jsonStr = await response.Content.ReadAsStringAsync();
                ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
                Assert.NotNull(errRes);
                Assert.NotEmpty(errRes.ErrList);
            }
        }
    }
}
