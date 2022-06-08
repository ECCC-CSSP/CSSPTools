namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllMWQMLookupMPNs_HasMWQMLookupMPN_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMLookupMPN().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllMWQMLookupMPNsAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllMWQMLookupMPNs_NoMWQMLookupMPN_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MWQMLookupMPN().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllMWQMLookupMPNsAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_MWQMLookupMPN()
    {
        DateTime DateTime = (from e in db.MWQMLookupMPNs
                             orderby e.LastUpdateDate_UTC descending
                             select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime.Year > 2000);

        return DateTime;
    }
}

