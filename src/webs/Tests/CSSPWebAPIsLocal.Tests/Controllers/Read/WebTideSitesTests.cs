namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory(Skip = "not implemented yet")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebTideSites_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebTideSites;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebTideSites webTideSite = JsonSerializer.Deserialize<WebTideSites>(responseContent);
            Assert.NotNull(webTideSite);
            Assert.NotNull(webTideSite.TideSiteModelList);
        }
    }
}
