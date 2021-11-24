namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMunicipalityGzFileAsync(int MunicipalityTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(MunicipalityTVItemID: { MunicipalityTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemMunicipality = await GetTVItemWithTVItemIDAsync(MunicipalityTVItemID);

        if (TVItemMunicipality == null || TVItemMunicipality.TVType != TVTypeEnum.Municipality)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", MunicipalityTVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebMunicipality webMunicipality = new WebMunicipality();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webMunicipality.TVItemModel, webMunicipality.TVItemModelParentList, TVItemMunicipality)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webMunicipality.TVFileModelList, TVItemMunicipality)) return await Task.FromResult(false);

            if (!await FillChildListTVItemContactModelListAsync(webMunicipality.MunicipalityContactModelList, TVItemMunicipality)) return await Task.FromResult(false);

            if (!await FillInfrastructureModelListAsync(webMunicipality.InfrastructureModelList, TVItemMunicipality)) return await Task.FromResult(false);

            webMunicipality.MunicipalityTVItemLinkList = await GetInfrastructureTVItemLinkListUnderMunicipalityAsync(TVItemMunicipality);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMunicipality>(webMunicipality, $"{ WebTypeEnum.WebMunicipality }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
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

