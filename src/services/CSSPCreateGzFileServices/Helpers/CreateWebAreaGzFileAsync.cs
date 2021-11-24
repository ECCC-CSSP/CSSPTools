namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAreaGzFileAsync(int AreaTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(AreaTVItemID: { AreaTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemArea = await GetTVItemWithTVItemIDAsync(AreaTVItemID);

        if (TVItemArea == null || TVItemArea.TVType != TVTypeEnum.Area)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", AreaTVItemID.ToString(), "TVType", TVTypeEnum.Area.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebArea webArea = new WebArea();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webArea.TVItemModel, webArea.TVItemModelParentList, TVItemArea)) return await Task.FromResult(false);

            if (!await FillChildListTVItemModelListAsync(webArea.TVItemModelSectorList, TVItemArea, TVTypeEnum.Sector)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webArea.TVFileModelList, TVItemArea)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebArea>(webArea, $"{ WebTypeEnum.WebArea }_{ AreaTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebArea>(webArea, $"{ WebTypeEnum.WebArea }_{ AreaTVItemID }.gz")) return await Task.FromResult(false);
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

