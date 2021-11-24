namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));
    }
}

