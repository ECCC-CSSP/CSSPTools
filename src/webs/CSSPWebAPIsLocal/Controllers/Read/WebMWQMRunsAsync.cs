namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMWQMRuns/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMWQMRuns>> WebMWQMRunsAsync(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);
    }
}

