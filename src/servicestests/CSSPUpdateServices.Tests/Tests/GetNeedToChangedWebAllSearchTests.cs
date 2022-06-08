namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllSearch_HasSearch_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Search().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllSearchAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllSearch_NoSearch_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Search().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllSearchAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_Search()
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

