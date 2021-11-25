namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetFunctionName_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        string ThisFunction = "ThisFunction";

        Assert.Equal(ThisFunction, CSSPLogService.GetFunctionName($"<{ThisFunction}>"));
    }
}

