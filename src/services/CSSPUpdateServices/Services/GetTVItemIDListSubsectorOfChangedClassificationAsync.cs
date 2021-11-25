namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedClassificationAsync(DateTime LastWriteTimeUtc)
    {
        List<int> subsectorTVItemIDList = (from t in db.TVItems
                                           from c in db.Classifications
                                           where t.TVItemID == c.ClassificationTVItemID
                                           && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                           select (int)t.ParentID).Distinct().ToList();

        return await Task.FromResult(subsectorTVItemIDList);
    }
}

