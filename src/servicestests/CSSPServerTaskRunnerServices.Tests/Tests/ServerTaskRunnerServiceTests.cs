namespace CSSPServerTaskRunnerServices.Tests;

[Collection("Sequential")]
public partial class ServerTaskRunnerServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ServerTaskRunnerService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPServerTaskRunnerServiceSetup(culture));
    }
}

