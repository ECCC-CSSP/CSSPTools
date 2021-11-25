namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllSearchAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.TVItems
                      from cl in db.TVItemLanguages
                      where c.TVItemID == cl.TVItemID
                      && (c.TVType == TVTypeEnum.Country
                      || c.TVType == TVTypeEnum.Province
                      || c.TVType == TVTypeEnum.Area
                      || c.TVType == TVTypeEnum.Sector
                      || c.TVType == TVTypeEnum.Subsector
                      || c.TVType == TVTypeEnum.Municipality)
                      && (c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      || cl.LastUpdateDate_UTC >= LastWriteTimeUtc)
                      select c).Any();

        return await Task.FromResult(exist);
    }
}

