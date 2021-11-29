namespace CSSPWebAPIsLocal.Tests;

public partial class CSSPWebAPIsLocalDownloadTempControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempController_Constructor_Good_Test(string culture)
    {
        Assert.True(await DownloadTempSetupAsync(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempController_Good_Test(string culture)
    {
        Assert.True(await DownloadTempSetupAsync(culture));

        FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\testing.txt");

        File.WriteAllText(fi.FullName, "bonjour");

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ LocalUrl }api/{ culture }/DownloadTemp/{fi.Name}";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
        }
    }
}

