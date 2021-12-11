namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMWQMSamples2021_2060/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMWQMSamples2021_2060>> WebMWQMSamples2021_2060Async(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMWQMSamples2021_2060>(WebTypeEnum.WebMWQMSamples2021_2060, TVItemID);
    }
}

