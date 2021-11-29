namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebClimateSites/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebClimateSites>> WebClimateSitesAsync(int TVItemID)
    {
        // TVItemID = ProvinceTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);
    }
}

