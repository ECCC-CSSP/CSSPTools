namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebDrogueRunsGzFileAsync(int ProvinceTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(ProvinceTVItemID: { ProvinceTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemProvince = await GetTVItemWithTVItemIDAsync(ProvinceTVItemID);

        if (TVItemProvince == null || TVItemProvince.TVType != TVTypeEnum.Province)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", ProvinceTVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebDrogueRuns webDrogueRuns = new WebDrogueRuns();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webDrogueRuns.TVItemModel, webDrogueRuns.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

            if (!await FillDrogueRunModelAsync(webDrogueRuns.DrogueRunModelList, TVItemProvince)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebDrogueRuns>(webDrogueRuns, $"{ WebTypeEnum.WebDrogueRuns }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebDrogueRuns>(webDrogueRuns, $"{ WebTypeEnum.WebDrogueRuns }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
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
