namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllHelpDocsAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.HelpDocs
                      where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        return await Task.FromResult(exist);
    }
}

