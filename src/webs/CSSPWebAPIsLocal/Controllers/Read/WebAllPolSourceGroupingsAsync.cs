namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllPolSourceGroupings")]
    [HttpGet]
    public async Task<ActionResult<WebAllPolSourceGroupings>> WebAllPolSourceGroupingsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllPolSourceGroupings>(WebTypeEnum.WebAllPolSourceGroupings);
    }
}

