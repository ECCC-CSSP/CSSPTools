namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedPolSourceSiteAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from c in db.TVItems
                                  from l in db.TVItemLanguages
                                  where c.TVItemID == l.TVItemID
                                  && c.TVType == TVTypeEnum.PolSourceSite
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select (int)c.ParentID).Distinct().ToList();

        TVItemIDList = TVItemIDList.Concat((from t in db.TVItems
                                            from p in db.PolSourceSites
                                            from po in db.PolSourceObservations
                                            from pi in db.PolSourceObservationIssues
                                            where t.TVItemID == p.PolSourceSiteTVItemID
                                            && p.PolSourceSiteID == po.PolSourceSiteID
                                            && po.PolSourceObservationID == pi.PolSourceObservationID
                                            && (p.LastUpdateDate_UTC >= LastWriteTimeUtc
                                            || po.LastUpdateDate_UTC >= LastWriteTimeUtc
                                            || pi.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                            select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

        TVItemIDList = TVItemIDList.Concat((from t in db.TVItems
                                            from p in db.PolSourceSites
                                            from pse in db.PolSourceSiteEffects
                                            where t.TVItemID == p.PolSourceSiteTVItemID
                                            && p.PolSourceSiteTVItemID == pse.PolSourceSiteOrInfrastructureTVItemID
                                            && (p.LastUpdateDate_UTC >= LastWriteTimeUtc
                                            || pse.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                            select (int)t.ParentID).Distinct().ToList()).Distinct().ToList();

        return await Task.FromResult(TVItemIDList.Distinct().ToList());
    }
}

