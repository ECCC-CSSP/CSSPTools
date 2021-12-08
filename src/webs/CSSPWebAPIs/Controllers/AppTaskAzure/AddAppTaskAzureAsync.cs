namespace CSSPWebAPIs.Controllers;

public partial class AppTaskAzureController : ControllerBase, IAppTaskAzureController
{
    [HttpPost]
    public async Task<ActionResult<AppTaskModel>> AddAppTaskAzureAsync(AppTaskModel appTaskModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AppTaskAzureService.AddAppTaskAzureAsync(appTaskModel);
    }
}

