namespace CSSPLocalTaskRunnerServices.Tests;

public partial class CSSPLocalTaskRunnerServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalTaskRunnerServiceSetup(culture));
    }
}

