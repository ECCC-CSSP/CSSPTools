namespace CSSPDBAzureServices;

public partial class TVTypeUserAuthorizationAzureService : ControllerBase, ITVTypeUserAuthorizationAzureService
{
    public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (from c in dbAzure.TVTypeUserAuthorizations.AsNoTracking()
                                                                     where c.ContactTVItemID == ContactTVItemID
                                                                     select c).ToList();

        return await Task.FromResult(Ok(tvTypeUserAuthorizationList));
    }
}

