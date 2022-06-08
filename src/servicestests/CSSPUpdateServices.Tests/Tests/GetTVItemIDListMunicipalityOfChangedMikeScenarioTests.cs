namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListMunicipalityOfChangedMikeScenario_HasMunicipality_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MikeScenario().AddDays(-1);

        List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedMikeScenarioAsync(LastUpdateDate_UTC);
        Assert.True(TVItemIDList.Count > 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemIDListMunicipalityOfChangedMikeScenario_NoMunicipality_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        DateTime LastUpdateDate_UTC = GetLastUpdateDate_UTC_MikeScenario().AddDays(1);

        List<int> TVItemIDList = await CSSPUpdateService.GetTVItemIDListMunicipalityOfChangedMikeScenarioAsync(LastUpdateDate_UTC);
        Assert.True(TVItemIDList.Count == 0);
    }

    private DateTime GetLastUpdateDate_UTC_MikeScenario()
    {
        DateTime DateTime1 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.MikeScenario
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime1.Year > 2000);

        DateTime DateTime2 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.MikeScenario
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime2.Year > 2000);

        DateTime DateTime3 = (from c in db.TVItems
                              where (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime3.Year > 2000);

        DateTime DateTime4 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && (c.TVType == TVTypeEnum.MikeBoundaryConditionMesh
                              || c.TVType == TVTypeEnum.MikeBoundaryConditionWebTide)
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime4.Year > 2000);

        DateTime DateTime5 = (from c in db.TVItems
                              where c.TVType == TVTypeEnum.MikeSource
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime5.Year > 2000);

        DateTime DateTime6 = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              where c.TVItemID == cl.TVItemID
                              && c.TVType == TVTypeEnum.MikeSource
                              orderby cl.LastUpdateDate_UTC descending
                              select cl.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime6.Year > 2000);

        DateTime DateTime7 = (from c in db.MikeScenarios
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime7.Year > 2000);

        DateTime DateTime8 = (from c in db.MikeScenarioResults
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime8.Year > 2000);

        DateTime DateTime9 = (from c in db.MikeBoundaryConditions
                              orderby c.LastUpdateDate_UTC descending
                              select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime9.Year > 2000);

        DateTime DateTime10 = (from c in db.MikeSources
                               orderby c.LastUpdateDate_UTC descending
                               select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime10.Year > 2000);

        DateTime DateTime11 = (from c in db.MikeSourceStartEnds
                               orderby c.LastUpdateDate_UTC descending
                               select c.LastUpdateDate_UTC).FirstOrDefault();
        Assert.True(DateTime11.Year > 2000);

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

        if (DateTime1 < DateTime5)
        {
            DateTime1 = DateTime5;
        }

        if (DateTime1 < DateTime6)
        {
            DateTime1 = DateTime6;
        }

        if (DateTime1 < DateTime7)
        {
            DateTime1 = DateTime7;
        }

        if (DateTime1 < DateTime8)
        {
            DateTime1 = DateTime8;
        }

        if (DateTime1 < DateTime9)
        {
            DateTime1 = DateTime9;
        }

        if (DateTime1 < DateTime10)
        {
            DateTime1 = DateTime10;
        }

        if (DateTime1 < DateTime11)
        {
            DateTime1 = DateTime11;
        }

        return DateTime1;
    }
}

