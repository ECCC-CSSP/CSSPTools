namespace CSSPLocalLoggedInServices.Tests;

public partial class CSSPLocalLoggedInServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalLoggedInServiceSetup(culture));
    }
}

