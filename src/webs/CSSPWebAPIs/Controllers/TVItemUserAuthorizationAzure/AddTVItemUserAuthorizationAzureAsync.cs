namespace CSSPWebAPIs.Controllers;

public partial class TVItemUserAuthorizationAzureController : ControllerBase, ITVItemUserAuthorizationAzureController
{
    [HttpPost]
    public async Task<ActionResult<TVItemUserAuthorization>> AddTVItemUserAuthorizationAzureAsync(TVItemUserAuthorization tvItemUserAuthorization)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await TVItemUserAuthorizationAzureService.AddTVItemUserAuthorizationAzureAsync(tvItemUserAuthorization);
    }
}

