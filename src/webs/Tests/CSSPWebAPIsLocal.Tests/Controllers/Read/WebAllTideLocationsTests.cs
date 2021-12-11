namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllTideLocations_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebAllTideLocations webAllTideLocations = JsonSerializer.Deserialize<WebAllTideLocations>(responseContent);
            Assert.NotNull(webAllTideLocations);
            Assert.NotNull(webAllTideLocations.TideLocationList);
        }
    }
}
