namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListProvinceOfChangedClimateSiteAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList1 = (from t in db.TVItems
                                   from tl in db.TVItemLanguages
                                   where t.TVItemID == tl.TVItemID
                                   && t.TVType == TVTypeEnum.ClimateSite
                                   && (t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   && tl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select (int)t.ParentID).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                              from c in db.ClimateSites
                                              from cd in db.ClimateDataValues
                                              where t.TVItemID == c.ClimateSiteTVItemID
                                              && c.ClimateSiteID == cd.ClimateSiteID
                                              && t.TVType == TVTypeEnum.ClimateSite
                                              && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              || cd.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                              select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

        return await Task.FromResult(TVItemIDList1);
    }
}

