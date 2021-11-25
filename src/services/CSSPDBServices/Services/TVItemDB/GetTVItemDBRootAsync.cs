namespace CSSPDBServices;

public partial class TVItemDBService : ControllerBase, ITVItemDBService
{
    public async Task<ActionResult<TVItem>> GetTVItemDBRootAsync()
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        TVItem tvItem = await (from c in db.TVItems.AsNoTracking()
                               where c.TVLevel == 0
                               select c).FirstOrDefaultAsync();

        if (tvItem == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.CouldNotFindRoot);
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(tvItem));
    }
}

