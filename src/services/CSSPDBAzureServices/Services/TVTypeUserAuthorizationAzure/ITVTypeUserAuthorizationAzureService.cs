namespace CSSPDBAzureServices;

public partial interface ITVTypeUserAuthorizationAzureService
{
    Task<ActionResult<TVTypeUserAuthorization>> AddTVTypeUserAuthorizationAzureAsync(TVTypeUserAuthorization tvTypeUserAuthorization);
    Task<ActionResult<TVTypeUserAuthorization>> DeleteTVTypeUserAuthorizationAzureAsync(int TVTypeUserAuthorizationID);
    Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID);
}
