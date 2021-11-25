namespace CSSPDBServices;

public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
{
    public async Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageDBWithAppTaskLanguageIDAsync(int AppTaskLanguageID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages.AsNoTracking()
                                           where c.AppTaskLanguageID == AppTaskLanguageID
                                           select c).FirstOrDefault();

        if (appTaskLanguage == null)
        {
            return await Task.FromResult(NotFound(""));
        }

        return await Task.FromResult(Ok(appTaskLanguage));
    }
}


