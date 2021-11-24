namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllTideLocationsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        WebAllTideLocations webAllTideLocations = new WebAllTideLocations();

        try
        {
            webAllTideLocations.TideLocationList = await GetTideLocationAsync();

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz")) return await Task.FromResult(false);
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

