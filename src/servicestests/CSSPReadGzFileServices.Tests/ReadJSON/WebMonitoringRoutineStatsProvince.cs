namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsProvince_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

