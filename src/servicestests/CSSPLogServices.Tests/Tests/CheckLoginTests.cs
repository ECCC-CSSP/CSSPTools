namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CheckLogin_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string FunctionName = "TheFunctionName";

        Assert.True(await CSSPLogService.CheckLogin(FunctionName));

        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CheckLogin_Error_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string FunctionName = "TheFunctionName";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        Assert.False(await CSSPLogService.CheckLogin(FunctionName));

        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}
