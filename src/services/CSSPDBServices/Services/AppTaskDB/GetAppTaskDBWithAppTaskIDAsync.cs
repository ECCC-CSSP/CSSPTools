namespace CSSPDBServices;

public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
{

    public async Task<ActionResult<AppTask>> GetAppTaskDBWithAppTaskIDAsync(int AppTaskID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        AppTask appTask = (from c in db.AppTasks.AsNoTracking()
                           where c.AppTaskID == AppTaskID
                           select c).FirstOrDefault();

        if (appTask == null)
        {
            return await Task.FromResult(NotFound(""));
        }

        return await Task.FromResult(Ok(appTask));
    }
}
