namespace CSSPSyncDBsServices.Tests;

public partial class SyncDBsServiceTest
{
    [Theory(Skip = "Skip this test for now")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Other_Good_Test(string culture)
    {
        Assert.True(await CSSPSyncDBsServiceSetup(culture));

        Assert.True(true);
    }
}

