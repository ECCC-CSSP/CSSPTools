namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllMWQMLookupMPNs")]
    [HttpGet]
    public async Task<ActionResult<WebAllMWQMLookupMPNs>> WebAllMWQMLookupMPNsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs);
    }
}

