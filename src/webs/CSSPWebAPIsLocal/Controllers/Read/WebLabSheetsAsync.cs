namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebLabSheets/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebLabSheets>> WebLabSheetsAsync(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebLabSheets>(WebTypeEnum.WebLabSheets, TVItemID);
    }
}

