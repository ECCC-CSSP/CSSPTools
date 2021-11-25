namespace CSSPDBServices;

public partial class TVTypeUserAuthorizationDBService : ControllerBase, ITVTypeUserAuthorizationDBService
{
    public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemIDAsync(int ContactTVItemID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations.AsNoTracking()
                                                                     where c.ContactTVItemID == ContactTVItemID
                                                                     select c).ToList();

        return await Task.FromResult(Ok(TVTypeUserAuthorizationList));
    }
}

