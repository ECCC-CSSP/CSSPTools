namespace CSSPWebAPIs.Controllers;

public partial class AzureAppTaskController : ControllerBase, IAppTaskController
{
    [HttpPost]
    public async Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel appTaskModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
    }
}

