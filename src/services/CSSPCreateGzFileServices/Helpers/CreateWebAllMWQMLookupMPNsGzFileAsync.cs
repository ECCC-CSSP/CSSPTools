namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllMWQMLookupMPNsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = new WebAllMWQMLookupMPNs();

        try
        {
            webAllMWQMLookupMPNs.MWQMLookupMPNList = await GetMWQMLookupMPNAsync();

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllMWQMLookupMPNs>(webAllMWQMLookupMPNs, $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllMWQMLookupMPNs>(webAllMWQMLookupMPNs, $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz")) return await Task.FromResult(false);
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

