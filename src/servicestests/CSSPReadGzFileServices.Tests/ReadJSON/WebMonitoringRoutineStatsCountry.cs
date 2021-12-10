namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

