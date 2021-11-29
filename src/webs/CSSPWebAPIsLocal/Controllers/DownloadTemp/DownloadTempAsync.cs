namespace CSSPWebAPIsLocal.Controllers;

public partial class DownloadTempController : ControllerBase, IDownloadTempController
{
    [Route("{FileName}")]
    [HttpGet]
    public async Task<ActionResult> DownloadTempAsync(string FileName)
    {
        // TVItemID = AreaTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await FileService.DownloadTempFileAsync(FileName);
    }
}

