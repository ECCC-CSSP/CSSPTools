namespace CSSPWebAPIs.Controllers;

public partial class TVTypeUserAuthorizationAzureController : ControllerBase, ITVTypeUserAuthorizationAzureController
{
    [Route("{TVTypeUserAuthorizationID}")]
    [HttpDelete]
    public async Task<ActionResult<TVTypeUserAuthorization>> DeleteTVTypeUserAuthorizationAzureAsync(int TVTypeUserAuthorizationID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVTypeUserAuthorizationAzureService.DeleteTVTypeUserAuthorizationAzureAsync(TVTypeUserAuthorizationID);
    }
}

