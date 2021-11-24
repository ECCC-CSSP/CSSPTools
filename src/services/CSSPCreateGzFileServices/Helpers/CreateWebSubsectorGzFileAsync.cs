namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebSubsectorGzFileAsync(int SubsectorTVItemID)
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

        WebSubsector webSubsector = new WebSubsector();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webSubsector.TVItemModel, webSubsector.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

            if (!await FillClassificationModelListAsync(webSubsector.ClassificationModelList, TVItemSubsector, TVTypeEnum.Classification)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webSubsector.TVFileModelList, TVItemSubsector)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebSubsector>(webSubsector, $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

