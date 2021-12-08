namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));
    }
}

