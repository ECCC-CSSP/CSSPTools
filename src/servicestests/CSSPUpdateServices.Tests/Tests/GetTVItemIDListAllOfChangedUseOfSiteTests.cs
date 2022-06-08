namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedUseOfSite_HasUseOfSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_UseOfSite().AddDays(-1);

        List<int> SubsectorUseOfSiteIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedUseOfSiteAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorUseOfSiteIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedUseOfSite_NoUseOfSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_UseOfSite().AddDays(1);

        List<int> SubsectorUseOfSiteIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedUseOfSiteAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorUseOfSiteIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_UseOfSite()
    {
        DateTime DateTime1 = (from c in db.UseOfSites
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        return DateTime1;
    }
}

