namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedLabSheetAsync(DateTime LastWriteTimeUtc)
    {
        List<int> TVItemIDList = (from c in db.LabSheets
                                  from l in db.LabSheetDetails
                                  from ld in db.LabSheetTubeMPNDetails
                                  where c.LabSheetID == l.LabSheetID
                                  && l.LabSheetDetailID == ld.LabSheetDetailID
                                  && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || l.LastUpdateDate_UTC >= LastWriteTimeUtc
                                  || ld.LastUpdateDate_UTC >= LastWriteTimeUtc)
                                  select c.SubsectorTVItemID).Distinct().ToList();

        return await Task.FromResult(TVItemIDList);
    }
}
