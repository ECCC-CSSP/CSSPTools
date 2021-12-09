namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMRuns_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
        int TVItemID = 635;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMWQMRuns webMWQMRun = JsonSerializer.Deserialize<WebMWQMRuns>(responseContent);
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunModelList);
        }
    }
}
