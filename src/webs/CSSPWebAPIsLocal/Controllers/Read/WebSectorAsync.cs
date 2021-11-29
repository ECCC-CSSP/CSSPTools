namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebSector/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebSector>> WebSectorAsync(int TVItemID)
    {
        // TVItemID = SectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);
    }
}

