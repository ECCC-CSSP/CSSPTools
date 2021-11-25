namespace CSSPDBServices;

public partial interface ITVItemUserAuthorizationDBService
{
    Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemIDAsync(int ContactTVItemID);
}
