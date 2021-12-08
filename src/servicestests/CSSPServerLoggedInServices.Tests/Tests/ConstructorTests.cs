namespace CSSPServerLoggedInServices.Tests;

public partial class CSSPServerLoggedInServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPServerLoggedInServiceSetup(culture));
    }
}

