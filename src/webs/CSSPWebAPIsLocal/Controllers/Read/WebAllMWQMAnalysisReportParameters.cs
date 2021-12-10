namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllMWQMAnalysisReportParameters")]
    [HttpGet]
    public async Task<ActionResult<WebAllMWQMAnalysisReportParameters>> WebAllMWQMAnalysisReportParametersAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllMWQMAnalysisReportParameters>(WebTypeEnum.WebAllMWQMAnalysisReportParameters);
    }
}

