namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory(Skip = "Skipping this test until we officially convert to the new/final CSSPDB which would not need all the stats info from the TVItemStats table")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ClearOldUnnecessaryStats_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        var actionRes = await CSSPUpdateService.ClearOldUnnecessaryStatsAsync();
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

