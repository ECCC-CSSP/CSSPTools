namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebArea/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebArea>> WebAreaAsync(int TVItemID)
    {
        // TVItemID = AreaTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);
    }
}

