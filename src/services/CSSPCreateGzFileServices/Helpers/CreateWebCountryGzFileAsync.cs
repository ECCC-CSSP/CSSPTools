namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebCountryGzFileAsync(int CountryTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(CountryTVItemID: { CountryTVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemCountry = await GetTVItemWithTVItemIDAsync(CountryTVItemID);

        if (TVItemCountry == null || TVItemCountry.TVType != TVTypeEnum.Country)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", CountryTVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebCountry webCountry = new WebCountry();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webCountry.TVItemModel, webCountry.TVItemModelParentList, TVItemCountry)) return await Task.FromResult(false);

            if (!await FillChildListTVItemModelListAsync(webCountry.TVItemModelProvinceList, TVItemCountry, TVTypeEnum.Province)) return await Task.FromResult(false);

            if (!await FillFileModelListAsync(webCountry.TVFileModelList, TVItemCountry)) return await Task.FromResult(false);

            if (!await FillRainExceedanceModelListAsync(webCountry.RainExceedanceModelList, TVItemCountry)) return await Task.FromResult(false);

            if (!await FillEmailDistributionListModelListAsync(webCountry.EmailDistributionListModelList, TVItemCountry)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebCountry>(webCountry, $"{ WebTypeEnum.WebCountry }_{ CountryTVItemID }.gz")) return await Task.FromResult(false);
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

