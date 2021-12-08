namespace CSSPWebAPIs.Controllers;

public partial class AppTaskAzureController : ControllerBase, IAppTaskAzureController
{
    [HttpPut]
    public async Task<ActionResult<AppTaskModel>> ModifyAppTaskAzureAsync(AppTaskModel appTaskModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AppTaskAzureService.ModifyAppTaskAzureAsync(appTaskModel);
    }
}

