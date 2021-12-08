namespace CSSPDBLocalServices;

public partial interface IAppTaskLocalService
{
    Task<ActionResult<AppTaskModel>> AddAppTaskLocalAsync(AppTaskModel appTaskModel);
    Task<ActionResult<AppTaskModel>> DeleteAppTaskLocalAsync(int AppTaskID);
    Task<ActionResult<List<AppTaskModel>>> GetAllAppTaskLocalAsync();
    Task<ActionResult<AppTaskModel>> ModifyAppTaskLocalAsync(AppTaskModel appTaskModel);
}
