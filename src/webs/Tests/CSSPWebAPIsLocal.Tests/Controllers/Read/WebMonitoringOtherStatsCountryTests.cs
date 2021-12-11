namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringOtherStatsCountry_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = JsonSerializer.Deserialize<WebMonitoringOtherStatsCountry>(responseContent);
            Assert.NotNull(webMonitoringOtherStatsCountry);
            Assert.NotNull(webMonitoringOtherStatsCountry.MonitoringStatsModelList);
        }
    }
}
