namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListSubsectorOfChangedMWQMRun_HasMWQMRun_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMRun().AddDays(-1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedMWQMRunAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count > 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListSubsectorOfChangedMWQMRun_NoMWQMRun_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMRun().AddDays(1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedMWQMRunAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count == 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }

    private DateTime GetLastUpdateDate_UTC_MWQMRun()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.MWQMRun
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.MWQMRun
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.MWQMRuns
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.MWQMRuns
                              from cl in db.MWQMRunLanguages
                              where c.MWQMRunID == cl.MWQMRunID
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime4.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        if (DateTime1 < DateTime3)
        {
            DateTime1 = DateTime3;
        }

        if (DateTime1 < DateTime4)
        {
            DateTime1 = DateTime4;
        }

        return DateTime1;
    }
}

