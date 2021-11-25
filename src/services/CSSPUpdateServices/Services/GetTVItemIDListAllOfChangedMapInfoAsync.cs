namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListAllOfChangedMapInfoAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from c in db.MapInfos
                                  from m in db.MapInfoPoints
                                  where c.MapInfoID == m.MapInfoID
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || m.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select c.TVItemID).Distinct().ToList();

        return await Task.FromResult(TVItemIDList);
    }
}

