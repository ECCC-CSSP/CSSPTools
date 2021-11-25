namespace CSSPDesktopInstallPostBuildServices.Tests;

public partial class CSSPDesktopInstallPostBuildServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPDesktopInstallPostBuildServiceSetup(culture));
    }
}

