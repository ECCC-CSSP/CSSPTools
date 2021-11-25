namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedMapInfo_HasMapInfo_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MapInfo().AddDays(-1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedMapInfo(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count > 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedMapInfo_NoMapInfo_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MapInfo().AddDays(1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedMapInfo(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count == 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }

    private DateTime GetLastUpdateDate_UTC_MapInfo()
    {
        DateTime DateTime1 = (from c in db.MapInfos
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from m in db.MapInfoPoints
                              orderby m.LastUpdateDate_UTC descending
                              select m.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        return DateTime1;
    }
}

