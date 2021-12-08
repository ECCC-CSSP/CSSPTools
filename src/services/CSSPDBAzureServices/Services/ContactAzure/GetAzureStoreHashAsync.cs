namespace CSSPDBAzureServices;

public partial class ContactAzureService : ControllerBase, IContactAzureService
{
    public async Task<ActionResult<string>> GetAzureStoreHashAsync()
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        string AzureStoreHash = Configuration["AzureStoreHash"];
        if (string.IsNullOrWhiteSpace(AzureStoreHash))
        {
            errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, "Configuration", "AzureStoreHash"));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(AzureStoreHash));
    }
}

