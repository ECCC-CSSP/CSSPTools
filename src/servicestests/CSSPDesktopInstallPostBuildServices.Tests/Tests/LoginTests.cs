namespace CSSPDesktopInstallPostBuildServices.Tests;

public partial class CSSPDesktopInstallPostBuildServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Login_Good_Test(string culture)
    {
        Assert.True(await CSSPDesktopInstallPostBuildServiceSetup(culture));

        Contact contact = await CSSPDesktopInstallPostBuildService.LoginAsync();
        Assert.NotNull(contact);
    }
}

