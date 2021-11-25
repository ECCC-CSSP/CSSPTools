namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListAllOfChangedUseOfSiteAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList1 = (from t in db.UseOfSites
                                   where t.LastUpdateDate_UTC >= LastWriteTimeUtc
                                   select t.SubsectorTVItemID).Distinct().ToList();

        return await Task.FromResult(TVItemIDList1);
    }
}

