namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllReportTypesAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.ReportTypes
                      where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.ReportTypes
                 from cr in db.ReportSections
                 where c.ReportTypeID == cr.ReportTypeID
                 && cr.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select cr).Any();


        return await Task.FromResult(exist);
    }
}

