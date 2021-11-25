namespace CSSPLocalTaskRunnerServices.Tests;

[Collection("Sequential")]
public partial class LocalTaskRunnerServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalTaskRunnerService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalTaskRunnerServiceSetup(culture));
    }
}

