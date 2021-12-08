namespace CSSPWebAPIs.Controllers;

public partial interface ITVItemUserAuthorizationAzureController
{
    Task<ActionResult<TVItemUserAuthorization>> AddTVItemUserAuthorizationAzureAsync(TVItemUserAuthorization tvItemUserAuthorization);
    Task<ActionResult<TVItemUserAuthorization>> DeleteTVItemUserAuthorizationAzureAsync(int TVItemUserAuthorizationID);
    Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID);
}
