namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebMWQMSamples1980_2020/{TVItemID:int}")]
    [HttpGet]
    public async Task<ActionResult<WebMWQMSamples1980_2020>> WebMWQMSamples1980_2020Async(int TVItemID)
    {
        // TVItemID = SubsectorTVItemID
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebMWQMSamples1980_2020>(WebTypeEnum.WebMWQMSamples1980_2020, TVItemID);
    }
}

