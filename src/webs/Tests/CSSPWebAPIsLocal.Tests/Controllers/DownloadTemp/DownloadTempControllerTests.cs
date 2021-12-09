namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadTempControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempController_Good_Test(string culture)
    {
        Assert.True(await DownloadTempControllerSetupAsync(culture));

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\testing.txt");

        File.WriteAllText(fi.FullName, "bonjour");

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/DownloadTemp/{fi.Name}";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
        }
    }
}

