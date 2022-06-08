namespace CSSPWebAPIs.Tests;

public partial class AppTaskAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Full_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureControllerSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContactTest.Token);

            // GetAllAzureAppTaskAsync
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure").Result;
            Assert.Equal(200, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<AppTaskModel> appTaskModelList = JsonSerializer.Deserialize<List<AppTaskModel>>(jsonStr);
            Assert.NotNull(appTaskModelList);
            Assert.Empty(appTaskModelList.Where(c => c.AppTask.AppTaskStatus == AppTaskStatusEnum.Completed));

            // AddAzureAppTaskAsync
            AppTaskModel appTaskModel = FillAppTaskModel();

            string stringData = JsonSerializer.Serialize(appTaskModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            AppTaskModel appTaskModelRet = JsonSerializer.Deserialize<AppTaskModel>(jsonStr);
            Assert.NotNull(appTaskModelRet);
            Assert.True(appTaskModelRet.AppTask.AppTaskID > 0);
            Assert.NotEmpty(appTaskModelRet.AppTaskLanguageList);

            // GetAllAzureAppTaskAsync
            response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure").Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            appTaskModelList = JsonSerializer.Deserialize<List<AppTaskModel>>(jsonStr);
            Assert.NotNull(appTaskModelList);
            Assert.NotEmpty(appTaskModelList.Where(c => c.AppTask.AppTaskStatus == AppTaskStatusEnum.Completed));


            // ModifyAzureAppTaskAsync
            appTaskModel = appTaskModelList.Where(c => c.AppTask.AppTaskStatus == AppTaskStatusEnum.Completed).FirstOrDefault();
            Assert.NotNull(appTaskModel);

            appTaskModel.AppTask.TVItemID = 23;

            stringData = JsonSerializer.Serialize(appTaskModel);
            contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            appTaskModelRet = JsonSerializer.Deserialize<AppTaskModel>(jsonStr);
            Assert.NotNull(appTaskModelRet);
            Assert.True(appTaskModelRet.AppTask.AppTaskID > 0);
            Assert.NotEmpty(appTaskModelRet.AppTaskLanguageList);

            foreach (AppTaskModel appTaskModelToDelete in appTaskModelList.Where(c => c.AppTask.AppTaskStatus == AppTaskStatusEnum.Completed))
            {
                response = httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure/{ appTaskModelToDelete.AppTask.AppTaskID }").Result;
                Assert.Equal(200, (int)response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                appTaskModelRet = JsonSerializer.Deserialize<AppTaskModel>(jsonStr);
                Assert.NotNull(appTaskModelRet);
            }
        }
    }
}

