namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebHydrometricSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

