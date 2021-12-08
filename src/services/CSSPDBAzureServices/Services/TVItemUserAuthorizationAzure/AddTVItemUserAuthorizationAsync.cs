namespace CSSPDBAzureServices;

public partial class TVItemUserAuthorizationAzureService : ControllerBase, ITVItemUserAuthorizationAzureService
{
    public async Task<ActionResult<TVItemUserAuthorization>> AddTVItemUserAuthorizationAzureAsync(TVItemUserAuthorization tvItemUserAuthorization)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        // need to make sure the tvItemUserAuthorization object has all the required fields

        TVItemUserAuthorization tvItemUserAuthorizationExist = (from c in dbAzure.TVItemUserAuthorizations
                                                                where c.TVAuth == tvItemUserAuthorization.TVAuth
                                                                && c.TVItemID1 == tvItemUserAuthorization.TVItemID1
                                                                && c.TVItemID2 == tvItemUserAuthorization.TVItemID2
                                                                && c.TVItemID3 == tvItemUserAuthorization.TVItemID3
                                                                && c.TVItemID4 == tvItemUserAuthorization.TVItemID4
                                                                && c.ContactTVItemID == tvItemUserAuthorization.ContactTVItemID
                                                                select c).FirstOrDefault();

        if (tvItemUserAuthorizationExist != null)
        {
            return await Task.FromResult(Ok(tvItemUserAuthorizationExist));
        }
        else
        {
            dbAzure.TVItemUserAuthorizations.Add(tvItemUserAuthorization);
            try
            {
                dbAzure.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemUserAuthorization", ex.Message));
                return await Task.FromResult(BadRequest(errRes));
            }
        }

        return await Task.FromResult(Ok(tvItemUserAuthorization));
    }
}

