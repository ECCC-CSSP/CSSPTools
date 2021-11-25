namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMWQMLookupMPN(MWQMLookupMPN mwqmLookupMPNOriginal, MWQMLookupMPN mwqmLookupMPNLocal)
    {
        if (mwqmLookupMPNLocal != null)
        {
            mwqmLookupMPNOriginal = mwqmLookupMPNLocal;
        }
    }
}

