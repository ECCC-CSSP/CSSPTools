namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoListAsync(int ParentTVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID) - ParentTVItemID: { ParentTVItemID }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        List<LocalFileInfo> LocalFileList = new List<LocalFileInfo>();

        DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\");

        if (!di.Exists)
        {
            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotFindDirectory_, di.FullName));
        }

        List<FileInfo> FileInfoList = di.GetFiles().ToList();

        foreach (FileInfo fi in FileInfoList)
        {
            LocalFileList.Add(new LocalFileInfo() { ParentTVItemID = ParentTVItemID, FileName = fi.Name, Length = fi.Length / 1024 });
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(LocalFileList));
    }
}

