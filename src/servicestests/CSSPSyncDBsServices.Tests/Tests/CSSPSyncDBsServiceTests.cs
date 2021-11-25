namespace CSSPSyncDBsServices.Tests;

[Collection("Sequential")]
public partial class SyncDBsServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CSSPSyncDBsService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPSyncDBsServiceSetup(culture));
    }
}

