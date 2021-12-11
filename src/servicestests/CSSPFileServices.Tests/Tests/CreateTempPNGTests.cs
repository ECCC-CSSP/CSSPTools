namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory(Skip = "Will need to figure out a way to write the test function")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempPNG_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        Assert.True(true);
    }

    [Theory(Skip = "Will need to figure out a way to write the test function")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempPNG_Unauthorized_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        Assert.True(true);
    }
}

