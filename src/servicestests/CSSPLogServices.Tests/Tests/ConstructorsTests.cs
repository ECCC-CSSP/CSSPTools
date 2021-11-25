namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.NotNull(CSSPCultureService);
        Assert.NotNull(CSSPLocalLoggedInService);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLogService);
        Assert.NotNull(dbManage);
        Assert.Equal("CSSPLogService_AppName", CSSPLogService.CSSPAppName);
        Assert.Equal("CSSPLogService_CommandName", CSSPLogService.CSSPCommandName);
        Assert.Equal("", CSSPLogService.sbError.ToString());
        Assert.Equal("", CSSPLogService.sbLog.ToString());
    }
}

