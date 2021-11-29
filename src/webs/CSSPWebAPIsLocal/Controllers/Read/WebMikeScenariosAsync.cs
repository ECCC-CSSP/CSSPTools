namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMikeScenarios/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMikeScenarios>> WebMikeScenariosAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);
    }
}

