namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void EnabledOrDisableRegisterButton()
    {
        butRegister.Enabled = false;
        bool CanEnableRegisterButton = true;
        if (textBoxLoginEmailRegister.Text.Length < 6)
        {
            CanEnableRegisterButton = false;
        }
        if (textBoxFirstNameRegister.Text.Length < 1)
        {
            CanEnableRegisterButton = false;
        }
        if (textBoxLastNameRegister.Text.Length < 1)
        {
            CanEnableRegisterButton = false;
        }
        if (textBoxInitialRegister.Text.Length < 1)
        {
            CanEnableRegisterButton = false;
        }
        if (textBoxPasswordRegister.Text.Length < 6)
        {
            CanEnableRegisterButton = false;
        }

        if (textBoxConfirmPasswordRegister.Text.Length < 6)
        {
            CanEnableRegisterButton = false;
        }

        if (textBoxPasswordRegister.Text != textBoxConfirmPasswordRegister.Text)
        {
            CanEnableRegisterButton = false;
        }

        Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");

        Match match = regex.Match(textBoxLoginEmailRegister.Text);

        if (!match.Success)
        {
            CanEnableRegisterButton = false;
        }

        if (CanEnableRegisterButton)
        {
            butLogin.Enabled = true;
        }
    }
}