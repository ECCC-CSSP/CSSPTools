namespace CSSPDBServices;

public partial interface ITVTypeUserAuthorizationDBService
{
    Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemIDAsync(int ContactTVItemID);
}
