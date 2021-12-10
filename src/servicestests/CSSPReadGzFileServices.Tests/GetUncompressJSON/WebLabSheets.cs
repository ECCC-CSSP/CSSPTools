namespace CSSPReadGzFileServices.Tests;

public partial class GetUncompressJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebLabSheet_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebLabSheets;

        await DoFullGetUncompressJSONTest(webType, TVItemID);
    }
}

