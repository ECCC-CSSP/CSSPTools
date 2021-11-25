namespace CSSPDBServices;

public partial class TVItemDBService : ControllerBase, ITVItemDBService
{
    public async Task<ActionResult<List<TVItem>>> GetTVItemDBStartDateListAsync(int Year, int Month, int Day)
    {
        DateTime StartDate = new DateTime(Year, Month, Day);

        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVItem> tvItemList = await (from c in db.TVItems.AsNoTracking()
                                         where c.LastUpdateDate_UTC >= StartDate
                                         select c).ToListAsync();

        return await Task.FromResult(Ok(tvItemList));
    }
}

