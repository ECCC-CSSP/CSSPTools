//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form 
//{
//    #region SettingUpAllTextForLanguage
//    private void SettingUpAllTextForLanguage()
//    {
//        CSSPDesktopService.IsEnglish = IsEnglish;

//        if (IsEnglish)
//        {
//            CSSPCultureService.SetCulture("en-CA");
//        }
//        else
//        {
//            CSSPCultureService.SetCulture("fr-CA");
//        }

//        try
//        {
//            if (CSSPDesktopService.contact != null && CSSPDesktopService.contact.HasInternetConnection == null)
//            {
//                Text = CSSPCultureDesktopRes.FormTitleText;
//            }
//            else
//            {
//                if (CSSPDesktopService.contact != null && (bool)CSSPDesktopService.contact.HasInternetConnection)
//                {
//                    Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.ConnectedOnInternet })";
//                }
//                else
//                {
//                    Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.NoInternetConnection })";
//                }
//            }

//        }
//        catch (Exception)
//        {
//            // nothing
//        }

//        // PanelTop
//        butShowLanguagePanel.Text = CSSPCultureDesktopRes.butShowLanguagePanelText;
//        butShowHelpPanel.Text = CSSPCultureDesktopRes.butShowHelpPanelText;
//        butLogoff.Text = CSSPCultureDesktopRes.butLogoffText;


//        // PanelButtonsCenter
//        butStart.Text = CSSPCultureDesktopRes.butStartText;
//        butStop.Text = CSSPCultureDesktopRes.butStopText;
//        butClose.Text = CSSPCultureDesktopRes.butCloseText;
//        butShowUpdatePanel.Text = CSSPCultureDesktopRes.butUpdatesAvailableText;

//        // PanelHelpCenter
//        butHideHelpPanel.Text = CSSPCultureDesktopRes.butHideHelpPanelText;

//        // PanelUpdateCenter
//        butUpdate.Text = CSSPCultureDesktopRes.butUpdateText;
//        butCancelUpdate.Text = CSSPCultureDesktopRes.butCancelUpdateText;
//        butUpdateCompleted.Text = CSSPCultureDesktopRes.butUpdateCompletedText;
//        lblInstalling.Text = CSSPCultureDesktopRes.lblInstallingText;

//        // PanelLoginCenter
//        lblCSSPWebToolsLoginOneTime.Text = CSSPCultureDesktopRes.lblCSSPWebToolsLoginOneTimeText;
//        lblLoginEmailLogin.Text = CSSPCultureDesktopRes.lblLoginEmailLoginText;
//        lblPasswordLogin.Text = CSSPCultureDesktopRes.lblPasswordLoginText;
//        butLogin.Text = CSSPCultureDesktopRes.butLoginText;
//        lblInternetRequiredLogin.Text = CSSPCultureDesktopRes.lblInternetRequiredLoginText;
//        linkLabelGotoRegister.Text = CSSPCultureDesktopRes.linkLabelGoToRegisterText;

//        // PanelRegisterCenter
//        lblCSSPWebToolsRegister.Text = CSSPCultureDesktopRes.lblCSSPWebToolsRegister;
//        lblLoginEmailRegister.Text = CSSPCultureDesktopRes.lblLoginEmailRegisterText;
//        lblFirstNameRegister.Text = CSSPCultureDesktopRes.lblFirstNameRegisterText;
//        lblLastNameRegister.Text = CSSPCultureDesktopRes.lblLastNameRegisterText;
//        lblInitialRegister.Text = CSSPCultureDesktopRes.lblInitialRegisterText;
//        lblPasswordRegister.Text = CSSPCultureDesktopRes.lblPasswordRegisterText;
//        lblConfirmPasswordRegister.Text = CSSPCultureDesktopRes.lblConfirmPasswordRegisterText;
//        butRegister.Text = CSSPCultureDesktopRes.butRegisterText;
//        lblInternetRequiredRegister.Text = CSSPCultureDesktopRes.lblInternetRequiredRegisterText;
//        linkLabelGoToLogin.Text = CSSPCultureDesktopRes.linkLabelGoToLoginText;

//        // PanelStatus
//        lblStatusText.Text = CSSPCultureDesktopRes.lblStatusText;
//        lblStatus.Text = "";
//    }
//    #endregion SettingUpAllTextForLanguage
//}