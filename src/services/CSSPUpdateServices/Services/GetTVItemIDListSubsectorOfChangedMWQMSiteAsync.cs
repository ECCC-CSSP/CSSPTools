namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSiteAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from c in db.TVItems
                                  from l in db.TVItemLanguages
                                  where c.TVItemID == l.TVItemID
                                  && c.TVType == TVTypeEnum.MWQMSite
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select (int)c.ParentID).Distinct().ToList();

        TVItemIDList = TVItemIDList.Concat((from t in db.TVItems
                                            from c in db.MWQMSites
                                            from l in db.MWQMSiteStartEndDates
                                            where t.TVItemID == c.MWQMSiteTVItemID
                                            && c.MWQMSiteTVItemID == l.MWQMSiteTVItemID
                                            && t.TVType == TVTypeEnum.MWQMSite
                                            && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                            || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                            select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

        return await Task.FromResult(TVItemIDList);
    }
}

