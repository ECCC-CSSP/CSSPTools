namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllPolSourceGroupingsAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.PolSourceGroupings
                      where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.PolSourceGroupings
                 from cl in db.PolSourceGroupingLanguages
                 where c.PolSourceGroupingID == cl.PolSourceGroupingID
                 && cl.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select cl).Any();


        return await Task.FromResult(exist);
    }
}

