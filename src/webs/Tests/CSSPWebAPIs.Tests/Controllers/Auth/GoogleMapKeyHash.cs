namespace CSSPWebAPIs.Tests;

public partial class AuthControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GoogleMapKeyHash_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(ContactTest);
        Assert.NotEmpty(ContactTest.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContactTest.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/GoogleMapKeyHash").Result;
            Assert.True((int)response.StatusCode == 200);
            string GoogleMapKeyHash = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(GoogleMapKeyHash);
        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GoogleMapKeyHash_Unauthorize_Error_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(ContactTest);
        Assert.NotEmpty(ContactTest.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContactTest.Token + "notworking");
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/GoogleMapKeyHash").Result;
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
}

