namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private async Task<bool> CheckInternetConnectionAsync()
    {
        if (!await CSSPDesktopService.FillContactHasInternetConnectionAsync()) return await Task.FromResult(false);

        if (CSSPDesktopService.contact != null && CSSPDesktopService.contact.HasInternetConnection != null)
        {
            if ((bool)CSSPDesktopService.contact.HasInternetConnection)
            {
                Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.ConnectedOnInternet })";
            }
            else
            {
                Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.NoInternetConnection })";
                butLogoff.Visible = false;
            }
        }

        return await Task.FromResult(true);
    }
}