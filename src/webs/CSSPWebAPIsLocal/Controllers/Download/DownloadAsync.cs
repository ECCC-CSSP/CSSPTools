namespace CSSPWebAPIsLocal.Controllers;

public partial class DownloadController : ControllerBase, IDownloadController
{
    [Route("{ParentTVItemID:int}/{FileName}")]
    [HttpGet]
    public async Task<ActionResult> DownloadAsync(int ParentTVItemID, string FileName)
    {
        // TVItemID = AreaTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.DownloadFileAsync(ParentTVItemID, FileName);
    }
}

