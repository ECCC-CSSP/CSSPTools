namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedSamplingPlan_HasSamplingPlan_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_SamplingPlan().AddDays(-1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedSamplingPlanAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListProvinceOfChangedSamplingPlan_NoSamplingPlan_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_SamplingPlan().AddDays(1);

        List<int> ProvinceTVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedSamplingPlanAsync(LastUpdateDate_UTC);
        Assert.True(ProvinceTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_SamplingPlan()
    {
        DateTime DateTime1 = (from c in db.SamplingPlans
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.SamplingPlanSubsectors
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.SamplingPlanSubsectorSites
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.SamplingPlanEmails
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
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

