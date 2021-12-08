namespace CSSPWebAPIs.Controllers;

public partial class TVItemUserAuthorizationAzureController : ControllerBase, ITVItemUserAuthorizationAzureController
{
    [Route("{TVItemUserAuthorizationID}")]
    [HttpDelete]
    public async Task<ActionResult<TVItemUserAuthorization>> DeleteTVItemUserAuthorizationAzureAsync(int TVItemUserAuthorizationID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVItemUserAuthorizationAzureService.DeleteTVItemUserAuthorizationAzureAsync(TVItemUserAuthorizationID);
    }
}

