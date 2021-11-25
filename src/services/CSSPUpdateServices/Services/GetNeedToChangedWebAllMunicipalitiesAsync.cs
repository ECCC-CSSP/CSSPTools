namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllMunicipalitiesAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.TVItems
                      where c.TVType == TVTypeEnum.Municipality
                      && c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 where c.TVItemID == cl.TVItemID
                 && c.TVType == TVTypeEnum.Municipality
                 && cl.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select cl).Any();

        return await Task.FromResult(exist);
    }
}

