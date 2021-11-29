namespace CSSPWebAPIsLocal.Controllers;

public partial interface IDownloadTempController
{
    Task<ActionResult> DownloadTempAsync(string FileName);
}
