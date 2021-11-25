namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListAllOfChangedTVItemLinkAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList1 = (from t in db.TVItems
                                   from tl in db.TVItemLinks
                                   where t.TVItemID == tl.FromTVItemID
                                   && (tl.FromTVType == TVTypeEnum.Contact
                                   || tl.FromTVType == TVTypeEnum.LiftStation
                                   || tl.FromTVType == TVTypeEnum.Infrastructure)
                                   && tl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   select (int)t.ParentID).Distinct().ToList();

        TVItemIDList1 = TVItemIDList1.Concat((from tl in db.TVItemLinks
                                              where tl.FromTVType == TVTypeEnum.Municipality
                                              && tl.LastUpdateDate_UTC >= LastWriteTimeUtc
                                              select tl.FromTVItemID).Distinct().ToList()).Distinct().ToList();

        return await Task.FromResult(TVItemIDList1);
    }
}

