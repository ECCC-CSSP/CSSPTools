namespace CSSPDBServices;

public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
{
    public async Task<ActionResult<AppTaskLanguage>> AddAppTaskLanguageDBAsync(AppTaskLanguage appTaskLanguage)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        if (!await ValidateAppTaskLanguageDBAsync(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create))
        {
            return await Task.FromResult(BadRequest(errRes));
        }

        try
        {
            db.AppTaskLanguages.Add(appTaskLanguage);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(appTaskLanguage));
    }
}


