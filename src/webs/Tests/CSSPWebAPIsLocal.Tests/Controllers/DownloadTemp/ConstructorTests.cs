namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadTempControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await DownloadTempControllerSetupAsync(culture));
    }
}

