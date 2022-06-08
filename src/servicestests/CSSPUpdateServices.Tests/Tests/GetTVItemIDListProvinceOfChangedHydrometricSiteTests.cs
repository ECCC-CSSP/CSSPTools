namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedHydrometricSite_HasHydrometricSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_HydrometricSite().AddDays(-1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedHydrometricSiteAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedHydrometricSite_NoHydrometricSite_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_HydrometricSite().AddDays(1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedHydrometricSiteAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_HydrometricSite()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.HydrometricSite
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.HydrometricSite
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.HydrometricSites
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.HydrometricDataValues
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime4.Year > 2000);

        DateTime DateTime5 = (from c in db.RatingCurves
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime5.Year > 2000);

        DateTime DateTime6 = (from c in db.RatingCurveValues
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime6.Year > 2000);

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

        if (DateTime1 < DateTime5)
        {
            DateTime1 = DateTime5;
        }

        if (DateTime1 < DateTime6)
        {
            DateTime1 = DateTime6;
        }

        return DateTime1;
    }
}

