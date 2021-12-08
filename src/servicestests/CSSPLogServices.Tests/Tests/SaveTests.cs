namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Save_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        var actionRes = await CSSPLogService.Save();
        Assert.Equal(200, ((ObjectResult)actionRes).StatusCode);
        Assert.True((bool)((OkObjectResult)actionRes).Value);

        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Save_CSSPAppNameIsEmpty_Error_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        CSSPLogService.CSSPAppName = "";

        var actionRes = await CSSPLogService.Save();
        Assert.Equal(200, ((ObjectResult)actionRes).StatusCode);
        Assert.False((bool)((OkObjectResult)actionRes).Value);

        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
        Assert.Equal("", CSSPLogService.CSSPAppName);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Save_CSSPCommandNameIsEmpty_Error_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        CSSPLogService.CSSPCommandName = "";

        var actionRes = await CSSPLogService.Save();
        Assert.Equal(200, ((ObjectResult)actionRes).StatusCode);
        Assert.False((bool)((OkObjectResult)actionRes).Value);

        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
        Assert.Equal("", CSSPLogService.CSSPCommandName);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
}

