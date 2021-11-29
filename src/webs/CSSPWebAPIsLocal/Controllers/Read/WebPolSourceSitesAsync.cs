namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebPolSourceSites/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebPolSourceSites>> WebPolSourceSitesAsync(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);
    }
}

