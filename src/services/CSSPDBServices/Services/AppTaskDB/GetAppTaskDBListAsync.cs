namespace CSSPDBServices;

public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
{
    public async Task<ActionResult<List<AppTask>>> GetAppTaskDBListAsync(int skip = 0, int take = 100)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<AppTask> appTaskList = (from c in db.AppTasks.AsNoTracking() orderby c.AppTaskID select c).Skip(skip).Take(take).ToList();

        return await Task.FromResult(Ok(appTaskList));
    }
}


