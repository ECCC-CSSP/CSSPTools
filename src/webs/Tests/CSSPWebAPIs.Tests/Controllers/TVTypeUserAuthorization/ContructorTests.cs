namespace CSSPWebAPIs.Tests;

public partial class TVTypeUserAuthorizationAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await TVTypeUserAuthorizationAzureSetup(culture));
    }
}

