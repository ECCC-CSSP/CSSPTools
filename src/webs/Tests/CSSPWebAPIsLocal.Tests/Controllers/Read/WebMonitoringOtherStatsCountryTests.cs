namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringOtherStatsCountry_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
        int TVItemID = 5;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry = JsonSerializer.Deserialize<WebMonitoringOtherStatsCountry>(responseContent);
            Assert.NotNull(webMonitoringOtherStatsCountry);
            Assert.NotNull(webMonitoringOtherStatsCountry.MonitoringStatsModelList);
        }
    }
}
