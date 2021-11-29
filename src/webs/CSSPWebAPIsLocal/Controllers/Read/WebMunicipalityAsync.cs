namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMunicipality/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMunicipality>> WebMunicipalityAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);
    }
}

