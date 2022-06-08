namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllPolSourceSiteEffectTerms_HasPolSourceSiteEffectTerm_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceSiteEffectTerm().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceSiteEffectTermsAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllPolSourceSiteEffectTerms_NoPolSourceSiteEffectTerm_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_PolSourceSiteEffectTerm().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllPolSourceSiteEffectTermsAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_PolSourceSiteEffectTerm()
    {
        DateTime DateTime1 = (from c in db.PolSourceSiteEffects
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from cl in db.PolSourceSiteEffectTerms
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

