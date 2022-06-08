namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllAddresses_HasAddress_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Address().AddDays(-1);

        Assert.True(await CSSPUpdateService.GetNeedToChangedWebAllAddressesAsync(LastUpdateDate_UTC));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetNeedToChangedWebAllAddresses_NoAddress_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_Address().AddDays(1);

        Assert.False(await CSSPUpdateService.GetNeedToChangedWebAllAddressesAsync(LastUpdateDate_UTC));
    }

    private DateTime GetLastUpdateDate_UTC_Address()
    {
        DateTime DateTime1 = (from t in db.TVItems
                              where t.TVType == TVTypeEnum.Address
                              orderby t.LastUpdateDate_UTC descending
                              select t.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from t in db.TVItems
                              from tl in db.TVItemLanguages
                              where t.TVItemID == tl.TVItemID
                              && t.TVType == TVTypeEnum.Address
                              orderby tl.LastUpdateDate_UTC descending
                              select tl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from e in db.Addresses
                              orderby e.LastUpdateDate_UTC descending
                              select e.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);


        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        if (DateTime1 < DateTime3)
        {
            DateTime1 = DateTime3;
        }

        return DateTime1;
    }
}

