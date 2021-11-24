namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebHydrometricSitesGzFileAsync(int ProvinceTVItemID)
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

        WebHydrometricSites webHydrometricSites = new WebHydrometricSites();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webHydrometricSites.TVItemModel, webHydrometricSites.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

            if (!await FillHydrometricSiteModelListAsync(webHydrometricSites.HydrometricSiteModelList, TVItemProvince)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebHydrometricSites>(webHydrometricSites, $"{ WebTypeEnum.WebHydrometricSites }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
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

