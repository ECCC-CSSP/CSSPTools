namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMWQMSamples2021_2060/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMWQMSamples>> WebMWQMSamples2021_2060Async(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMWQMSamples>(WebTypeEnum.WebMWQMSamples2021_2060, TVItemID);
    }
}

