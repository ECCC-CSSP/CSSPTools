namespace CSSPWebAPIs.Tests;

public partial class AuthControllerTests
{
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
                new LoginModel() { LoginEmail = "WillError", Password = Configuration["Password"] },
                new LoginModel() { LoginEmail = Configuration["LoginEmail"], Password = "WillError"},
                new LoginModel() { LoginEmail = "", Password = Configuration["Password"] },
                new LoginModel() { LoginEmail = Configuration["LoginEmail"], Password = ""},
            };

        foreach (LoginModel loginModel in loginModelList)
        {
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.Token);

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/auth/token", contentData).Result;
                Assert.True((int)response.StatusCode == 400);
            }

        }
    }
}

