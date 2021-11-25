namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AppendLog_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string LogStr = "Testing";

        CSSPLogService.AppendLog(LogStr);

        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
        Assert.Contains(LogStr, CSSPLogService.sbLog.ToString());

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
}

