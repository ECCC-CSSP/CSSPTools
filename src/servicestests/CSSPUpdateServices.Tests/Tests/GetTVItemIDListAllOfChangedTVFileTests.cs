namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedTVFile_HasTVFile_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVFile().AddDays(-1);

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVFileAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListAllOfChangedTVFile_NoTVFile_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TVFile().AddDays(1);

        List<int> SubsectorTVItemIDList = await CSSPUpdateService.GetTVItemIDListAllOfChangedTVFileAsync(LastUpdateDate_UTC);
        Assert.True(SubsectorTVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_TVFile()
    {
        DateTime DateTime1 = (from t in db.TVItems
                              where t.TVType == TVTypeEnum.File
                              orderby t.LastUpdateDate_UTC descending
                              select t.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from t in db.TVItems
                              from tl in db.TVItemLanguages
                              where t.TVItemID == tl.TVItemID
                              && t.TVType == TVTypeEnum.File
                              orderby tl.LastUpdateDate_UTC descending
                              select tl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.TVFiles
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from cf in db.TVFileLanguages
                              orderby cf.LastUpdateDate_UTC descending
                              select cf.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime4.Year > 2000);

        if (DateTime1 < DateTime2)
        {
            DateTime1 = DateTime2;
        }

        if (DateTime1 < DateTime3)
        {
            DateTime1 = DateTime3;
        }

        if (DateTime1 < DateTime3)
        {
            DateTime1 = DateTime4;
        }
        return DateTime1;
    }
}

