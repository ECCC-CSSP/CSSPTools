namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllCountries_HasCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Country().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllCountriesAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllCountries_NoCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Country().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllCountriesAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_Country()
    {
        DateTime DateTime1 = (from t in db.TVItems
                              where t.TVType == TVTypeEnum.Country
                              orderby t.LastUpdateDate_UTC descending
                              select t.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from t in db.TVItems
                              from tl in db.TVItemLanguages
                              where t.TVItemID == tl.TVItemID
                              && t.TVType == TVTypeEnum.Country
                              orderby tl.LastUpdateDate_UTC descending
                              select tl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);


        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        return DateTime1;
    }
}

