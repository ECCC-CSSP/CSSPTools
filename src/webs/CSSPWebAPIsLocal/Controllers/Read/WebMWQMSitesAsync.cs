namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMWQMSites/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMWQMSites>> WebMWQMSitesAsync(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);
    }
}

