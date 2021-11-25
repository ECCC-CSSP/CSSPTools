namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncTideLocation(TideLocation tideLocationOriginal, TideLocation tideLocationLocal)
    {
        if (tideLocationLocal != null)
        {
            tideLocationOriginal = tideLocationLocal;
        }
    }
}

