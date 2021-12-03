namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllPolSourceSiteEffectTermsAsync(WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTermsLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms WebAllPolSourceSiteEffectTermsLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllPolSourceSiteEffectsTermsPolSourceSiteEffectTermList(webAllPolSourceSiteEffectTerms, webAllPolSourceSiteEffectTermsLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllPolSourceSiteEffectsTermsPolSourceSiteEffectTermList(WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms, WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTermsLocal)
    {
        List<PolSourceSiteEffectTerm> polSourceSiteEffectTermLocalList = (from c in webAllPolSourceSiteEffectTermsLocal.PolSourceSiteEffectTermList
                                                                          where c.DBCommand != DBCommandEnum.Original
                                                                          select c).ToList();

        foreach (PolSourceSiteEffectTerm polSourceSiteEffectTermLocal in polSourceSiteEffectTermLocalList)
        {
            PolSourceSiteEffectTerm polSourceSiteEffectTermOriginal = webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Where(c => c.PolSourceSiteEffectTermID == polSourceSiteEffectTermLocal.PolSourceSiteEffectTermID).FirstOrDefault();
            if (polSourceSiteEffectTermOriginal == null)
            {
                webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Add(polSourceSiteEffectTermLocal);
            }
            else
            {
                SyncPolSourceSiteEffectTerm(polSourceSiteEffectTermOriginal, polSourceSiteEffectTermLocal);
            }
        }
    }
}

