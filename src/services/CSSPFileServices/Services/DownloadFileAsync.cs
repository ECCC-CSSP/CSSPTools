namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult> DownloadFileAsync(int ParentTVItemID, string FileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID } FileName: { FileName }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        FileInfo fi = new FileInfo($"{ Configuration["CSSPFilesPath"]}{ParentTVItemID}\\{FileName}");

        if (!fi.Exists)
        {
            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return PhysicalFile(fi.FullName, "application/octet-stream");
    }
}

