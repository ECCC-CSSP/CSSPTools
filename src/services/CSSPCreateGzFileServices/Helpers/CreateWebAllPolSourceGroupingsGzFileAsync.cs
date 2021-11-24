namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllPolSourceGroupingsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        WebAllPolSourceGroupings webAllPolSourceGroupings = new WebAllPolSourceGroupings();

        try
        {
            if (!await FillPolSourceGroupingModelListAsync(webAllPolSourceGroupings.PolSourceGroupingModelList)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz")) return await Task.FromResult(false);
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

