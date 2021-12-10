namespace CSSPReadGzFileServices.Tests;

public partial class GetUncompressJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMikeScenarios_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 27764;
        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;

        await DoFullGetUncompressJSONTest(webType, TVItemID);
    }
}

