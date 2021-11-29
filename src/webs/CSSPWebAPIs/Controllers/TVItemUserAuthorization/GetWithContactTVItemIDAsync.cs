namespace CSSPWebAPIs.Controllers;

public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
{
    [Route("GetWithContactTVItemID/{ContactTVItemID}")]
    [HttpGet]
    public async Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemIDAsync(int ContactTVItemID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVItemUserAuthorizationDBService.GetTVItemUserAuthorizationWithContactTVItemIDAsync(ContactTVItemID);
    }
}

