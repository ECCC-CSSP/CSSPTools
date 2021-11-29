namespace CSSPWebAPIs.Controllers;

public partial interface IAuthController
{
    Task<ActionResult<Contact>> TokenAsync(LoginModel loginModel);
    Task<ActionResult<string>> AzureStoreHashAsync();
    Task<ActionResult<string>> GoogleMapKeyHashAsync();
}
