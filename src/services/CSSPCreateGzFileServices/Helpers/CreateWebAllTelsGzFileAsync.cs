namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllTelsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        TVItem TVItemRoot = await GetTVItemRootAsync();

        WebAllTels webAllTels = new WebAllTels();

        try
        {
            webAllTels.TelList = await GetAllTelAsync();

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllTels>(webAllTels, $"{WebTypeEnum.WebAllTels }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllTels>(webAllTels, $"{WebTypeEnum.WebAllTels }.gz")) return await Task.FromResult(false);
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

