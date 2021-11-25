namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllMWQMLookupMPNsAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.MWQMLookupMPNs
                      where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        return await Task.FromResult(exist);
    }
}
