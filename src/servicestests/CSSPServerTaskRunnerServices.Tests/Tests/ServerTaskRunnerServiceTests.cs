namespace CSSPServerTaskRunnerServices.Tests;

public partial class ServerTaskRunnerServiceTest
{
    [Theory(Skip = "Skip this test for now")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Other_Good_Test(string culture)
    {
        Assert.True(await CSSPServerTaskRunnerServiceSetup(culture));

        Assert.True(true);
    }
}

