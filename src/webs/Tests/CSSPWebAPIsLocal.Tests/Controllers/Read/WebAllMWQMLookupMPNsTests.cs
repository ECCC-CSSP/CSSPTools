namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMWQMLookupMPNs_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = JsonSerializer.Deserialize<WebAllMWQMLookupMPNs>(responseContent);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotNull(webAllMWQMLookupMPNs.MWQMLookupMPNList);
        }
    }
}