using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPDesktop
{
    public partial class CSSPDesktopForm : Form
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPFileService CSSPFileService { get; set; }
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        bool IsEnglish { get; set; } = true;
        #endregion Properties

        #region Constructors
        public CSSPDesktopForm()
        {
            InitializeComponent();
            Setup().GetAwaiter().GetResult();
        }
        #endregion Constructors

        #region Events
        #region Button Click
        private void butCancelUpdate_Click(object sender, EventArgs e)
        {
            StartTheAppWithLanguage().GetAwaiter().GetResult();
            ShowPanels(ShowPanel.Commands);
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void butContactLoggedIn_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Login);
        }
        private void butLogoff_Click(object sender, EventArgs e)
        {
            Logoff();
        }
        private void butHideHelpPanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
        }
        private void butShowHelpPanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Help);
        }
        private void butShowLanguagePanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Language);
        }
        private void butSetLanguageToEnglish_Click(object sender, EventArgs e)
        {
            IsEnglish = true;
            StartTheAppWithLanguage().GetAwaiter().GetResult();
        }
        private void butSetLanguageToFrancais_Click(object sender, EventArgs e)
        {
            IsEnglish = false;
            StartTheAppWithLanguage().GetAwaiter().GetResult();
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
            ShowPanels(ShowPanel.Updates);
            butUpdateCompleted.Visible = false;
        }
        private void butUpdate_Click(object sender, EventArgs e)
        {
            butCancelUpdate.Enabled = false;
            if (CSSPDesktopService.InstallUpdates().GetAwaiter().GetResult())
            {
                butShowUpdatePanel.Enabled = false;
            }
            butCancelUpdate.Visible = false;
            butUpdate.Visible = false;
            butUpdateCompleted.Visible = true;
        }
        private void butUpdateCompleted_Click(object sender, EventArgs e)
        {
            StartTheAppWithLanguage().GetAwaiter().GetResult();

            ShowPanels(ShowPanel.Commands);
            butCancelUpdate.Enabled = true;
            butCancelUpdate.Visible = true;
            butUpdate.Visible = true;
            butUpdateCompleted.Visible = false;
        }
        #endregion Button Click
        #region Form
        private void CSSPDesktopForm_Resize(object sender, EventArgs e)
        {
            RecenterPanels();
        }
        private void CSSPDesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }
        #endregion Form
        #region csspDesktopServiceEvent
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
        #endregion csspDesktopServiceEvent
        #region Login
        private void butLogin_Click(object sender, EventArgs e)
        {
            butLogin.Enabled = false;
            butLogin.Text = CSSPDesktopService.appTextModel.LoggingIn;
            Login().GetAwaiter().GetResult();
            butLogin.Text = CSSPDesktopService.appTextModel.butLoginText;
            butLogin.Enabled = true;
        }
        #endregion Login
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> CheckInternetConnection()
        {
            if (!await CSSPDesktopService.CheckingInternetConnection()) return await Task.FromResult(false);

            if (CSSPDesktopService.preference.HasInternetConnection != null)
            {
                if ((bool)CSSPDesktopService.preference.HasInternetConnection)
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.ConnectedOnInternet })";
                }
                else
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.NoInternetConnection })";
                }
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> Login()
        {
            if (!await CSSPDesktopService.Login(textBoxLoginEmail.Text.Trim(), textBoxPassword.Text.Trim())) return await Task.FromResult(false);
            if (!await StartTheAppWithLanguage()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        private void Logoff()
        {
            CSSPDesktopService.Logoff();
            textBoxPassword.Text = "";
            ShowPanels(ShowPanel.Login);
        }
        private void RecenterPanels()
        {
            this.Width = 600;
            this.Height = 500;
            panelCommandsCenter.Top = panelCommandsCenter.Parent.Height / 2 - panelCommandsCenter.Height / 2;
            panelCommandsCenter.Left = panelCommandsCenter.Parent.Width / 2 - panelCommandsCenter.Width / 2;

            panelUpdateCenter.Top = panelUpdateCenter.Parent.Height / 2 - panelUpdateCenter.Height / 2;
            panelUpdateCenter.Left = panelUpdateCenter.Parent.Width / 2 - panelUpdateCenter.Width / 2;

            panelLoginCenter.Top = panelLoginCenter.Parent.Height / 2 - panelLoginCenter.Height / 2;
            panelLoginCenter.Left = panelLoginCenter.Parent.Width / 2 - panelLoginCenter.Width / 2;

            panelLanguageCenter.Top = panelLanguageCenter.Parent.Height / 2 - panelLanguageCenter.Height / 2;
            panelLanguageCenter.Left = panelLanguageCenter.Parent.Width / 2 - panelLanguageCenter.Width / 2;

            panelHelp.Dock = DockStyle.Fill;

            butHideHelpPanel.Left = panelHelpTop.Width / 2 - butHideHelpPanel.Width / 2;
        }
        private async Task<bool> StartTheAppWithLanguage()
        {
            SettingUpAllTextForLanguage();

            if (!await CSSPDesktopService.CheckIfLoginIsRequired()) return await Task.FromResult(false);

            if (!CSSPDesktopService.LoginRequired)
            {
                if (!await CSSPDesktopService.CheckIfUpdateIsNeeded()) return await Task.FromResult(false);
            }

            if (CSSPDesktopService.LoginRequired)
            {
                butLogoff.Visible = false;
                butShowLoginPanel.Visible = true;

                lblContactLoggedIn.Text = "";
                ShowPanels(ShowPanel.Login);

                if (CSSPDesktopService.preference.HasInternetConnection == null || (bool)CSSPDesktopService.preference.HasInternetConnection == false)
                {
                    butLogin.Enabled = false;
                    lblInternetRequired.Visible = true;
                    lblStatus.Text = CSSPDesktopService.appTextModel.InternetConnectionRequiredFirstTimeConnecting;
                }
                else
                {
                    butLogin.Enabled = true;
                    lblInternetRequired.Visible = false;
                    lblStatus.Text = "";
                }
            }
            else
            {
                butLogoff.Visible = true;
                butShowLoginPanel.Visible = false;

                lblContactLoggedIn.Text = CSSPDesktopService.ContactLoggedIn.LoginEmail;
                ShowPanels(ShowPanel.Commands);
            }

            if (!CSSPDesktopService.LoginRequired && CSSPDesktopService.UpdateIsNeeded)
            {
                ShowPanels(ShowPanel.Updates);
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
        private async Task<bool> Setup()
        {
            string _CouldNotBeFoundInConfigurationFile_ = "{0} could not be found in the configuration file {1}";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdesktop.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();

            // doing CSSPLocal
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json"));
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            // doing CSSPSearch
            string CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            if (string.IsNullOrWhiteSpace(CSSPDBSearch))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBSearch", "appsettings_csspdesktop.json"));
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearch);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            // doing CSSPDBFilesManagement
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json"));
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBFileManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFileManagement.FullName }");
            });

            // doing CSSPLogin
            string CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPDBLogin))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBLogin", "appsettings_csspdesktop.json"));
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLogin);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                richTextBoxStatus.AppendText("Provider should not be null\r\n");
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
            SettingUpAllTextForLanguage();
            if (!await CSSPDesktopService.ReadConfiguration()) return await Task.FromResult(false);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            if (CSSPSQLiteService == null)
            {
                richTextBoxStatus.AppendText(string.Format(CSSPDesktopService.appTextModel._ShouldNotBeNull, "CSSPSQLiteService"));
            }

            if (!await CSSPDesktopService.CreateAllRequiredDirectories()) return await Task.FromResult(false);


            SettingUpAllTextForLanguage();

            // create CSSPDBLocal if it does not exist
            FileInfo fi = new FileInfo(CSSPDesktopService.CSSPDBLocal);
            if (!fi.Exists)
            {
                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBLocal()) return await Task.FromResult(false);
            }

            // create CSSPDBSearch if it does not exist
            fi = new FileInfo(CSSPDesktopService.CSSPDBSearch);
            if (!fi.Exists)
            {
                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBSearch()) return await Task.FromResult(false);
            }

            // create CSSPDBFilesManagement if it does not exist
            fi = new FileInfo(CSSPDesktopService.CSSPDBFilesManagement);
            if (!fi.Exists)
            {
                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBFilesManagement()) return await Task.FromResult(false);
            }

            // create CSSPDBLogin if it does not exist
            fi = new FileInfo(CSSPDesktopService.CSSPDBLogin);
            if (!fi.Exists)
            {
                if (!await CSSPSQLiteService.CreateSQLiteCSSPDBLogin()) return await Task.FromResult(false);
            }

            splitContainerFirst.Dock = DockStyle.Fill;
            panelHelp.Dock = DockStyle.Fill;
            richTextBoxStatus.Dock = DockStyle.Fill;
            richTextBoxHelp.Dock = DockStyle.Fill;

            ShowPanels(ShowPanel.Language);

            RecenterPanels();

            if (!await CSSPDesktopService.CheckIfHelpFilesExist()) return await Task.FromResult(false);

            if (!await CheckInternetConnection()) return await Task.FromResult(false);

            lblStatus.Text = "";

            return await Task.FromResult(true);
        }
        private void SettingUpAllTextForLanguage()
        {
            CSSPDesktopService.IsEnglish = IsEnglish;

            if (IsEnglish)
            {
                CSSPDesktopService.appTextModel = new AppTextModelEN();
            }
            else
            {
                CSSPDesktopService.appTextModel = new AppTextModelFR();
            }

            // Form
            if (CSSPDesktopService.preference.HasInternetConnection == null)
            {
                Text = CSSPDesktopService.appTextModel.FormTitleText;
            }
            else
            {
                if ((bool)CSSPDesktopService.preference.HasInternetConnection)
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.ConnectedOnInternet })";
                }
                else
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.NoInternetConnection })";
                }
            }

            // PanelTop
            butShowLanguagePanel.Text = CSSPDesktopService.appTextModel.butShowLanguagePanelText;
            butShowHelpPanel.Text = CSSPDesktopService.appTextModel.butShowHelpPanelText;
            lblLoginEmail.Text = CSSPDesktopService.appTextModel.lblLoginEmailText;
            butShowLoginPanel.Text = CSSPDesktopService.appTextModel.butShowLoginPanelText;
            butLogoff.Text = CSSPDesktopService.appTextModel.butLogoffText;


            // PanelButtonsCenter
            butStart.Text = CSSPDesktopService.appTextModel.butStartText;
            butStop.Text = CSSPDesktopService.appTextModel.butStopText;
            butClose.Text = CSSPDesktopService.appTextModel.butCloseText;
            butShowUpdatePanel.Text = CSSPDesktopService.appTextModel.butUpdatesAvailableText;

            // PanelHelpCenter
            butHideHelpPanel.Text = CSSPDesktopService.appTextModel.butHideHelpPanelText;

            // PanelUpdateCenter
            butUpdate.Text = CSSPDesktopService.appTextModel.butUpdateText;
            butCancelUpdate.Text = CSSPDesktopService.appTextModel.butCancelUpdateText;
            butUpdateCompleted.Text = CSSPDesktopService.appTextModel.butUpdateCompletedText;
            lblInstalling.Text = CSSPDesktopService.appTextModel.lblInstallingText;

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTime.Text = CSSPDesktopService.appTextModel.lblCSSPWebToolsLoginOneTimeText;
            lblPassword.Text = CSSPDesktopService.appTextModel.lblPasswordText;
            butLogin.Text = CSSPDesktopService.appTextModel.butLoginText;
            lblInternetRequired.Text = CSSPDesktopService.appTextModel.lblInternetRequiredText;

            // PanelStatus
            lblStatusText.Text = CSSPDesktopService.appTextModel.lblStatusText;
            lblStatus.Text = "";
        }
        private void ShowPanels(ShowPanel showPanel)
        {
            panelLanguageCenter.Visible = false;
            panelUpdateCenter.Visible = false;
            panelLoginCenter.Visible = false;
            panelHelp.Visible = false;
            panelCommandsCenter.Visible = false;

            if (CSSPDesktopService.HasHelpFiles)
            {
                butShowHelpPanel.Visible = true;
            }
            else
            {
                butShowHelpPanel.Visible = false;
            }

            switch (showPanel)
            {
                case ShowPanel.Commands:
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
                case ShowPanel.Language:
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
                case ShowPanel.Help:
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
                        richTextBoxHelp.LoadFile($"{ CSSPDesktopService.LocalCSSPWebAPIsPath }{ fileToOpen }");
                        panelHelp.Visible = true;

                        butHideHelpPanel.Focus();
                    }
                    break;
                case ShowPanel.Login:
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
                        textBoxLoginEmail.Focus();
                    }
                    break;
                case ShowPanel.Updates:
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
        private void Start()
        {
            butStart.Enabled = false;
            butStop.Enabled = true;
            CSSPDesktopService.Start();
        }
        private void Stop()
        {
            butStart.Enabled = true;
            butStop.Enabled = false;
            CSSPDesktopService.Stop();
        }
        #endregion Functions private

        #region Enums
        private enum ShowPanel
        {
            Commands,
            Language,
            Help,
            Login,
            Updates,
        }
        #endregion Enums

    }
}
