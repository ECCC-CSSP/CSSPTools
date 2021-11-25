namespace CSSPDBServices;
public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
{
    public async Task<ActionResult<bool>> DeleteAppTaskDBAsync(int AppTaskID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        AppTask appTask = (from c in db.AppTasks
                           where c.AppTaskID == AppTaskID
                           select c).FirstOrDefault();

        if (appTask == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));
            return await Task.FromResult(BadRequest(errRes));
        }

        try
        {
            db.AppTasks.Remove(appTask);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(true));
    }
}