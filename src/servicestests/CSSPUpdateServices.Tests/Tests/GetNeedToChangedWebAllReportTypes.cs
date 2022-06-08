namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllReportTypes_HasReportType_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_ReportType().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllReportTypesAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllReportTypes_NoReportType_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_ReportType().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllReportTypesAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_ReportType()
    {
        DateTime DateTime1 = (from c in db.ReportTypes
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from rs in db.ReportSections
                              orderby rs.LastUpdateDate_UTC descending
                              select rs.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        return DateTime1;
    }
}

