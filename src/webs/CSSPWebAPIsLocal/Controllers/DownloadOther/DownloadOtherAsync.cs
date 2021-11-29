namespace CSSPWebAPIsLocal.Controllers;

public partial class DownloadOtherController : ControllerBase, IDownloadOtherController
{
    [Route("{FileName}")]
    [HttpGet]
    public async Task<ActionResult> DownloadOtherAsync(string FileName)
    {
        // TVItemID = AreaTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.DownloadOtherFileAsync(FileName);
    }
}

