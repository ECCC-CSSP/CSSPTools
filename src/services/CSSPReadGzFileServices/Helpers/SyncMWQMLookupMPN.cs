namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncMWQMLookupMPN(MWQMLookupMPN mwqmLookupMPNOriginal, MWQMLookupMPN mwqmLookupMPNLocal)
    {
        if (mwqmLookupMPNLocal != null)
        {
            mwqmLookupMPNOriginal.DBCommand = mwqmLookupMPNLocal.DBCommand;
            mwqmLookupMPNOriginal.LastUpdateContactTVItemID = mwqmLookupMPNLocal.LastUpdateContactTVItemID;
            mwqmLookupMPNOriginal.LastUpdateDate_UTC = mwqmLookupMPNLocal.LastUpdateDate_UTC;
            mwqmLookupMPNOriginal.MPN_100ml = mwqmLookupMPNLocal.MPN_100ml;
            mwqmLookupMPNOriginal.Tubes01 = mwqmLookupMPNLocal.Tubes01;
            mwqmLookupMPNOriginal.Tubes1 = mwqmLookupMPNLocal.Tubes1;
            mwqmLookupMPNOriginal.Tubes10 = mwqmLookupMPNLocal.Tubes10;
        }
    }
}

