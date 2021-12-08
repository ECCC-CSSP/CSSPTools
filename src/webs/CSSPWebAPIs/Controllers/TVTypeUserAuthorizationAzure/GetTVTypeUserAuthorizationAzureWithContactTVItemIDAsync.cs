namespace CSSPWebAPIs.Controllers;

public partial class TVTypeUserAuthorizationAzureController : ControllerBase, ITVTypeUserAuthorizationAzureController
{
    [Route("{ContactTVItemID}")]
    [HttpGet]
    public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVTypeUserAuthorizationAzureService.GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(ContactTVItemID);
    }
}

