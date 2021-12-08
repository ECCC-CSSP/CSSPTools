namespace CSSPDBAzureServices.Tests;

public partial class TVItemUserAuthorizationAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await TVItemUserAuthorizationAzureServiceSetup(culture));
    }
}

