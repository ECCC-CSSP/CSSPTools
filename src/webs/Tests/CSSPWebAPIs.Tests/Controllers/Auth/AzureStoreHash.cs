namespace CSSPWebAPIs.Tests;

public partial class AuthControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AzureStoreHash_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/AzureStoreHash").Result;
            Assert.True((int)response.StatusCode == 200);
            string AzureStoreHash = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(AzureStoreHash);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AzureStoreHash_Unauthorize_Error_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "notworking");
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/AzureStoreHash").Result;
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
}

