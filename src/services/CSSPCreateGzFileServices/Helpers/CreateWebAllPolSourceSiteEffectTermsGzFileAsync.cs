namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllPolSourceSiteEffectTermsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = new WebAllPolSourceSiteEffectTerms();

        try
        {
            webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList = await GetPolSourceSiteEffectTermListAsync();

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllPolSourceSiteEffectTerms>(webAllPolSourceSiteEffectTerms, $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllPolSourceSiteEffectTerms>(webAllPolSourceSiteEffectTerms, $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz")) return await Task.FromResult(false);
            }
        }
        catch (Exception ex)
        {
            string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
            CSSPLogService.AppendError($"{ ex.Message } { inner }");
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
