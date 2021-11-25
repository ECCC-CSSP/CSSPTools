namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task GetTVItemIDListProvinceOfChangedTideSite_HasTideSite_Good_Test(string culture)
    //{
    //    Assert.True(await Setup(culture));

    //    DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideSite().AddDays(-1);

    //    Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

    //    List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedTideSite(LastUpdateDate_UTC);
    //    Assert.True(TVItemIDList.Count > 0);

    //    Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task GetTVItemIDListProvinceOfChangedTideSite_NoTideSite_Good_Test(string culture)
    //{
    //    Assert.True(await Setup(culture));

    //    DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_TideSite().AddDays(1);

    //    Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

    //    List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListProvinceOfChangedTideSite(LastUpdateDate_UTC);
    //    Assert.True(TVItemIDList.Count == 0);

    //    Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
    //}

    private DateTime GetLastUpdateDate_UTC_TideSite()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.TideSite
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.TideSite
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.TideSites
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.TideDataValues
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

