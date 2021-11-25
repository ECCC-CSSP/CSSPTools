namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> LogoffAsync()
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Logoff));

        Contact contactToModify = (from c in dbManage.Contacts
                                   where c.ContactTVItemID == contact.ContactTVItemID
                                   select c).FirstOrDefault();

        if (contactToModify != null)
        {
            contactToModify.IsLoggedIn = false;
            LoginRequired = true;

            try
            {
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                return await Task.FromResult(true);
            }
        }

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

