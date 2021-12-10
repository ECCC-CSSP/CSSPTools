namespace CSSPReadGzFileServices.Tests;

public partial class GetUncompressJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebDrogueRuns_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;

        await DoFullGetUncompressJSONTest(webType, TVItemID);
    }
}

