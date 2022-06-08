namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListMunicipalityOfChangedVPScenario_HasMunicipality_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_VPScenario().AddDays(-1);

        List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedVPScenarioAsync(LastUpdateDate_UTC);
        Assert.True(TVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListMunicipalityOfChangedVPScenario_NoMunicipality_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_VPScenario().AddDays(1);

        List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedVPScenarioAsync(LastUpdateDate_UTC);
        Assert.True(TVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_VPScenario()
    {
        DateTime DateTime1 = (from c in db.VPScenarios
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.VPScenarioLanguages
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.VPAmbients
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.VPResults
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

