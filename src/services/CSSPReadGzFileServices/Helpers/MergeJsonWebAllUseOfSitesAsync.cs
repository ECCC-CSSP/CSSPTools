namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllUseOfSitesAsync(WebAllUseOfSites webAllUseOfSites, WebAllUseOfSites webAllUseOfSitesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllUseOfSites webAllUseOfSites, WebAllUseOfSites webAllUseOfSitesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebSubsectorUseOfSiteList(webAllUseOfSites, webAllUseOfSitesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebSubsectorUseOfSiteList(WebAllUseOfSites webAllUseOfSites, WebAllUseOfSites webAllUseOfSitesLocal)
    {
        List<UseOfSite> UseOfSiteLocalList = (from c in webAllUseOfSitesLocal.UseOfSiteList
                                              where c.SubsectorTVItemID != 0
                                              && c.DBCommand != DBCommandEnum.Original
                                              select c).ToList();

        foreach (UseOfSite useOfSiteLocal in UseOfSiteLocalList)
        {
            UseOfSite useOfSiteOriginal = webAllUseOfSites.UseOfSiteList.Where(c => c.SubsectorTVItemID == useOfSiteLocal.SubsectorTVItemID).FirstOrDefault();
            if (useOfSiteOriginal == null)
            {
                webAllUseOfSites.UseOfSiteList.Add(useOfSiteLocal);
            }
            else
            {
                useOfSiteOriginal = useOfSiteLocal;
            }
        }
    }
}

