namespace CSSPWebAPIs.Controllers;

public partial interface ITVItemUserAuthorizationController
{
    Task<ActionResult<List<TVItemUserAuthorization>>> GetWithContactTVItemIDAsync(int ContactTVItemID);
}
