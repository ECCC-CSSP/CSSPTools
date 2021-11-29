namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMonitoringOtherStatsCountry/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMonitoringOtherStatsCountry>> WebMonitoringOtherStatsCountryAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMonitoringOtherStatsCountry>(WebTypeEnum.WebMonitoringOtherStatsCountry, TVItemID);
    }
}

