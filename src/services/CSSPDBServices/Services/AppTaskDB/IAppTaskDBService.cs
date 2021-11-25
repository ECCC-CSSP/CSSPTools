namespace CSSPDBServices;

public partial interface IAppTaskDBService
{
    Task<ActionResult<bool>> DeleteAppTaskDBAsync(int AppTaskID);
    Task<ActionResult<List<AppTask>>> GetAppTaskDBListAsync(int skip = 0, int take = 100);
    Task<ActionResult<AppTask>> GetAppTaskDBWithAppTaskIDAsync(int AppTaskID);
    Task<ActionResult<AppTask>> AddAppTaskDBAsync(AppTask apptask);
    Task<ActionResult<AppTask>> ModifyAppTaskDBAsync(AppTask apptask);
}
