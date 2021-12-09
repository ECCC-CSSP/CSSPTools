namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadOtherControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadOtherController_Good_Test(string culture)
    {
        Assert.True(await DownloadOtherControllerSetupAsync(culture));

        List<string> otherFileList = new List<string>()
        {
            "CssFamilyMaterial.css", "IconFamilyMaterial.css", "GoogleMap.js", "flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2"
        };

        using (HttpClient httpClient = new HttpClient())
        {
            foreach (string otherFile in otherFileList)
            {
                string url = $"{ Configuration["LocalUrl"] }api/{ culture }/DownloadOther/{otherFile}";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
            }
        }
    }
}

