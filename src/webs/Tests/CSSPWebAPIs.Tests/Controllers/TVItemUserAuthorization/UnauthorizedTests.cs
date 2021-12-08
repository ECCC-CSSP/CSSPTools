namespace CSSPWebAPIs.Tests;

public partial class TVItemUserAuthorizationAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Unauthorize_NoTokenSent_Error_Test(string culture)
    {
        Assert.True(await TVItemUserAuthorizationAzureSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ -1 }");
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            TVItemUserAuthorization tvItemUserAuthorizationAdd = await FillTVItemUserAuthorization();

            string stringData = JsonSerializer.Serialize(tvItemUserAuthorizationAdd);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure", contentData);
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);


            errRes = new ErrRes();

            response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ -1 }");
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
    public async Task Unauthorize_BadTokenSent_Error_Test(string culture)
    {
        Assert.True(await TVItemUserAuthorizationAzureSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "BadToken");

            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ -1 }");
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            TVItemUserAuthorization tvItemUserAuthorizationAdd = await FillTVItemUserAuthorization();

            string stringData = JsonSerializer.Serialize(tvItemUserAuthorizationAdd);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure", contentData);
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);


            errRes = new ErrRes();

            response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ -1 }");
            Assert.Equal(401, (int)response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
}

