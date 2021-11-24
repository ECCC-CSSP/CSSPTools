namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebProvinceGzFileAsync(int ProvinceTVItemID)
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

        WebProvince webProvince = new WebProvince();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webProvince.TVItemModel, webProvince.TVItemModelParentList, TVItemProvince)) return await Task.FromResult(false);

            if (!await FillChildListTVItemModelListAsync(webProvince.TVItemModelAreaList, TVItemProvince, TVTypeEnum.Area)) return await Task.FromResult(false);

            if (!await FillChildListTVItemModelListAsync(webProvince.TVItemModelMunicipalityList, TVItemProvince, TVTypeEnum.Municipality)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webProvince.TVFileModelList, TVItemProvince)) return await Task.FromResult(false);

            if (!await FillSamplingPlanModelListAsync(webProvince.SamplingPlanModelList, TVItemProvince)) return await Task.FromResult(false);

            webProvince.MunicipalityWithInfrastructureTVItemIDList = await GetMunicipalityWithInfrastructureTVItemIDListAsync(TVItemProvince);

            if (Local)
            {
                if (!await StoreLocalAsync<WebProvince>(webProvince, $"{ WebTypeEnum.WebProvince }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebProvince>(webProvince, $"{ WebTypeEnum.WebProvince }_{ ProvinceTVItemID }.gz")) return await Task.FromResult(false);
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

