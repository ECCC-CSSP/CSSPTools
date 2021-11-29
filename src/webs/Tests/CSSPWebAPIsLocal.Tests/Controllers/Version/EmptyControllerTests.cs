namespace CSSPWebAPIsLocal.VersionController.Tests;

public partial class CSSPWebAPIsLocalVersionControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task VersionController_Constructor_Good_Test(string culture)
    {
        Assert.True(await VersionSetupAsync(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task VersionController_Load_Good_Test(string culture)
    {
        Assert.True(await VersionSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ LocalUrl }Version";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.StartsWith("Version", responseContent);
        }
    }
}

