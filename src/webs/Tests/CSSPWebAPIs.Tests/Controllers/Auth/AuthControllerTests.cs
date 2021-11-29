namespace CSSPWebAPIs.AuthController.Tests;

public partial class CSSPWebAPIsAuthControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(Configuration);
        Assert.NotNull(CSSPCultureService);
        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Token_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Token_Error_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);

        List<LoginModel> loginModelList = new List<LoginModel>()
            {
                new LoginModel() { LoginEmail = "WillError", Password = Password },
                new LoginModel() { LoginEmail = LoginEmail, Password = "WillError"},
                new LoginModel() { LoginEmail = "", Password = Password },
                new LoginModel() { LoginEmail = LoginEmail, Password = ""},
            };

        foreach (LoginModel loginModel in loginModelList)
        {
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(CSSPAzureUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }

        }
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GoogleMapKeyHash_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKeyHash").Result;
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

        Assert.NotNull(contact);
        Assert.NotEmpty(contact.Token);

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token + "notworking");
            HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKeyHash").Result;
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
            HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/AzureStoreHash").Result;
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
            HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/AzureStoreHash").Result;
            Assert.Equal(401, (int)response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(jsonStr);
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
    }
}

