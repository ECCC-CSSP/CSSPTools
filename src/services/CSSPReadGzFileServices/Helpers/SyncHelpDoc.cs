namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncHelpDoc(HelpDoc helpDocOriginal, HelpDoc helpDocLocal)
    {
        if (helpDocLocal != null)
        {
            helpDocOriginal.DBCommand = helpDocLocal.DBCommand;
            helpDocOriginal.DocHTMLText = helpDocLocal.DocHTMLText;
            helpDocOriginal.LastUpdateContactTVItemID = helpDocLocal.LastUpdateContactTVItemID;
            helpDocOriginal.LastUpdateDate_UTC = helpDocLocal.LastUpdateDate_UTC;
        }
    }
}

