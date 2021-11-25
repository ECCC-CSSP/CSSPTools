namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllHelpDocs_HasHelpDoc_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_HelpDoc().AddDays(-1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllHelpDocs(LastUpdateDate_UTC));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllHelpDocs_NoHelpDoc_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_HelpDoc().AddDays(1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllHelpDocs(LastUpdateDate_UTC));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }

    private DateTime GetLastUpdateDate_UTC_HelpDoc()
    {
        DateTime DateTime = (from e in db.HelpDocs
                             orderby e.LastUpdateDate_UTC descending
                             select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime.Year > 2000);

        return DateTime;
    }
}

