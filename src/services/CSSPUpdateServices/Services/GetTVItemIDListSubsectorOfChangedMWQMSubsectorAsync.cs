namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSubsectorAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from c in db.MWQMSubsectors
                                  from l in db.MWQMSubsectorLanguages
                                  where c.MWQMSubsectorID == l.MWQMSubsectorID
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || l.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select c.MWQMSubsectorTVItemID).Distinct().ToList();

        return await Task.FromResult(TVItemIDList);
    }
}

