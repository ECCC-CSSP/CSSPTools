namespace CSSPReadGzFileServices.Tests;

public partial class GetUncompressJSONTests : CSSPReadGzFileServiceTests
{
    [Theory(Skip = "WebTideSite does not yet have items")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebTideSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebTideSites;

        await DoFullGetUncompressJSONTest(webType, TVItemID);
    }
}

