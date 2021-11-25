namespace CSSPDBServices;

public partial class AppTaskDBService : ControllerBase, IAppTaskDBService
{
    public async Task<ActionResult<AppTask>> AddAppTaskDBAsync(AppTask appTask)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        if (!await ValidateAppTaskDBAsync(new ValidationContext(appTask), ActionDBTypeEnum.Create))
        {
            return await Task.FromResult(BadRequest(errRes));
        }

        try
        {
            db.AppTasks.Add(appTask);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(appTask));
    }
}