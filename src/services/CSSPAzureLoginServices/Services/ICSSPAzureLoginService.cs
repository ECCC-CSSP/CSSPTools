namespace CSSPAzureLoginServices.Services;

public interface ICSSPAzureLoginService
{
    Task<ActionResult<bool>> AzureLoginAsync(LoginModel loginModel);
}

