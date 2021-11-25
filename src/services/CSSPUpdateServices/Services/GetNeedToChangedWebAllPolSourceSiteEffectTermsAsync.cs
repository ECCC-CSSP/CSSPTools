namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<bool> GetNeedToChangedWebAllPolSourceSiteEffectTermsAsync(DateTime LastWriteTimeUtc)
    {
        bool exist = (from c in db.PolSourceSiteEffects
                      where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                      select c).Any();

        if (exist)
        {
            return await Task.FromResult(exist);
        }

        exist = (from c in db.PolSourceSiteEffectTerms
                 where c.LastUpdateDate_UTC >= LastWriteTimeUtc
                 select c).Any();


        return await Task.FromResult(exist);
    }
}

