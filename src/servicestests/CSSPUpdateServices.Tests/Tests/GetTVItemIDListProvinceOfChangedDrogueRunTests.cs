namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedDrogueRun_HasDrogueRun_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_DrogueRun().AddDays(-1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedDrogueRunAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedDrogueRun_NoDrogueRun_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_DrogueRun().AddDays(1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedDrogueRunAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_DrogueRun()
    {
        DateTime DateTime1 = (from c in db.DrogueRuns
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.DrogueRunPositions
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        return DateTime1;
    }
}

