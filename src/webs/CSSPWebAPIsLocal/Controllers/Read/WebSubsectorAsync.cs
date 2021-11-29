namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebSubsector/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebSubsector>> WebSubsectorAsync(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);
    }
}

