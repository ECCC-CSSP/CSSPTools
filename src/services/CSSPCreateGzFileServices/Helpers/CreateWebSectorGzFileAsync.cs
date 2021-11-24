namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebSectorGzFileAsync(int SectorTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SectorTVItemID: { SectorTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemSector = await GetTVItemWithTVItemIDAsync(SectorTVItemID);

        if (TVItemSector == null || TVItemSector.TVType != TVTypeEnum.Sector)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", SectorTVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebSector webSector = new WebSector();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webSector.TVItemModel, webSector.TVItemModelParentList, TVItemSector)) return await Task.FromResult(false);

            if (!await FillChildListTVItemModelListAsync(webSector.TVItemModelSubsectorList, TVItemSector, TVTypeEnum.Subsector)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webSector.TVFileModelList, TVItemSector)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebSector>(webSector, $"{ WebTypeEnum.WebSector }_{ SectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebSector>(webSector, $"{ WebTypeEnum.WebSector }_{ SectorTVItemID }.gz")) return await Task.FromResult(false);
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
