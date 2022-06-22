namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task UploadAllFilesToAzure_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        // should not run this test everytime as it takes a very long time
        // run this test in debug mode with break points to stop the app
        // and test some parts
        bool a = false;
        if (a)
        {
            if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
            {
                var actionRes = await CSSPUpdateService.UploadAllFilesToAzureAsync();
                Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            }
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

