namespace CSSPDBAzureServices.Tests;

public partial class ContactAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await ContactAzureServiceSetup(culture));
    }
}

