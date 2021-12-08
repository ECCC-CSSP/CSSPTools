namespace CSSPWebAPIs.Tests;

public partial class VersionControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await VersionControllerSetup(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPAzureUrl"] }Version";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.StartsWith("Version", responseContent);
        }
    }
}

