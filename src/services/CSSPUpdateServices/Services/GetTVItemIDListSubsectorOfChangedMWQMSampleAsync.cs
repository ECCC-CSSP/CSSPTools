namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSampleAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from t in db.TVItems
                                  from c in db.MWQMSamples
                                  from l in db.MWQMSampleLanguages
                                  where t.TVItemID == c.MWQMSiteTVItemID
                                  && c.MWQMSampleID == l.MWQMSampleID
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select (int)t.ParentID).Distinct().ToList();

        return await Task.FromResult(TVItemIDList);
    }
}

