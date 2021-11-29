namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllEmails")]
    [HttpGet]
    public async Task<ActionResult<WebAllEmails>> WebAllEmailsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllEmails>(WebTypeEnum.WebAllEmails);
    }
}

