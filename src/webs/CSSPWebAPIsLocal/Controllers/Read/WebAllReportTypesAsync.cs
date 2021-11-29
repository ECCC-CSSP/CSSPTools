namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllReportTypes")]
    [HttpGet]
    public async Task<ActionResult<WebAllReportTypes>> WebAllReportTypesAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllReportTypes>(WebTypeEnum.WebAllReportTypes);
    }
}

