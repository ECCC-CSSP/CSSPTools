namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMonitoringRoutineStatsProvince/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMonitoringRoutineStatsProvince>> WebMonitoringRoutineStatsProvinceAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMonitoringRoutineStatsProvince>(WebTypeEnum.WebMonitoringRoutineStatsProvince, TVItemID);
    }
}

