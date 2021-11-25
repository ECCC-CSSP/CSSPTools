namespace CSSPLogServices.Tests;

public partial class CSSPLogServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task EndFunctionReturnOkTrue_Good_Test(string culture)
    {
        Assert.True(await CSSPLogServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string ThisFunction = "ThisFunction";

        var actionRes = await CSSPLogService.EndFunctionReturnOkTrue(ThisFunction);

        Assert.Equal(200, ((ObjectResult)actionRes).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes).Value);
        Assert.True((bool)((OkObjectResult)actionRes).Value);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

