namespace CSSPWebAPIsLocal.DownloadController.Tests;

public partial class CSSPWebAPIsLocalDownloadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadController_Constructor_Good_Test(string culture)
    {
        Assert.True(await DownloadSetupAsync(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadController_1_BarTopBottom_png_Good_Test(string culture)
    {
        Assert.True(await DownloadSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = httpClient.GetAsync($"{ LocalUrl }api/{ culture }/download/1/BarTopBottom.png").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(responseContent.Length > 0);
        }
    }
}

