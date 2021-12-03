namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));
    }
}

