namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllSearch")]
    [HttpGet]
    public async Task<ActionResult<WebAllSearch>> WebAllSearchAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllSearch>(WebTypeEnum.WebAllSearch);
    }
}

