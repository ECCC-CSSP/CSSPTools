namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllHelpDocs")]
    [HttpGet]
    public async Task<ActionResult<WebAllHelpDocs>> WebAllHelpDocsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs);
    }
}

