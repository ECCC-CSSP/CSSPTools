namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebLabSheetsGzFileAsync(int SubsectorTVItemID)
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

        WebLabSheets webLabSheets = new WebLabSheets();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webLabSheets.TVItemModel, webLabSheets.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

            if (!await FillLabSheetModelListAsync(webLabSheets.LabSheetModelList, TVItemSubsector)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebLabSheets>(webLabSheets, $"{ WebTypeEnum.WebLabSheets }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebLabSheets>(webLabSheets, $"{ WebTypeEnum.WebLabSheets }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

