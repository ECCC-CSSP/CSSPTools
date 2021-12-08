namespace CSSPWebAPIs.Controllers;

public partial class AuthController : ControllerBase, IAuthController
{
    [Route("Token")]
    [HttpPost]
    public async Task<ActionResult<Contact>> TokenAsync(LoginModel loginModel)
    {
        return await ContactAzureService.LoginAzureAsync(loginModel);
    }
}

