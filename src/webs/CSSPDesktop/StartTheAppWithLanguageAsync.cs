//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form 
//{
//    #region StartTheAppWithLanguageAsync
//    private async Task<bool> StartTheAppWithLanguageAsync()
//    {
//        SettingUpAllTextForLanguage();

//        if (!await CSSPDesktopService.FillLoginRequiredAsync()) return await Task.FromResult(false);

//        if (!CSSPDesktopService.LoginRequired)
//        {
//            if (CSSPDesktopService.contact != null && (bool)CSSPDesktopService.contact.HasInternetConnection)
//            {
//                LoginModel loginModel = new LoginModel()
//                {
//                    LoginEmail = CSSPDesktopService.contact.LoginEmail,
//                    Password = CSSPScrambleService.Descramble(CSSPDesktopService.contact.PasswordHash),
//                };

//                if (!await CSSPDesktopService.LoginAsync(loginModel)) return await Task.FromResult(false);
//            }
//            if (!await CSSPDesktopService.FillUpdateIsNeededAsync()) return await Task.FromResult(false);
//        }

//        if (CSSPDesktopService.LoginRequired)
//        {
//            butLogoff.Visible = false;

//            lblContactLoggedIn.Text = "";
//            ShowPanels(ShowPanelEnum.Login);

//            if (CSSPDesktopService.contact != null && !(bool)CSSPDesktopService.contact.HasInternetConnection)
//            {
//                butLogin.Enabled = false;
//                lblInternetRequiredLogin.Visible = true;
//                lblInternetRequiredRegister.Visible = true;
//                lblStatus.Text = CSSPCultureDesktopRes.InternetConnectionRequiredFirstTimeConnecting;
//            }
//            else
//            {
//                butLogin.Enabled = true;
//                lblInternetRequiredLogin.Visible = false;
//                lblInternetRequiredRegister.Visible = false;
//                lblStatus.Text = "";
//            }
//        }
//        else
//        {
//            butLogoff.Visible = true;

//            lblContactLoggedIn.Text = CSSPDesktopService.contact.LoginEmail;
//            ShowPanels(ShowPanelEnum.Commands);
//        }

//        if (!CSSPDesktopService.LoginRequired && CSSPDesktopService.UpdateIsNeeded)
//        {
//            ShowPanels(ShowPanelEnum.Updates);
//        }

//        if (CSSPDesktopService.UpdateIsNeeded)
//        {
//            butShowUpdatePanel.Enabled = true;
//        }
//        else
//        {
//            butShowUpdatePanel.Enabled = false;
//        }

//        return await Task.FromResult(true);
//    }
//    #endregion StartTheAppWithLanguageAsync
//}