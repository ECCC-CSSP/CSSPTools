namespace CSSPWebAPIs.Tests;

public partial class TVItemUserAuthorizationAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Full_Good_Test(string culture)
    {
        Assert.True(await TVItemUserAuthorizationAzureSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContactTest.Token);

            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(jsonStr);
            Assert.NotNull(tvItemUserAuthorizationList);
            Assert.Empty(tvItemUserAuthorizationList);

            TVItemUserAuthorization tvItemUserAuthorizationAdd = await FillTVItemUserAuthorization();

            string stringData = JsonSerializer.Serialize(tvItemUserAuthorizationAdd);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure", contentData);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            TVItemUserAuthorization tvItemUserAuthorization = JsonSerializer.Deserialize<TVItemUserAuthorization>(jsonStr);
            Assert.NotNull(tvItemUserAuthorization);

            response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(jsonStr);
            Assert.NotNull(tvItemUserAuthorizationList);
            Assert.NotEmpty(tvItemUserAuthorizationList);

            response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ tvItemUserAuthorization.TVItemUserAuthorizationID }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvItemUserAuthorization = JsonSerializer.Deserialize<TVItemUserAuthorization>(jsonStr);
            Assert.NotNull(tvItemUserAuthorization);

            response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(jsonStr);
            Assert.NotNull(tvItemUserAuthorizationList);
            Assert.Empty(tvItemUserAuthorizationList);
        }
    }
}

