namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsCountry_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
        int TVItemID = 5;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry = JsonSerializer.Deserialize<WebMonitoringRoutineStatsCountry>(responseContent);
            Assert.NotNull(webMonitoringRoutineStatsCountry);
            Assert.NotNull(webMonitoringRoutineStatsCountry.MonitoringStatsModelList);
        }
    }
}
