namespace CSSPDBAzureServices;

public partial class TVTypeUserAuthorizationAzureService : ControllerBase, ITVTypeUserAuthorizationAzureService
{
    public async Task<ActionResult<TVTypeUserAuthorization>> AddTVTypeUserAuthorizationAzureAsync(TVTypeUserAuthorization tvTypeUserAuthorization)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        // need to make sure the tvTypeUserAuthorization object has all the required fields

        TVTypeUserAuthorization tvTypeUserAuthorizationExist = (from c in dbAzure.TVTypeUserAuthorizations
                                                                where c.TVAuth == tvTypeUserAuthorization.TVAuth
                                                                && c.TVType == tvTypeUserAuthorization.TVType
                                                                && c.ContactTVItemID == tvTypeUserAuthorization.ContactTVItemID
                                                                select c).FirstOrDefault();

        if (tvTypeUserAuthorizationExist != null)
        {
            return await Task.FromResult(Ok(tvTypeUserAuthorizationExist));
        }
        else
        {
            dbAzure.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);
            try
            {
                dbAzure.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVTypeUserAuthorization", ex.Message));
                return await Task.FromResult(BadRequest(errRes));
            }
        }

        return await Task.FromResult(Ok(tvTypeUserAuthorization));
    }
}

