namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMikeScenarios_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 27764;
        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

