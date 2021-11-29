//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form 
//{
//    #region ShowPanels
//    private void ShowPanels(ShowPanelEnum showPanel)
//    {
//        panelLanguageCenter.Visible = false;
//        panelUpdateCenter.Visible = false;
//        panelLoginCenter.Visible = false;
//        panelRegisterCenter.Visible = false;
//        panelHelp.Visible = false;
//        panelCommandsCenter.Visible = false;

//        if (CSSPDesktopService.HasCSSPOtherFiles)
//        {
//            butShowHelpPanel.Visible = true;
//        }
//        else
//        {
//            butShowHelpPanel.Visible = false;
//        }

//        switch (showPanel)
//        {
//            case ShowPanelEnum.Commands:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Commands visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Commandes visible"));
//                    }

//                    panelTop.Visible = true;
//                    panelLoginEmail.Visible = true;
//                    if (CSSPDesktopService.LoginRequired)
//                    {
//                        panelLoginCenter.Visible = true;
//                    }
//                    else
//                    {
//                        panelCommandsCenter.Visible = true;
//                    }

//                    butStart.Focus();
//                }
//                break;
//            case ShowPanelEnum.Language:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Language visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Langage visible"));
//                    }

//                    panelTop.Visible = false;
//                    panelLoginEmail.Visible = false;
//                    panelLanguageCenter.Visible = true;
//                    butSetLanguageToEnglish.Focus();
//                }
//                break;
//            case ShowPanelEnum.Help:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Help visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Aide visible"));
//                    }

//                    panelTop.Visible = false;
//                    panelLoginEmail.Visible = false;
//                    string fileToOpen = IsEnglish ? "HelpDocEN.rtf" : "HelpDocFR.rtf";
//                    richTextBoxHelp.LoadFile($"{ Configuration["CSSPOtherFilesPath"] }{ fileToOpen }");
//                    panelHelp.Visible = true;

//                    butHideHelpPanel.Focus();
//                }
//                break;
//            case ShowPanelEnum.Login:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Login visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Connexion visible"));
//                    }

//                    panelTop.Visible = false;
//                    panelLoginEmail.Visible = false;
//                    panelLoginCenter.Visible = true;
//                    textBoxLoginEmailLogin.Focus();
//                }
//                break;
//            case ShowPanelEnum.Register:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Register visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Enregistrer visible"));
//                    }

//                    panelTop.Visible = false;
//                    panelLoginEmail.Visible = false;
//                    panelRegisterCenter.Visible = true;
//                    textBoxLoginEmailRegister.Focus();
//                }
//                break;
//            case ShowPanelEnum.Updates:
//                {
//                    if (IsEnglish)
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Updates visible"));
//                    }
//                    else
//                    {
//                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Mise-à-jour visible"));
//                    }

//                    panelTop.Visible = true;
//                    panelLoginEmail.Visible = true;
//                    panelUpdateCenter.Visible = true;
//                    butUpdate.Focus();
//                }
//                break;
//            default:
//                break;
//        }

//        CSSPDesktopService_StatusAppend(this, new AppendEventArgs(""));
//    }
//    #endregion ShowPanels
//}