namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void Logoff()
    {
        CSSPDesktopService.LogoffAsync();
        textBoxPasswordLogin.Text = "";
        ShowPanels(ShowPanelEnum.Login);
    }
}