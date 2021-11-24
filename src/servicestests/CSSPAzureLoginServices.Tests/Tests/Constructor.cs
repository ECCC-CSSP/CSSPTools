namespace CSSPAzureLoginServices.Tests;

public partial class CSSPAzureLoginServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CSSPAzureLoginService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureLoginServiceSetup(culture));
    }
}

