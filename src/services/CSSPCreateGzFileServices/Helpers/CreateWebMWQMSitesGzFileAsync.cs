namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMWQMSitesGzFileAsync(int SubsectorTVItemID)
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

        WebMWQMSites webMWQMSites = new WebMWQMSites();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webMWQMSites.TVItemModel, webMWQMSites.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

            if (!await FillMWQMSiteModelListAsync(webMWQMSites.MWQMSiteModelList, TVItemSubsector, TVTypeEnum.MWQMSite)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMWQMSites>(webMWQMSites, $"{ WebTypeEnum.WebMWQMSites }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMWQMSites>(webMWQMSites, $"{ WebTypeEnum.WebMWQMSites }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

