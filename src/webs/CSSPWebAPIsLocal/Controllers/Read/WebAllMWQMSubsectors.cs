namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllMWQMSubsectors")]
    [HttpGet]
    public async Task<ActionResult<WebAllMWQMSubsectors>> WebAllMWQMSubsectorsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllMWQMSubsectors>(WebTypeEnum.WebAllMWQMSubsectors);
    }
}

