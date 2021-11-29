namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPDesktopService CSSPDesktopService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    bool IsEnglish { get; set; } = true;

    public CSSPDesktopForm()
    {
        InitializeComponent();
        string Version = "1.0.1.9";
        lblVersionValue.Text = Version;
        lblVersionTop.Text = Version;

        SetupAsync().GetAwaiter().GetResult();
    }

    #region ButtonEvents
    private void butCancelUpdate_Click(object sender, EventArgs e)
    {
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
        ShowPanels(ShowPanelEnum.Commands);
    }
    private void butClose_Click(object sender, EventArgs e)
    {
        Close();
    }
    private void butContactLoggedIn_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Login);
    }
    private void butLogoff_Click(object sender, EventArgs e)
    {
        Logoff();
    }
    private void butHideHelpPanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Commands);
    }
    private void butShowHelpPanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Help);
    }
    private void butShowLanguagePanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Language);
    }
    private void butSetLanguageToEnglish_Click(object sender, EventArgs e)
    {
        IsEnglish = true;
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
    }
    private void butSetLanguageToFrancais_Click(object sender, EventArgs e)
    {
        IsEnglish = false;
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
    }
    private void butStart_Click(object sender, EventArgs e)
    {
        Start();
    }
    private void butStop_Click(object sender, EventArgs e)
    {
        Stop();
    }
    private void butShowUpdatePanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Updates);
        butUpdateCompleted.Visible = false;
    }
    private void butUpdate_Click(object sender, EventArgs e)
    {
        butCancelUpdate.Enabled = false;
        if (CSSPDesktopService.InstallUpdatesAsync().GetAwaiter().GetResult())
        {
            butShowUpdatePanel.Enabled = false;
        }
        butCancelUpdate.Visible = false;
        butUpdate.Visible = false;
        butUpdateCompleted.Visible = true;
    }
    private void butUpdateCompleted_Click(object sender, EventArgs e)
    {
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();

        ShowPanels(ShowPanelEnum.Commands);
        butCancelUpdate.Enabled = true;
        butCancelUpdate.Visible = true;
        butUpdate.Visible = true;
        butUpdateCompleted.Visible = false;
    }
    #endregion ButtonEvents

    #region CheckInternetConnectionAsync
    private async Task<bool> CheckInternetConnectionAsync()
    {
        if (!await CSSPDesktopService.FillContactHasInternetConnectionAsync()) return await Task.FromResult(false);

        if (CSSPDesktopService.contact != null && CSSPDesktopService.contact.HasInternetConnection != null)
        {
            if ((bool)CSSPDesktopService.contact.HasInternetConnection)
            {
                Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.ConnectedOnInternet })";
            }
            else
            {
                Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.NoInternetConnection })";
                butLogoff.Visible = false;
            }
        }

        return await Task.FromResult(true);
    }
    #endregion CheckInternetConnectionAsync

    #region CSSPDesktopServiceEvents
    private void CSSPDesktopService_StatusClear(object sender, ClearEventArgs e)
    {
        richTextBoxStatus.Text = "";
        richTextBoxStatus.Refresh();
        Application.DoEvents();
    }
    private void CSSPDesktopService_StatusAppend(object sender, AppendEventArgs e)
    {
        lblStatus.Text = e.Message;
        lblStatus.Refresh();

        richTextBoxStatus.AppendText(e.Message + "\r\n");
        richTextBoxStatus.Refresh();
        Application.DoEvents();
    }
    private void CSSPDesktopService_StatusInstalling(object sender, InstallingEventArgs e)
    {
        progressBarInstalling.Value = e.Percent;
        progressBarInstalling.Refresh();
        Application.DoEvents();
    }
    #endregion CSSPDesktopServiceEvents

    #region EnabledOrDisableLoginButton
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
    #endregion EnabledOrDisableLoginButton

    #region EnabledOrDisableRegisterButton
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
    #endregion EnabledOrDisableRegisterButton

    #region FormEvents
    private void CSSPDesktopForm_Resize(object sender, EventArgs e)
    {
        RecenterPanels();
    }
    private void CSSPDesktopForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Stop();
    }
    #endregion FormEvents

    #region LoginAsync
    private async Task<bool> LoginAsync()
    {
        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = textBoxLoginEmailLogin.Text.Trim(),
            Password = textBoxPasswordLogin.Text.Trim(),
        };

        if (!await CSSPDesktopService.LoginAsync(loginModel)) return await Task.FromResult(false);
        if (!await StartTheAppWithLanguageAsync()) return await Task.FromResult(false);

        return await Task.FromResult(true);
    }
    #endregion LoginAsync

    #region LoginEvents
    private void butLogin_Click(object sender, EventArgs e)
    {
        butLogin.Enabled = false;
        butLogin.Text = CSSPCultureDesktopRes.LoggingIn;
        LoginAsync().GetAwaiter().GetResult();
        butLogin.Text = CSSPCultureDesktopRes.butLoginText;
        butLogin.Enabled = true;
    }
    private void linkLabelGotoRegister_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Register);
    }
    private void textBoxLoginEmailLogin_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableLoginButton();
    }
    private void textBoxPasswordLogin_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableLoginButton();
    }
    #endregion LoginEvents

    #region Logoff
    private void Logoff()
    {
        CSSPDesktopService.LogoffAsync();
        textBoxPasswordLogin.Text = "";
        ShowPanels(ShowPanelEnum.Login);
    }
    #endregion Logoff

    #region RecenterPanels
    private void RecenterPanels()
    {
        panelCommandsCenter.Top = panelCommandsCenter.Parent.Height / 2 - panelCommandsCenter.Height / 2;
        panelCommandsCenter.Left = panelCommandsCenter.Parent.Width / 2 - panelCommandsCenter.Width / 2;

        panelUpdateCenter.Top = panelUpdateCenter.Parent.Height / 2 - panelUpdateCenter.Height / 2;
        panelUpdateCenter.Left = panelUpdateCenter.Parent.Width / 2 - panelUpdateCenter.Width / 2;

        panelLoginCenter.Top = panelLoginCenter.Parent.Height / 2 - panelLoginCenter.Height / 2;
        panelLoginCenter.Left = panelLoginCenter.Parent.Width / 2 - panelLoginCenter.Width / 2;

        panelRegisterCenter.Top = panelRegisterCenter.Parent.Height / 2 - panelRegisterCenter.Height / 2;
        panelRegisterCenter.Left = panelRegisterCenter.Parent.Width / 2 - panelRegisterCenter.Width / 2;

        panelLanguageCenter.Top = panelLanguageCenter.Parent.Height / 2 - panelLanguageCenter.Height / 2;
        panelLanguageCenter.Left = panelLanguageCenter.Parent.Width / 2 - panelLanguageCenter.Width / 2;

        panelHelp.Dock = DockStyle.Fill;

        butHideHelpPanel.Left = panelHelpTop.Width / 2 - butHideHelpPanel.Width / 2;
    }
    #endregion RecenterPanels

    #region RegisterAsync
    //private async Task<bool> RegisterAsync()
    //{
    //    RegisterModel registerModel = new RegisterModel()
    //    {
    //        LoginEmail = textBoxLoginEmailRegister.Text.Trim(),
    //        FirstName = textBoxFirstNameRegister.Text.Trim(),
    //        LastName = textBoxLastNameRegister.Text.Trim(),
    //        Initial = textBoxInitialRegister.Text.Trim(),
    //        Password = textBoxPasswordRegister.Text.Trim(),
    //        ConfirmPassword = textBoxConfirmPasswordRegister.Text.Trim(),
    //    };

    //    if (!await CSSPDesktopService.Register(registerModel)) return await Task.FromResult(false);
    //    if (!await StartTheAppWithLanguage()) return await Task.FromResult(false);

    //    return await Task.FromResult(true);
    //}
    #endregion RegisterAsync

    #region RegisterEvents
    //private void butRegister_Click(object sender, EventArgs e)
    //{
    //    butRegister.Enabled = false;
    //    butRegister.Text = CSSPCultureDesktopRes.RegisteringIn;
    //    Register().GetAwaiter().GetResult();
    //    butRegister.Text = CSSPCultureDesktopRes.butRegisterText;
    //    butRegister.Enabled = true;
    //}
    private void linkLabelGoToLogin_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Login);
    }
    private void textBoxLoginEmailRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    private void textBoxFirstNameRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    private void textBoxLastNameRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    private void textBoxInitialRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    private void textBoxPasswordRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    private void textBoxConfirmPasswordRegister_TextChanged(object sender, EventArgs e)
    {
        EnabledOrDisableRegisterButton();
    }
    #endregion RegisterEvents

    #region SettingUpAllTextForLanguage
    private void SettingUpAllTextForLanguage()
    {
        CSSPDesktopService.IsEnglish = IsEnglish;

        if (IsEnglish)
        {
            CSSPCultureService.SetCulture("en-CA");
        }
        else
        {
            CSSPCultureService.SetCulture("fr-CA");
        }

        try
        {
            if (CSSPDesktopService.contact != null && CSSPDesktopService.contact.HasInternetConnection == null)
            {
                Text = CSSPCultureDesktopRes.FormTitleText;
            }
            else
            {
                if (CSSPDesktopService.contact != null && (bool)CSSPDesktopService.contact.HasInternetConnection)
                {
                    Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.ConnectedOnInternet })";
                }
                else
                {
                    Text = CSSPCultureDesktopRes.FormTitleText + $" --- ({ CSSPCultureDesktopRes.NoInternetConnection })";
                }
            }

        }
        catch (Exception)
        {
            // nothing
        }

        // PanelTop
        butShowLanguagePanel.Text = CSSPCultureDesktopRes.butShowLanguagePanelText;
        butShowHelpPanel.Text = CSSPCultureDesktopRes.butShowHelpPanelText;
        butLogoff.Text = CSSPCultureDesktopRes.butLogoffText;


        // PanelButtonsCenter
        butStart.Text = CSSPCultureDesktopRes.butStartText;
        butStop.Text = CSSPCultureDesktopRes.butStopText;
        butClose.Text = CSSPCultureDesktopRes.butCloseText;
        butShowUpdatePanel.Text = CSSPCultureDesktopRes.butUpdatesAvailableText;

        // PanelHelpCenter
        butHideHelpPanel.Text = CSSPCultureDesktopRes.butHideHelpPanelText;

        // PanelUpdateCenter
        butUpdate.Text = CSSPCultureDesktopRes.butUpdateText;
        butCancelUpdate.Text = CSSPCultureDesktopRes.butCancelUpdateText;
        butUpdateCompleted.Text = CSSPCultureDesktopRes.butUpdateCompletedText;
        lblInstalling.Text = CSSPCultureDesktopRes.lblInstallingText;

        // PanelLoginCenter
        lblCSSPWebToolsLoginOneTime.Text = CSSPCultureDesktopRes.lblCSSPWebToolsLoginOneTimeText;
        lblLoginEmailLogin.Text = CSSPCultureDesktopRes.lblLoginEmailLoginText;
        lblPasswordLogin.Text = CSSPCultureDesktopRes.lblPasswordLoginText;
        butLogin.Text = CSSPCultureDesktopRes.butLoginText;
        lblInternetRequiredLogin.Text = CSSPCultureDesktopRes.lblInternetRequiredLoginText;
        linkLabelGotoRegister.Text = CSSPCultureDesktopRes.linkLabelGoToRegisterText;

        // PanelRegisterCenter
        lblCSSPWebToolsRegister.Text = CSSPCultureDesktopRes.lblCSSPWebToolsRegister;
        lblLoginEmailRegister.Text = CSSPCultureDesktopRes.lblLoginEmailRegisterText;
        lblFirstNameRegister.Text = CSSPCultureDesktopRes.lblFirstNameRegisterText;
        lblLastNameRegister.Text = CSSPCultureDesktopRes.lblLastNameRegisterText;
        lblInitialRegister.Text = CSSPCultureDesktopRes.lblInitialRegisterText;
        lblPasswordRegister.Text = CSSPCultureDesktopRes.lblPasswordRegisterText;
        lblConfirmPasswordRegister.Text = CSSPCultureDesktopRes.lblConfirmPasswordRegisterText;
        butRegister.Text = CSSPCultureDesktopRes.butRegisterText;
        lblInternetRequiredRegister.Text = CSSPCultureDesktopRes.lblInternetRequiredRegisterText;
        linkLabelGoToLogin.Text = CSSPCultureDesktopRes.linkLabelGoToLoginText;

        // PanelStatus
        lblStatusText.Text = CSSPCultureDesktopRes.lblStatusText;
        lblStatus.Text = "";
    }
    #endregion SettingUpAllTextForLanguage

    #region SetupAsync
    private async Task<bool> SetupAsync()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_csspdesktop.json")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");

        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPDesktopForm") }");
        if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "CSSPDesktopForm") }");

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

        /* ---------------------------------------------------------------------------------
         * using CSSPDBLocal
         * ---------------------------------------------------------------------------------      
         */
        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
        });


        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */
        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });

        Provider = Services.BuildServiceProvider();
        if (Provider == null)
        {
            richTextBoxStatus.AppendText("Provider should not be null\r\n");
            return await Task.FromResult(false);
        }

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        if (CSSPCultureService == null)
        {
            richTextBoxStatus.AppendText("CSSPCultureService should not be null\r\n");
            return await Task.FromResult(false);
        }

        CSSPCultureService.SetCulture("en-CA");

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        if (CSSPScrambleService == null)
        {
            richTextBoxStatus.AppendText("CSSPLocalLoggedInService should not be null\r\n");
            return await Task.FromResult(false);
        }

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        if (CSSPLocalLoggedInService == null)
        {
            richTextBoxStatus.AppendText("CSSPLocalLoggedInService should not be null\r\n");
            return await Task.FromResult(false);
        }

        CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
        if (CSSPDesktopService == null)
        {
            richTextBoxStatus.AppendText("CSSPDesktopService should not be null\r\n");
            return await Task.FromResult(false);
        }

        CSSPDesktopService.StatusClear += CSSPDesktopService_StatusClear;
        CSSPDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
        CSSPDesktopService.StatusInstalling += CSSPDesktopService_StatusInstalling;

        CSSPDesktopService.IsEnglish = IsEnglish;

        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
        if (CSSPSQLiteService == null)
        {
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
        }

        CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
        if (CSSPAzureLoginService == null)
        {
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
        }

        if (!await CSSPDesktopService.CreateAllRequiredDirectoriesAsync()) return await Task.FromResult(false);

        CSSPDBManageContext dbManage = Provider.GetService<CSSPDBManageContext>();
        if (dbManage == null)
        {
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes._ShouldNotBeNull, "CSSPSQLiteService") + "\r\n");
        }

        // create CSSPDBManage if it does not exist
        FileInfo fi = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fi.Exists)
        {
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db") + "\r\n");
            if (!await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync()) return await Task.FromResult(false);
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db" + "\r\n"));
        }
        else
        {
            try
            {
                var a = (from c in dbManage.Contacts
                         select c).FirstOrDefault();

                await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
            }
            catch (Exception)
            {
                richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db") + "\r\n");
                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync()) return await Task.FromResult(false);
                richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBManage.db" + "\r\n"));
            }
        }

        SettingUpAllTextForLanguage();

        // create CSSPDBLocal if it does not exist
        fi = new FileInfo(Configuration["CSSPDBLocal"]);
        if (!fi.Exists)
        {
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Creating_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBLocal.db") + "\r\n");
            if (!await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync()) return await Task.FromResult(false);
            richTextBoxStatus.AppendText(string.Format(CSSPCultureDesktopRes.Created_SQLiteDatabase, @"C:\CSSPDesktop\cssplocaldatabases\CSSPDBLocal.db") + "\r\n");
        }

        splitContainerFirst.Dock = DockStyle.Fill;
        panelHelp.Dock = DockStyle.Fill;
        richTextBoxStatus.Dock = DockStyle.Fill;
        richTextBoxHelp.Dock = DockStyle.Fill;

        ShowPanels(ShowPanelEnum.Language);

        RecenterPanels();

        if (!await CheckInternetConnectionAsync()) return await Task.FromResult(false);

        if (!await CSSPDesktopService.FillHasCSSPOtherFilesAsync()) return await Task.FromResult(false);

        lblStatus.Text = "";

        butLogin.Enabled = false;
        butRegister.Enabled = false;

        return await Task.FromResult(true);
    }
    #endregion SetupAsync

    #region ShowPanelEnum
    private enum ShowPanelEnum
    {
        Commands,
        Language,
        Help,
        Login,
        Updates,
        Register,
    }
    #endregion ShowPanelEnum

    #region ShowPanels
    private void ShowPanels(ShowPanelEnum showPanel)
    {
        panelLanguageCenter.Visible = false;
        panelUpdateCenter.Visible = false;
        panelLoginCenter.Visible = false;
        panelRegisterCenter.Visible = false;
        panelHelp.Visible = false;
        panelCommandsCenter.Visible = false;

        if (CSSPDesktopService.HasCSSPOtherFiles)
        {
            butShowHelpPanel.Visible = true;
        }
        else
        {
            butShowHelpPanel.Visible = false;
        }

        switch (showPanel)
        {
            case ShowPanelEnum.Commands:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Commands visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Commandes visible"));
                    }

                    panelTop.Visible = true;
                    panelLoginEmail.Visible = true;
                    if (CSSPDesktopService.LoginRequired)
                    {
                        panelLoginCenter.Visible = true;
                    }
                    else
                    {
                        panelCommandsCenter.Visible = true;
                    }

                    butStart.Focus();
                }
                break;
            case ShowPanelEnum.Language:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Language visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Langage visible"));
                    }

                    panelTop.Visible = false;
                    panelLoginEmail.Visible = false;
                    panelLanguageCenter.Visible = true;
                    butSetLanguageToEnglish.Focus();
                }
                break;
            case ShowPanelEnum.Help:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Help visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Aide visible"));
                    }

                    panelTop.Visible = false;
                    panelLoginEmail.Visible = false;
                    string fileToOpen = IsEnglish ? "HelpDocEN.rtf" : "HelpDocFR.rtf";
                    richTextBoxHelp.LoadFile($"{ Configuration["CSSPOtherFilesPath"] }{ fileToOpen }");
                    panelHelp.Visible = true;

                    butHideHelpPanel.Focus();
                }
                break;
            case ShowPanelEnum.Login:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Login visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Connexion visible"));
                    }

                    panelTop.Visible = false;
                    panelLoginEmail.Visible = false;
                    panelLoginCenter.Visible = true;
                    textBoxLoginEmailLogin.Focus();
                }
                break;
            case ShowPanelEnum.Register:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Register visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Enregistrer visible"));
                    }

                    panelTop.Visible = false;
                    panelLoginEmail.Visible = false;
                    panelRegisterCenter.Visible = true;
                    textBoxLoginEmailRegister.Focus();
                }
                break;
            case ShowPanelEnum.Updates:
                {
                    if (IsEnglish)
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Updates visible"));
                    }
                    else
                    {
                        CSSPDesktopService_StatusAppend(this, new AppendEventArgs("Mise-à-jour visible"));
                    }

                    panelTop.Visible = true;
                    panelLoginEmail.Visible = true;
                    panelUpdateCenter.Visible = true;
                    butUpdate.Focus();
                }
                break;
            default:
                break;
        }

        CSSPDesktopService_StatusAppend(this, new AppendEventArgs(""));
    }
    #endregion ShowPanels

    #region Start
    private void Start()
    {
        butStart.Enabled = false;
        butStop.Enabled = true;
        CSSPDesktopService.StartAsync();
    }
    #endregion Start

    #region StartTheAppWithLanguageAsync
    private async Task<bool> StartTheAppWithLanguageAsync()
    {
        SettingUpAllTextForLanguage();

        if (!await CSSPDesktopService.FillLoginRequiredAsync()) return await Task.FromResult(false);

        if (!CSSPDesktopService.LoginRequired)
        {
            if (CSSPDesktopService.contact != null && (bool)CSSPDesktopService.contact.HasInternetConnection)
            {
                LoginModel loginModel = new LoginModel()
                {
                    LoginEmail = CSSPDesktopService.contact.LoginEmail,
                    Password = CSSPScrambleService.Descramble(CSSPDesktopService.contact.PasswordHash),
                };

                if (!await CSSPDesktopService.LoginAsync(loginModel)) return await Task.FromResult(false);
            }
            if (!await CSSPDesktopService.FillUpdateIsNeededAsync()) return await Task.FromResult(false);
        }

        if (CSSPDesktopService.LoginRequired)
        {
            butLogoff.Visible = false;

            lblContactLoggedIn.Text = "";
            ShowPanels(ShowPanelEnum.Login);

            if (CSSPDesktopService.contact != null && !(bool)CSSPDesktopService.contact.HasInternetConnection)
            {
                butLogin.Enabled = false;
                lblInternetRequiredLogin.Visible = true;
                lblInternetRequiredRegister.Visible = true;
                lblStatus.Text = CSSPCultureDesktopRes.InternetConnectionRequiredFirstTimeConnecting;
            }
            else
            {
                butLogin.Enabled = true;
                lblInternetRequiredLogin.Visible = false;
                lblInternetRequiredRegister.Visible = false;
                lblStatus.Text = "";
            }
        }
        else
        {
            butLogoff.Visible = true;

            lblContactLoggedIn.Text = CSSPDesktopService.contact.LoginEmail;
            ShowPanels(ShowPanelEnum.Commands);
        }

        if (!CSSPDesktopService.LoginRequired && CSSPDesktopService.UpdateIsNeeded)
        {
            ShowPanels(ShowPanelEnum.Updates);
        }

        if (CSSPDesktopService.UpdateIsNeeded)
        {
            butShowUpdatePanel.Enabled = true;
        }
        else
        {
            butShowUpdatePanel.Enabled = false;
        }

        return await Task.FromResult(true);
    }
    #endregion StartTheAppWithLanguageAsync

    #region Stop
    private void Stop()
    {
        butStart.Enabled = true;
        butStop.Enabled = false;
        CSSPDesktopService.StopAsync();
    }
    #endregion Stop

}

