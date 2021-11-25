namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void Stop()
    {
        butStart.Enabled = true;
        butStop.Enabled = false;
        CSSPDesktopService.StopAsync();
    }
}