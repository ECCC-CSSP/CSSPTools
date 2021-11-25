namespace CSSPDBServices;

public partial interface IContactDBService
{
    Task<ActionResult<Contact>> LoginDBAsync(LoginModel loginModel);
    Task<ActionResult<string>> GetAzureStoreHashAsync();
    Task<ActionResult<string>> GetGoogleMapKeyHashAsync();
}

