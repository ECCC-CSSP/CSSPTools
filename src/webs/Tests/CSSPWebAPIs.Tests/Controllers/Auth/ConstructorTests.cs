namespace CSSPWebAPIs.Tests;

public partial class AuthControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await AuthControllerSetup(culture));
    }
}

