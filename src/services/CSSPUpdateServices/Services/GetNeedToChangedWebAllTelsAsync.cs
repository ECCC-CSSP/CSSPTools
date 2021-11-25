namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllTelsAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.TVItems
                      where c.TVType == TVTypeEnum.Tel
                      && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 where c.TVItemID == cl.TVItemID
                 && c.TVType == TVTypeEnum.Tel
                 && cl.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select cl).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.Tels
                 where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select c).Any();

        return await Task.FromResult(exist);
    }
}

