namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMikeScenariosGzFileAsync(int MunicipalityTVItemID)
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

        WebMikeScenarios webMikeScenarios = new WebMikeScenarios();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webMikeScenarios.TVItemModel, webMikeScenarios.TVItemModelParentList, TVItemMunicipality)) return await Task.FromResult(false);

            if (!await FillMikeScenarioModelListAsync(webMikeScenarios.TVItemModel, webMikeScenarios.TVItemModelParentList, webMikeScenarios.MikeScenarioModelList, TVItemMunicipality)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMikeScenarios>(webMikeScenarios, $"{ WebTypeEnum.WebMikeScenarios }_{ MunicipalityTVItemID }.gz")) return await Task.FromResult(false);
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

