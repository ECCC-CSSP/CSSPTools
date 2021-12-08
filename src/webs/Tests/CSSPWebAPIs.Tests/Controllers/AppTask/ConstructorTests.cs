namespace CSSPWebAPIs.Tests;

public partial class AppTaskAzureControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureControllerSetup(culture));
    }
}

