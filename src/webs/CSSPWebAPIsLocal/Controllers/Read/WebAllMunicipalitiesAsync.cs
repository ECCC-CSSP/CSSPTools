namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllMunicipalities")]
    [HttpGet]
    public async Task<ActionResult<WebAllMunicipalities>> WebAllMunicipalitiesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities);
    }
}

