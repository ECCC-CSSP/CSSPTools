namespace CSSPDBServices;

public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
{
    public async Task<ActionResult<bool>> DeleteAppTaskLanguageDBAsync(int AppTaskLanguageID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages
                                           where c.AppTaskLanguageID == AppTaskLanguageID
                                           select c).FirstOrDefault();

        if (appTaskLanguage == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", AppTaskLanguageID.ToString()));
            return await Task.FromResult(BadRequest(errRes));
        }

        try
        {
            db.AppTaskLanguages.Remove(appTaskLanguage);
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


