namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory(Skip = "not implemented yet")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebTideSites_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebTideSites;
        int TVItemID = 7;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebTideSites webTideSite = JsonSerializer.Deserialize<WebTideSites>(responseContent);
            Assert.NotNull(webTideSite);
            Assert.NotNull(webTideSite.TideSiteModelList);
        }
    }
}
