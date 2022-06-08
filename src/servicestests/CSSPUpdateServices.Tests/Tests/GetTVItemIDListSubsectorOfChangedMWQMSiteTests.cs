namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListSubsectorOfChangedMWQMSite_HasMWQMSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMSite().AddDays(-1);

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedMWQMSiteAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListSubsectorOfChangedMWQMSite_NoMWQMSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMSite().AddDays(1);

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListSubsectorOfChangedMWQMSiteAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_MWQMSite()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.MWQMSite
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.MWQMSite
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.MWQMSites
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from cl in db.MWQMSiteStartEndDates
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

        if (DateTime1 < DateTime3)
        {
            DateTime1 = DateTime4;
        }

        return DateTime1;
    }
}

