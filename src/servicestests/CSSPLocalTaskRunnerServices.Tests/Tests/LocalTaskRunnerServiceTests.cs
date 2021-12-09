namespace CSSPLocalTaskRunnerServices.Tests;

public partial class CSSPLocalTaskRunnerServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Placeholder_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalTaskRunnerServiceSetup(culture));

        Assert.True(true);
    }
}

