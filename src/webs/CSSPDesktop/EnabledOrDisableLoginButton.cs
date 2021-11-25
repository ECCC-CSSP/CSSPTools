namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void EnabledOrDisableLoginButton()
    {
        butLogin.Enabled = false;
        bool CanEnableLoginButton = true;
        if (textBoxLoginEmailLogin.Text.Length < 6)
        {
            CanEnableLoginButton = false;
        }
        if (textBoxPasswordLogin.Text.Length < 6)
        {
            CanEnableLoginButton = false;
        }

        Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");

        Match match = regex.Match(textBoxLoginEmailLogin.Text);

        if (!match.Success)
        {
            CanEnableLoginButton = false;
        }

        if (CanEnableLoginButton)
        {
            butLogin.Enabled = true;
        }
    }
}