namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListAllOfChangedTVFileAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = new List<int>();

        List<TVItem> TVItemListPolSourceSite = (from t in db.TVItems
                                                where t.TVType == TVTypeEnum.PolSourceSite
                                                select t).ToList();

        List<TVItem> TVItemListMikeScenario = (from t in db.TVItems
                                               where t.TVType == TVTypeEnum.MikeScenario
                                               select t).ToList();

        List<TVItem> TVItemListMWQMSite = (from t in db.TVItems
                                           where t.TVType == TVTypeEnum.MWQMSite
                                           select t).ToList();

        List<TVItem> TVItemListAllOthers = (from t in db.TVItems
                                            where (t.TVType == TVTypeEnum.Country
                                            || t.TVType == TVTypeEnum.Province
                                            || t.TVType == TVTypeEnum.Area
                                            || t.TVType == TVTypeEnum.Sector
                                            || t.TVType == TVTypeEnum.Subsector
                                            || t.TVType == TVTypeEnum.Municipality)
                                            select t).ToList();

        List<TVItem> TVItemList = (from t in db.TVItems
                                   from tl in db.TVItemLanguages
                                   where t.TVItemID == tl.TVItemID
                                   && t.TVType == TVTypeEnum.File
                                   && (t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   || tl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                   select t).Distinct().ToList();

        TVItemList = TVItemList.Concat((from t in db.TVItems
                                        from c in db.TVFiles
                                        from cf in db.TVFileLanguages
                                        where t.TVItemID == c.TVFileTVItemID
                                        && c.TVFileID == cf.TVFileID
                                        && t.TVType == TVTypeEnum.File
                                        && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                        || cf.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                        select t).Distinct().ToList()).Distinct().ToList();

        foreach (TVItem tvItemPolSourceSite in (from c in TVItemList
                                                from p in TVItemListPolSourceSite
                                                where c.ParentID == p.TVItemID
                                                select p).Distinct().ToList())
        {
            if (!TVItemIDList.Where(c => c == tvItemPolSourceSite.ParentID).Any())
            {
                TVItemIDList.Add((int)tvItemPolSourceSite.ParentID);
            }
        }

        foreach (TVItem tvItemMikeScenario in (from c in TVItemList
                                               from p in TVItemListMikeScenario
                                               where c.ParentID == p.TVItemID
                                               select p).Distinct().ToList())
        {
            if (!TVItemIDList.Where(c => c == tvItemMikeScenario.ParentID).Any())
            {
                TVItemIDList.Add((int)tvItemMikeScenario.ParentID);
            }
        }

        foreach (TVItem tvItemMWQMSite in (from c in TVItemList
                                           from p in TVItemListMWQMSite
                                           where c.ParentID == p.TVItemID
                                           select p).Distinct().ToList())
        {
            if (!TVItemIDList.Where(c => c == tvItemMWQMSite.ParentID).Any())
            {
                TVItemIDList.Add((int)tvItemMWQMSite.ParentID);
            }
        }

        foreach (TVItem tvItemMWQMSite in (from c in TVItemList
                                           from p in TVItemListAllOthers
                                           where c.ParentID == p.TVItemID
                                           select p).Distinct().ToList())
        {
            if (!TVItemIDList.Where(c => c == tvItemMWQMSite.TVItemID).Any())
            {
                TVItemIDList.Add((int)tvItemMWQMSite.TVItemID);
            }
        }

        return await Task.FromResult(TVItemIDList);
    }
}

