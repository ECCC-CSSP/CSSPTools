namespace CSSPWebAPIs.Tests;

public partial class TVTypeUserAuthorizationAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Full_Good_Test(string culture)
    {
        Assert.True(await TVTypeUserAuthorizationAzureSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorizationList);
            Assert.Empty(tvTypeUserAuthorizationList);

            TVTypeUserAuthorization tvTypeUserAuthorizationAdd = await FillTVTypeUserAuthorization();

            string stringData = JsonSerializer.Serialize(tvTypeUserAuthorizationAdd);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

            response = await httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure", contentData);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            TVTypeUserAuthorization tvTypeUserAuthorization = JsonSerializer.Deserialize<TVTypeUserAuthorization>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorization);

            response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorizationList);
            Assert.NotEmpty(tvTypeUserAuthorizationList);

            response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ tvTypeUserAuthorization.TVTypeUserAuthorizationID }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvTypeUserAuthorization = JsonSerializer.Deserialize<TVTypeUserAuthorization>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorization);

            response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonStr = await response.Content.ReadAsStringAsync();
            tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorizationList);
            Assert.Empty(tvTypeUserAuthorizationList);
        }

    }
}

