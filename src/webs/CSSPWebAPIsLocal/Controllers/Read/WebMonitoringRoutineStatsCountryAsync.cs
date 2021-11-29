namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMonitoringRoutineStatsCountry/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMonitoringRoutineStatsCountry>> WebMonitoringRoutineStatsCountryAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMonitoringRoutineStatsCountry>(WebTypeEnum.WebMonitoringRoutineStatsCountry, TVItemID);
    }
}

