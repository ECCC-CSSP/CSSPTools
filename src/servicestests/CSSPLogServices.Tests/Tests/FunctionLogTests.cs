namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task FunctionLog_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        string ThisFunction = "ThisFunction";

        CSSPLogService.FunctionLog(ThisFunction);

        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
    }
}

