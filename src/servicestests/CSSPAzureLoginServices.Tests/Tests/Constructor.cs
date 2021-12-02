namespace CSSPAzureLoginServices.Tests;

public partial class CSSPAzureLoginServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));
    }
}

