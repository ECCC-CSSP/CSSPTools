namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllPolSourceGroupings_HasPolSourceGrouping_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceGrouping().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceGroupingsAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllPolSourceGroupings_NoPolSourceGrouping_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceGrouping().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceGroupingsAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_PolSourceGrouping()
    {
        DateTime DateTime1 = (from c in db.PolSourceGroupings
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.PolSourceGroupings
                              from cl in db.PolSourceGroupingLanguages
                              where c.PolSourceGroupingID == cl.PolSourceGroupingID
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

