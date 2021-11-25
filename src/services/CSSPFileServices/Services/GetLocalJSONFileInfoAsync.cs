namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<LocalFileInfo>> GetLocalJSONFileInfoAsync(string FileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(string FileName) - FileName: { FileName }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"] }{FileName}");

        if (!fi.Exists)
        {
            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName));
        }

        LocalFileInfo localFileInfo = new LocalFileInfo() { ParentTVItemID = 0, FileName = fi.Name, Length = fi.Length / 1024 };

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(localFileInfo));
    }
}

