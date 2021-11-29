namespace CSSPWebAPIsLocal.Controllers;

public partial interface IDownloadController
{
    Task<ActionResult> DownloadAsync(int ParentTVItemID, string FileName);
}
