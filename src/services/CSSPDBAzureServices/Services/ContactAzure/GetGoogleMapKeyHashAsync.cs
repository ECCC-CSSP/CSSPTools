namespace CSSPDBAzureServices;

public partial class ContactAzureService : ControllerBase, IContactAzureService
{
    public async Task<ActionResult<string>> GetGoogleMapKeyHashAsync()
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        string sto = Configuration["GoogleMapKeyHash"];
        if (string.IsNullOrWhiteSpace(sto))
        {
            errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, "Configuration", "GoogleMapKeyHash"));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(sto));
    }
}

