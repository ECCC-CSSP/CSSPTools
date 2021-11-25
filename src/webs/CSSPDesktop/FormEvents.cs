namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void CSSPDesktopForm_Resize(object sender, EventArgs e)
    {
        RecenterPanels();
    }
    private void CSSPDesktopForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Stop();
    }
}
