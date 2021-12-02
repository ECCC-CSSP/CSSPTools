namespace UpdateServices.Tests;

[Collection("Sequential")]
public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));
    }
}

