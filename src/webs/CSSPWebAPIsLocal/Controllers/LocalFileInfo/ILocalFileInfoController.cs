namespace CSSPWebAPIsLocal.Controllers;

public partial interface ILocalFileInfoController
{
    Task<ActionResult<LocalFileInfo>> GetLocalFileInfoAsync(int ParentTVItemID, string FileName);
    Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoListAsync(int ParentTVItemID);
}
