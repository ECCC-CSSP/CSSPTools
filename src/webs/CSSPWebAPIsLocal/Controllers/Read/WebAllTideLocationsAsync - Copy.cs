namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllUseOfSites")]
    [HttpGet]
    public async Task<ActionResult<WebAllUseOfSites>> WebAllUseOfSitesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllUseOfSites>(WebTypeEnum.WebAllUseOfSites);
    }
}

