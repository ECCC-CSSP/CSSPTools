namespace CSSPWebAPIs.Controllers;

public partial interface ITVTypeUserAuthorizationController
{
    Task<ActionResult<List<TVTypeUserAuthorization>>> GetWithContactTVItemIDAsync(int ContactTVItemID);
}
