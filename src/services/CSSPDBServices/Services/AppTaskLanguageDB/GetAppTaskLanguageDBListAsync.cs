namespace CSSPDBServices;

public partial class AppTaskLanguageDBService : ControllerBase, IAppTaskLanguageDBService
{
    public async Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageDBListAsync(int skip = 0, int take = 100)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages.AsNoTracking() orderby c.AppTaskLanguageID select c).Skip(skip).Take(take).ToList();

        return await Task.FromResult(Ok(appTaskLanguageList));
    }
}


