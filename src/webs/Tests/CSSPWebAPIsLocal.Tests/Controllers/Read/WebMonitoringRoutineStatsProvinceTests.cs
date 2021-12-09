namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsProvince_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
        int TVItemID = 7;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince = JsonSerializer.Deserialize<WebMonitoringRoutineStatsProvince>(responseContent);
            Assert.NotNull(webMonitoringRoutineStatsProvince);
            Assert.NotNull(webMonitoringRoutineStatsProvince.MonitoringStatsModelList);
        }
    }
}
