namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> FillLoginRequiredAsync()
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfLoginIsRequired));

        contact = (from c in dbManage.Contacts
                   select c).FirstOrDefault();

        if (contact == null || contact.IsLoggedIn == null || !(bool)contact.IsLoggedIn)
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoginRequired));

            LoginRequired = true;
            return await Task.FromResult(true);
        }

        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.AlreadyLoggedIn));

        LoginRequired = false;

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

