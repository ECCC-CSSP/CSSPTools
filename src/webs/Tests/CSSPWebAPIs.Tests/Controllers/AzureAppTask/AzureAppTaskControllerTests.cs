namespace CSSPWebAPIs.AzureAppTaskController.Tests;

public partial class AzureAppTaskControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await AzureAppTaskSetup(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Get_Good_Test(string culture)
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
            List<AppTaskLocalModel> appTaskModelList = JsonSerializer.Deserialize<List<AppTaskLocalModel>>(jsonStr);
            Assert.Empty(appTaskModelList);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Post_Add_Good_Test(string culture)
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
            List<AppTaskLocalModel> postAppTaskModelList = JsonSerializer.Deserialize<List<AppTaskLocalModel>>(jsonStr);
            Assert.Empty(postAppTaskModelList);

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            string stringData = JsonSerializer.Serialize(appTaskModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask", contentData).Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            AppTaskLocalModel postAppTaskModel = JsonSerializer.Deserialize<AppTaskLocalModel>(jsonStr);
            Assert.NotNull(postAppTaskModel);
            Assert.True(postAppTaskModel.AppTask.AppTaskID > 0);
            Assert.NotEmpty(postAppTaskModel.AppTaskLanguageList);

            response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            postAppTaskModelList = JsonSerializer.Deserialize<List<AppTaskLocalModel>>(jsonStr);
            Assert.NotEmpty(postAppTaskModelList);
            Assert.True(postAppTaskModelList[0].AppTask.AppTaskID > 0);
            Assert.NotEmpty(postAppTaskModelList[0].AppTaskLanguageList);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Put_Good_Test(string culture)
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
            List<AppTaskLocalModel> postAppTaskModelList = JsonSerializer.Deserialize<List<AppTaskLocalModel>>(jsonStr);
            Assert.Empty(postAppTaskModelList);

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            string stringData = JsonSerializer.Serialize(appTaskModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask", contentData).Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            AppTaskLocalModel postAppTaskModel = JsonSerializer.Deserialize<AppTaskLocalModel>(jsonStr);
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
            postAppTaskModel = JsonSerializer.Deserialize<AppTaskLocalModel>(jsonStr);
            Assert.NotNull(postAppTaskModel);
            Assert.True(postAppTaskModel.AppTask.AppTaskID > 0);
            Assert.NotEmpty(postAppTaskModel.AppTaskLanguageList);

            response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/AzureAppTask").Result;
            Assert.Equal(200, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            postAppTaskModelList = JsonSerializer.Deserialize<List<AppTaskLocalModel>>(jsonStr);
            Assert.NotEmpty(postAppTaskModelList);
            Assert.True(postAppTaskModelList[0].AppTask.AppTaskID > 0);
            Assert.NotEmpty(postAppTaskModelList[0].AppTaskLanguageList);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Unauthorized_NoTokenSent_Error_Test(string culture)
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
    public async Task Unauthorized_BadTokenSent_Test(string culture)
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

