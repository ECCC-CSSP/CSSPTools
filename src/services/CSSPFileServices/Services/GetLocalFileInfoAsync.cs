namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<LocalFileInfo>> GetLocalFileInfoAsync(int ParentTVItemID, string FileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID }  FileName: { FileName }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        FileInfo fi = new FileInfo($"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\{FileName}");

        if (!fi.Exists)
        {
            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName));
        }

        LocalFileInfo localFileInfo = new LocalFileInfo() { ParentTVItemID = ParentTVItemID, FileName = fi.Name, Length = fi.Length / 1024 };

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(localFileInfo));
    }
}

