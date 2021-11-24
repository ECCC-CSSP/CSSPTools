namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllCountriesGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemRoot = await GetTVItemRootAsync();

        if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                "TVItem", "TVType", TVTypeEnum.Root.ToString()));
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(false);
        }

        WebAllCountries webAllCountries = new WebAllCountries();

        try
        {
            if (!await FillAllCountryTVItemModelListAsync(webAllCountries.TVItemModelList, TVItemRoot)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllCountries>(webAllCountries, $"{ WebTypeEnum.WebAllCountries }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllCountries>(webAllCountries, $"{ WebTypeEnum.WebAllCountries }.gz")) return await Task.FromResult(false);
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

