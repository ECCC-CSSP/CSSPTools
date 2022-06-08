namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListCountryOfChangedEmailDistributionList_HasEmailDistributionList_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_EmailDistributionList().AddDays(-1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListCountryOfChangedEmailDistributionListAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListCountryOfChangedEmailDistributionList_NoEmailDistribution_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_EmailDistributionList().AddDays(1);

        List<int> CountryTVItemIDList = await CSSPUpdateService.GetTVItemIDListCountryOfChangedEmailDistributionListAsync(LastUpdateDate_UTC);
        Assert.True(CountryTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_EmailDistributionList()
    {
        DateTime DateTime1 = (from e in db.EmailDistributionLists
                              orderby e.LastUpdateDate_UTC descending
                              select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from e in db.EmailDistributionListLanguages
                              orderby e.LastUpdateDate_UTC descending
                              select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from e in db.EmailDistributionListContacts
                              orderby e.LastUpdateDate_UTC descending
                              select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from e in db.EmailDistributionListContactLanguages
                              orderby e.LastUpdateDate_UTC descending
                              select e.LastUpdateDate_UTC).FirstOrDefault();
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

