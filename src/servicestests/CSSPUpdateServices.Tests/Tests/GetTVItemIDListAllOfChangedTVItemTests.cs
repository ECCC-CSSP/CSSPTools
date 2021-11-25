namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedTVItem_HasTVItem_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVItem().AddDays(-1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVItem(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count > 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedTVItem_NoTVItem_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVItem().AddDays(1);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVItem(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count == 0);

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    }

    private DateTime GetLastUpdateDate_UTC_TVItem()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where (c.TVType == TVTypeEnum.Country
                              || c.TVType == TVTypeEnum.Province
                              || c.TVType == TVTypeEnum.Area
                              || c.TVType == TVTypeEnum.Sector
                              || c.TVType == TVTypeEnum.Subsector
                              || c.TVType == TVTypeEnum.Municipality)
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && (c.TVType == TVTypeEnum.Country
                              || c.TVType == TVTypeEnum.Province
                              || c.TVType == TVTypeEnum.Area
                              || c.TVType == TVTypeEnum.Sector
                              || c.TVType == TVTypeEnum.Subsector
                              || c.TVType == TVTypeEnum.Municipality)
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        return DateTime1;
    }
}

