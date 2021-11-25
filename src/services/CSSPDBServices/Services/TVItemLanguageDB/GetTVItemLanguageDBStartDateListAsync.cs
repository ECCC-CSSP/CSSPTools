namespace CSSPDBServices;

public partial class TVItemLanguageDBService : ControllerBase, ITVItemLanguageDBService
{
    public async Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageDBStartDateListAsync(int Year, int Month, int Day)
    {
        DateTime StartDate = new DateTime(Year, Month, Day);

        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVItemLanguage> tvItemLanguageList = (from c in db.TVItemLanguages.AsNoTracking()
                                                   where c.LastUpdateDate_UTC >= StartDate
                                                   select c).ToList();

        return await Task.FromResult(Ok(tvItemLanguageList));
    }
}

