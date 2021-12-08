namespace CSSPWebAPIs.Controllers;

public partial class TVItemUserAuthorizationAzureController : ControllerBase, ITVItemUserAuthorizationAzureController
{
    [Route("{ContactTVItemID}")]
    [HttpGet]
    public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVItemUserAuthorizationAzureService.GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(ContactTVItemID);
    }
}

