namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMWQMRunsGzFileAsync(int SubsectorTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SubsectorTVItemID: { SubsectorTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemSubsector = await GetTVItemWithTVItemIDAsync(SubsectorTVItemID);

        if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebMWQMRuns webMWQMRuns = new WebMWQMRuns();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webMWQMRuns.TVItemModel, webMWQMRuns.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

            if (!await FillMWQMRunModelListAsync(webMWQMRuns.MWQMRunModelList, TVItemSubsector, TVTypeEnum.MWQMRun)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMWQMRuns>(webMWQMRuns, $"{ WebTypeEnum.WebMWQMRuns }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMWQMRuns>(webMWQMRuns, $"{ WebTypeEnum.WebMWQMRuns }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

