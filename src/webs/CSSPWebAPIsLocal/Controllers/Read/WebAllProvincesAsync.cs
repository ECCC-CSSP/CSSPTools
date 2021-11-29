namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllProvinces")]
    [HttpGet]
    public async Task<ActionResult<WebAllProvinces>> WebAllProvincesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllProvinces>(WebTypeEnum.WebAllProvinces);
    }
}

