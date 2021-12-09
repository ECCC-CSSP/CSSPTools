namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebPolSourceSites_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
        int TVItemID = 635;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebPolSourceSites webPolSourceSite = JsonSerializer.Deserialize<WebPolSourceSites>(responseContent);
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
        }
    }
}
