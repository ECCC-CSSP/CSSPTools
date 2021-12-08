namespace CSSPWebAPIs.Controllers;

public partial interface IAppTaskAzureController
{
    Task<ActionResult<List<AppTaskModel>>> GetAllAppTaskAzureAsync();
    Task<ActionResult<AppTaskModel>> AddAppTaskAzureAsync(AppTaskModel appTaskModel);
    Task<ActionResult<AppTaskModel>> DeleteAppTaskAzureAsync(int AppTaskID);
    Task<ActionResult<AppTaskModel>> ModifyAppTaskAzureAsync(AppTaskModel appTaskModel);
}
