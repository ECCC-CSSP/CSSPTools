namespace CSSPServerTaskRunnerServices.Tests;

public partial class ServerTaskRunnerServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPServerTaskRunnerServiceSetup(culture));
    }
}

