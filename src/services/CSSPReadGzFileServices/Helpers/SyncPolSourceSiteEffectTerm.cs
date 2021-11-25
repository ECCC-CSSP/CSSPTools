namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncPolSourceSiteEffectTerm(PolSourceSiteEffectTerm polSourceSiteEffectTermOriginal, PolSourceSiteEffectTerm polSourceSiteEffectTermLocal)
    {
        if (polSourceSiteEffectTermLocal != null)
        {
            polSourceSiteEffectTermOriginal = polSourceSiteEffectTermLocal;
        }
    }
}

