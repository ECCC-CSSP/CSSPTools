namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ControllerBase, ICSSPAzureLoginService
{
    public async Task<ActionResult<bool>> AzureLoginAsync(LoginModel LoginModel)
    {
        culture = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? "fr-CA" : "en-CA";

        loginModel = LoginModel;

        if (string.IsNullOrWhiteSpace(this.loginModel.LoginEmail))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (string.IsNullOrWhiteSpace(this.loginModel.Password))
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "Password"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await AzureLoginContactAsync();

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await AzureLoginTVItemUserAuthorizationAsync();

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await AzureLoginTVTypeUserAuthorizationAsync();

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        await AzureLoginManageAsync(loginModel);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync())
        {
            CSSPLogService.AppendError(CSSPCultureServicesRes.ErrorInSetLocalLoggedInContactInfo);
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        return await Task.FromResult(Ok(true));
    }
}

