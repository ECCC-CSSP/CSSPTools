namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMWQMAnalysisReportParameters_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMWQMAnalysisReportParameters;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

