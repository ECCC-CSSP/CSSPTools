namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task BarTopBottom_png_Good_Test(string culture)
    {
        Assert.True(await DownloadControllerSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["LocalUrl"] }api/{ culture }/download/1/BarTopBottom.png").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(responseContent.Length > 0);
        }
    }
}

