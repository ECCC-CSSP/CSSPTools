using System.Threading;

namespace CSSPWebAPIs.Controllers;

public partial class AuthController : ControllerBase, IAuthController
{
    [Route("Token")]
    [HttpPost]
    //[AllowAnonymous]
    public async Task<ActionResult<Contact>> TokenAsync(LoginModel loginModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await ContactDBService.LoginDBAsync(loginModel);
    }
}

