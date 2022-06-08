namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListCountryOfChangedRainExceedance_HasRainExceedance_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_RainExceedance().AddDays(-1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListCountryOfChangedRainExceedanceAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListCountryOfChangedRainExceedance_NoRainExceedance_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_RainExceedance().AddDays(1);

        List<int> CountryTVItemIDList = await CSSPUpdateService.GetTVItemIDListCountryOfChangedRainExceedanceAsync(LastUpdateDate_UTC);
        Assert.True(CountryTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_RainExceedance()
    {

        DateTime DateTime1 = (from t in db.TVItems
                              where t.TVType == TVTypeEnum.RainExceedance
                              orderby t.LastUpdateDate_UTC descending
                              select t.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from t in db.TVItems
                              from tl in db.TVItemLanguages
                              where t.TVItemID == tl.TVItemID
                              && t.TVType == TVTypeEnum.RainExceedance
                              orderby tl.LastUpdateDate_UTC descending
                              select tl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from r in db.RainExceedances
                              orderby r.LastUpdateDate_UTC descending
                              select r.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from rc in db.RainExceedanceClimateSites
                              orderby rc.LastUpdateDate_UTC descending
                              select rc.LastUpdateDate_UTC).FirstOrDefault();
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

