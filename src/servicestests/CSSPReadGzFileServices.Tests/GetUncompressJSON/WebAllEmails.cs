namespace CSSPReadGzFileServices.Tests;

public partial class GetUncompressJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllEmails_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllEmails;

        await DoFullGetUncompressJSONTest(webType, TVItemID);
    }
}

