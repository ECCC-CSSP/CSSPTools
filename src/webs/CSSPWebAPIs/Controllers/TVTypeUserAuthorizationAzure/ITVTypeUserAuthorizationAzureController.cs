namespace CSSPWebAPIs.Controllers;

public partial interface ITVTypeUserAuthorizationAzureController
{
    Task<ActionResult<TVTypeUserAuthorization>> AddTVTypeUserAuthorizationAzureAsync(TVTypeUserAuthorization tvTypeUserAuthorization);
    Task<ActionResult<TVTypeUserAuthorization>> DeleteTVTypeUserAuthorizationAzureAsync(int TVTypeUserAuthorizationID);
    Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID);
}
