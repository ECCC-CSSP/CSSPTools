namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebHydrometricSites/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebHydrometricSites>> WebHydrometricSitesAsync(int TVItemID)
    {
        // TVItemID = ProvinceTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);
    }
}

