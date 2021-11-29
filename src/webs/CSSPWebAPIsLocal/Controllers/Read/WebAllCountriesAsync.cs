namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllCountries")]
    [HttpGet]
    public async Task<ActionResult<WebAllCountries>> WebAllCountriesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllCountries>(WebTypeEnum.WebAllCountries);
    }
}

