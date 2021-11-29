namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMonitoringOtherStatsProvince/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMonitoringOtherStatsProvince>> WebMonitoringOtherStatsProvinceAsync(int TVItemID)
    {
        // TVItemID = MunicipalityTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMonitoringOtherStatsProvince>(WebTypeEnum.WebMonitoringOtherStatsProvince, TVItemID);
    }
}

