//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form
//{
//    #region LoginEvents
//    private void butLogin_Click(object sender, EventArgs e)
//    {
//        butLogin.Enabled = false;
//        butLogin.Text = CSSPCultureDesktopRes.LoggingIn;
//        LoginAsync().GetAwaiter().GetResult();
//        butLogin.Text = CSSPCultureDesktopRes.butLoginText;
//        butLogin.Enabled = true;
//    }
//    private void linkLabelGotoRegister_Click(object sender, EventArgs e)
//    {
//        ShowPanels(ShowPanelEnum.Register);
//    }
//    private void textBoxLoginEmailLogin_TextChanged(object sender, EventArgs e)
//    {
//        EnabledOrDisableLoginButton();
//    }
//    private void textBoxPasswordLogin_TextChanged(object sender, EventArgs e)
//    {
//        EnabledOrDisableLoginButton();
//    }
//    #endregion LoginEvents
//}
