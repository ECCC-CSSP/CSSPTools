namespace CSSPFileServices;

public interface ICSSPFileService
{
    Task<ActionResult<bool>> CreateTempCSVAsync(TableConvertToCSVModel tableConvertToCSVModel);
    Task<ActionResult<bool>> CreateTempPNGAsync(HttpRequest request);
    Task<ActionResult> DownloadTempFileAsync(string FileName);
    Task<ActionResult> DownloadOtherFileAsync(string FileName);
    Task<ActionResult> DownloadFileAsync(int ParentTVItemID, string FileName);
    Task<ActionResult> DownloadJSONFileAsync(string FileName);
    Task<ActionResult<LocalFileInfo>> GetAzureFileInfoAsync(int ParentTVItemID, string FileName);
    Task<ActionResult<LocalFileInfo>> GetAzureJSONFileInfoAsync(string FileName);
    Task<ActionResult<LocalFileInfo>> GetLocalFileInfoAsync(int ParentTVItemID, string FileName);
    Task<ActionResult<LocalFileInfo>> GetLocalJSONFileInfoAsync(string FileName);
    Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoListAsync(int ParentTVItemID);
    Task<ActionResult<bool>> LocalizeAzureFileAsync(int ParentTVItemID, string FileName);
    Task<ActionResult<bool>> LocalizeAzureJSONFileAsync(string FileName);
}
