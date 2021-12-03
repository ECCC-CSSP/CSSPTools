namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllHelpDocsAsync(WebAllHelpDocs webAllHelpDocs, WebAllHelpDocs webAllHelpDocsLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllHelpDocs WebAllHelpDocs, WebAllHelpDocs WebAllHelpDocsLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllHelpDocsHelpDocList(webAllHelpDocs, webAllHelpDocsLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllHelpDocsHelpDocList(WebAllHelpDocs webAllHelpDocs, WebAllHelpDocs webAllHelpDocsLocal)
    {
        List<HelpDoc> helpDocLocalList = (from c in webAllHelpDocsLocal.HelpDocList
                                          where c.DBCommand != DBCommandEnum.Original
                                          select c).ToList();

        foreach (HelpDoc helpDocLocal in helpDocLocalList)
        {
            HelpDoc helpDocOriginal = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDocLocal.HelpDocID).FirstOrDefault();
            if (helpDocOriginal == null)
            {
                webAllHelpDocs.HelpDocList.Add(helpDocLocal);
            }
            else
            {
                SyncHelpDoc(helpDocOriginal, helpDocLocal);
            }
        }
    }
}

