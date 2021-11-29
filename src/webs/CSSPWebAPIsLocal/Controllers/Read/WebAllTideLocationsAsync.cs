namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllTideLocations")]
    [HttpGet]
    public async Task<ActionResult<WebAllTideLocations>> WebAllTideLocationsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllTideLocations>(WebTypeEnum.WebAllTideLocations);
    }
}

