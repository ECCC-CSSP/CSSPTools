namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameterAsync(DateTime LastWriteTimeUtc)
    {
        List<int> subsectorTVItemIDList = (from c in db.MWQMAnalysisReportParameters
                                           where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                                           select c.SubsectorTVItemID).Distinct().ToList();

        return await Task.FromResult(subsectorTVItemIDList);
    }
}

