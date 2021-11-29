namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllAddresses")]
    [HttpGet]
    public async Task<ActionResult<WebAllAddresses>> WebAllAddressesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllAddresses>(WebTypeEnum.WebAllAddresses);
    }
}

