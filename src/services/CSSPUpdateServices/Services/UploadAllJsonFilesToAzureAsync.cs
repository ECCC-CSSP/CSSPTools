namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> UploadAllJsonFilesToAzureAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
        
        var actionRes = await CreateGzFileService.CreateAllGzFilesAsync();
        if (((ObjectResult)actionRes.Result).StatusCode != 200)
        {
            CSSPLogService.AppendError($"{ CSSPCultureServicesRes.ErrorWhileCreateAllGzFiles  }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

