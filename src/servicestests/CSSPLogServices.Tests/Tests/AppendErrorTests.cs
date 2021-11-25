namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AppendError_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string ErrorStr = "Testing";

        CSSPLogService.AppendError(ErrorStr);

        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
        Assert.StartsWith($"{ CSSPCultureServicesRes.ERRORCap}: {ErrorStr}", CSSPLogService.sbError.ToString());

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
}

