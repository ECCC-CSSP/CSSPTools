namespace CSSPDBAzureServices;

public partial class TVTypeUserAuthorizationAzureService : ControllerBase, ITVTypeUserAuthorizationAzureService
{
    public async Task<ActionResult<TVTypeUserAuthorization>> DeleteTVTypeUserAuthorizationAzureAsync(int TVTypeUserAuthorizationID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        // need to make sure the tvTypeUserAuthorization object has all the required fields

        TVTypeUserAuthorization tvTypeUserAuthorizationExist = (from c in dbAzure.TVTypeUserAuthorizations
                                                                where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                                                select c).FirstOrDefault();

        if (tvTypeUserAuthorizationExist == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", TVTypeUserAuthorizationID.ToString()));
            return await Task.FromResult(Unauthorized(errRes));
        }

        dbAzure.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorizationExist);

        try
        {
            dbAzure.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVTypeUserAuthorization", ex.Message));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(tvTypeUserAuthorizationExist));
    }
}

