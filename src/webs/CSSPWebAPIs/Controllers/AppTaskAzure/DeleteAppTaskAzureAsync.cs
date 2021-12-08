namespace CSSPWebAPIs.Controllers;

public partial class AppTaskAzureController : ControllerBase, IAppTaskAzureController
{
    [Route("{AppTaskID:int}")]
    [HttpDelete]
    public async Task<ActionResult<AppTaskModel>> DeleteAppTaskAzureAsync(int AppTaskID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AppTaskAzureService.DeleteAppTaskAzureAsync(AppTaskID);
    }
}

