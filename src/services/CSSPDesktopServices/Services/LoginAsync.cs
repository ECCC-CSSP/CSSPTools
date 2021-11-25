namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> LoginAsync(LoginModel loginModel)
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggingIn));

        await CSSPAzureLoginService.AzureLoginAsync(loginModel);

        if (CSSPLogService.ErrRes.ErrList.Count == 0)
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggedIn));
            LoginRequired = false;

            contact = (from c in dbManage.Contacts
                       select c).FirstOrDefault();
        }
        else
        {
            AppendStatus(new AppendEventArgs(string.Join(",", CSSPLogService.ErrRes.ErrList)));
            LoginRequired = true;
        }

        return await Task.FromResult(true);
    }
}

