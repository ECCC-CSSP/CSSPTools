namespace CSSPDBLocalServices.Tests;

public partial class TelLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));
    }
}

