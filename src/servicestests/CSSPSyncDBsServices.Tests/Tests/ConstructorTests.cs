namespace CSSPSyncDBsServices.Tests;

public partial class SyncDBsServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPSyncDBsServiceSetup(culture));
    }
}

