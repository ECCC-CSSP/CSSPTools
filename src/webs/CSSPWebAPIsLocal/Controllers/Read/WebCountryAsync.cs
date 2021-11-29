namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebCountry/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebCountry>> WebCountryAsync(int TVItemID)
    {
        // TVItemID = CountryTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);
    }
}

