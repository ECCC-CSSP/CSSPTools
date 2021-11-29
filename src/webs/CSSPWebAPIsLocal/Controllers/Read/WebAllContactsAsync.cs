namespace CSSPWebAPIsLocal.Controllers;

public partial class ReadController : ControllerBase, IReadController
{
    [Route("WebAllContacts")]
    [HttpGet]
    public async Task<ActionResult<WebAllContacts>> WebAllContactsAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        return await ReadGzFileService.ReadJSONAsync<WebAllContacts>(WebTypeEnum.WebAllContacts);
    }
}

