namespace CSSPDBAzureServices;

public partial interface IContactAzureService
{
    Task<ActionResult<Contact>> LoginAzureAsync(LoginModel loginModel);
    Task<ActionResult<string>> GetAzureStoreHashAsync();
    Task<ActionResult<string>> GetGoogleMapKeyHashAsync();
}

