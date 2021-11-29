namespace CSSPWebAPIs.Controllers;

public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
{
    [Route("GetWithContactTVItemID/{ContactTVItemID}")]
    [HttpGet]
    public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemIDAsync(int ContactTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVTypeUserAuthorizationDBService.GetTVTypeUserAuthorizationWithContactTVItemIDAsync(ContactTVItemID);
    }
}

