namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebTideSites/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebTideSites>> WebTideSitesAsync(int TVItemID)
    {
        // TVItemID = ProvinceTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);
    }
}

