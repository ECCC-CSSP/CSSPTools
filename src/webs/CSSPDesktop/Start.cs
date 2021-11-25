namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void Start()
    {
        butStart.Enabled = false;
        butStop.Enabled = true;
        CSSPDesktopService.StartAsync();
    }
}