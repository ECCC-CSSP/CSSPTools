namespace CSSPWebAPIs.Tests;

public partial class AppTaskAzureControllerTests : BaseControllerTests
{
    private async Task<bool> AppTaskAzureControllerSetup(string culture)
    {
        await BaseControllerSetup(culture);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContactTest.Token);

            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/AppTaskAzure").Result;
            Assert.Equal(200, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<AppTaskModel> appTaskModelList = JsonSerializer.Deserialize<List<AppTaskModel>>(jsonStr);
            Assert.NotNull(appTaskModelList);

            foreach (AppTaskModel appTaskModel in appTaskModelList.Where(c => c.AppTask.AppTaskStatus == AppTaskStatusEnum.Completed))
            {
                HttpResponseMessage responseDel = httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/AppTaskAzure/{ appTaskModel.AppTask.AppTaskID }").Result;
                Assert.Equal(200, (int)responseDel.StatusCode);
                string jsonStrDel = await responseDel.Content.ReadAsStringAsync();
                AppTaskModel appTaskModelDel = JsonSerializer.Deserialize<AppTaskModel>(jsonStrDel);
                Assert.NotNull(appTaskModelDel);
            }
        }

        return await Task.FromResult(true);
    }
}

