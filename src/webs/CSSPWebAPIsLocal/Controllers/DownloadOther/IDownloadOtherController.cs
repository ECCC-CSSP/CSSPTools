namespace CSSPWebAPIsLocal.Controllers;

public partial interface IDownloadOtherController
{
    Task<ActionResult> DownloadOtherAsync(string FileName);
}
