namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebCountry;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

