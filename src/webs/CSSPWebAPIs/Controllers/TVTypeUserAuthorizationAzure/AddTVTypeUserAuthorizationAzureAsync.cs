namespace CSSPWebAPIs.Controllers;

public partial class TVTypeUserAuthorizationAzureController : ControllerBase, ITVTypeUserAuthorizationAzureController
{
    [HttpPost]
    public async Task<ActionResult<TVTypeUserAuthorization>> AddTVTypeUserAuthorizationAzureAsync(TVTypeUserAuthorization tvTypeUserAuthorization)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVTypeUserAuthorizationAzureService.AddTVTypeUserAuthorizationAzureAsync(tvTypeUserAuthorization);
    }
}

