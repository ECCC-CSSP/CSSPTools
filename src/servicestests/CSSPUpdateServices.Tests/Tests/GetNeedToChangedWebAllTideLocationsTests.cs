namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllTideLocations_HasTideLocation_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideLocation().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllTideLocationsAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllTideLocations_NoTideLocation_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideLocation().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllTideLocationsAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_TideLocation()
    {
        DateTime DateTime1 = (from t in db.TideLocations
                              orderby t.LastUpdateDate_UTC descending
                              select t.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        return DateTime1;
    }
}

