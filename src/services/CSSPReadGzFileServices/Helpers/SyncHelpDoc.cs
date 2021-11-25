namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncHelpDoc(HelpDoc helpDocOriginal, HelpDoc helpDocLocal)
    {
        if (helpDocLocal != null)
        {
            helpDocOriginal = helpDocLocal;
        }
    }
}

