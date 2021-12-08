namespace CSSPWebAPIs.Tests;

public partial class AppTaskAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Unauthorized_NoTokenSent_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureControllerSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure").Result;
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            AppTaskModel appTaskModel = FillAppTaskModel();

            string stringData = JsonSerializer.Serialize(appTaskModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;           
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            response = httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure/{ appTaskModel.AppTask.AppTaskID }").Result;
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            appTaskModel = FillAppTaskModel();

            stringData = JsonSerializer.Serialize(appTaskModel);
            contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Unauthorized_BadTokenSent_Test(string culture)
    {
        Assert.True(await AppTaskAzureControllerSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "BadToken");

            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure").Result;
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            AppTaskModel appTaskModel = FillAppTaskModel();

            string stringData = JsonSerializer.Serialize(appTaskModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            response = httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure/{ appTaskModel.AppTask.AppTaskID }").Result;
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            appTaskModel = FillAppTaskModel();

            stringData = JsonSerializer.Serialize(appTaskModel);
            contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure", contentData).Result;
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
}

