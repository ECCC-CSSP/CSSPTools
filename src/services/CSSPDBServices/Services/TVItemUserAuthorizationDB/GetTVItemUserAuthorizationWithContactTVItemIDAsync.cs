namespace CSSPDBServices;

public partial class TVItemUserAuthorizationDBService : ControllerBase, ITVItemUserAuthorizationDBService
{
    public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemIDAsync(int ContactTVItemID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations.AsNoTracking()
                                                                     where c.ContactTVItemID == ContactTVItemID
                                                                     select c).ToList();

        return await Task.FromResult(Ok(tvItemUserAuthorizationList));
    }
}

