namespace CSSPDBAzureServices;

public partial class TVItemUserAuthorizationAzureService : ControllerBase, ITVItemUserAuthorizationAzureService
{
    public async Task<ActionResult<TVItemUserAuthorization>> DeleteTVItemUserAuthorizationAzureAsync(int TVItemUserAuthorizationID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        TVItemUserAuthorization tvItemUserAuthorizationExist = (from c in dbAzure.TVItemUserAuthorizations
                                                                where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                                                select c).FirstOrDefault();

        if (tvItemUserAuthorizationExist == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", TVItemUserAuthorizationID.ToString()));
            return await Task.FromResult(Unauthorized(errRes));
        }

        dbAzure.TVItemUserAuthorizations.Remove(tvItemUserAuthorizationExist);

        try
        {
            dbAzure.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemUserAuthorization", ex.Message));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(tvItemUserAuthorizationExist));
    }
}

