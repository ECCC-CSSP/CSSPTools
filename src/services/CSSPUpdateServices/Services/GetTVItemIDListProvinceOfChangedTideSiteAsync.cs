namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListProvinceOfChangedTideSiteAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList1 = (from t in db.TVItems
                                   from tl in db.TVItemLanguages
                                   where t.TVItemID == tl.TVItemID
                                   && t.TVType == TVTypeEnum.TideSite
                                   && (t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   && tl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select (int)t.ParentID).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from t in db.TVItems
                                              from c in db.TideSites
                                              from cd in db.TideDataValues
                                              where t.TVItemID == c.TideSiteTVItemID
                                              && c.TideSiteTVItemID == cd.TideSiteTVItemID
                                              && t.TVType == TVTypeEnum.TideSite
                                              && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              || cd.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                              select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

        return await Task.FromResult(TVItemIDList1);
    }
}

