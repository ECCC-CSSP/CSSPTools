namespace CSSPDBAzureServices;
public partial interface IAppTaskAzureService
{
    Task<ActionResult<AppTaskModel>> AddAppTaskAzureAsync(AppTaskModel postAppTaskModel);
    Task<ActionResult<AppTaskModel>> DeleteAppTaskAzureAsync(int appTaskID);
    Task<ActionResult<List<AppTaskModel>>> GetAllAppTaskAzureAsync();
    Task<ActionResult<AppTaskModel>> ModifyAppTaskAzureAsync(AppTaskModel postAppTaskModel);
}
