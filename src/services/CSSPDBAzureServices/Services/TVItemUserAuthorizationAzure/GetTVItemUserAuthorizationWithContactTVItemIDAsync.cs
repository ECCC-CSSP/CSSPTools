namespace CSSPDBAzureServices;

public partial class TVItemUserAuthorizationAzureService : ControllerBase, ITVItemUserAuthorizationAzureService
{
    public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationAzureWithContactTVItemIDAsync(int ContactTVItemID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in dbAzure.TVItemUserAuthorizations.AsNoTracking()
                                                                     where c.ContactTVItemID == ContactTVItemID
                                                                     select c).ToList();

        return await Task.FromResult(Ok(tvItemUserAuthorizationList));
    }
}

