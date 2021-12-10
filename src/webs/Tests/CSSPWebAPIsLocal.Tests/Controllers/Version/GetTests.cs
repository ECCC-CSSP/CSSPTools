namespace CSSPWebAPIsLocal.Tests;

public partial class VersionControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Get_Good_Test(string culture)
    {
        Assert.True(await VersionControllerSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }Version";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.StartsWith("Version", responseContent);
        }
    }
}

