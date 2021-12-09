namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebDrogueRuns_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
        int TVItemID = 7;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebDrogueRuns webDrogueRuns = JsonSerializer.Deserialize<WebDrogueRuns>(responseContent);
            Assert.NotNull(webDrogueRuns);
            Assert.NotNull(webDrogueRuns.DrogueRunModelList);
        }
    }
}
