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
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        bool IsEnglish { get; set; } = true;
        #endregion Properties

        #region Constructors
        public CSSPDesktopForm()
        {
            InitializeComponent();
            if (!Setup())
            {
                return;
            }
        }
        #endregion Constructors

        #region Events
        #region Button Click
        private void linkLabelCancelUpdate_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
        }
        private void linkLabelClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void butContactLoggedIn_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Login);
        }
        private void linkLabelLogoff_Click(object sender, EventArgs e)
        {
            Logoff();
        }
        private void linkLabelHideHelpPanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
        }
        private void linkLabelShowHelpPanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Help);
        }
        private void linkLabelShowLanguagePanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Language);
        }
        private void linkLabelSetLanguageToEnglish_Click(object sender, EventArgs e)
        {
            SetLanguage(true);
        }
        private void linkLabelSetLanguageToFrancais_Click(object sender, EventArgs e)
        {
            SetLanguage(false);
        }
        private void linkLabelStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void linkLabelStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void linkLabelShowUpdatePanel_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Updates);
            linkLabelUpdateCompleted.Visible = false;
        }
        private void linkLabelUpdate_Click(object sender, EventArgs e)
        {
            linkLabelCancelUpdate.Enabled = false;
            CSSPDesktopService.InstallUpdates();
            linkLabelCancelUpdate.Visible = false;
            linkLabelUpdate.Visible = false;
            linkLabelUpdateCompleted.Visible = true;
        }
        private void linkLabelUpdateCompleted_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
            linkLabelCancelUpdate.Enabled = true;
            linkLabelCancelUpdate.Visible = true;
            linkLabelUpdate.Visible = true;
            linkLabelUpdateCompleted.Visible = false;
        }
        #endregion Button Click
        #region Form Resize
        private void CSSPDesktopForm_Resize(object sender, EventArgs e)
        {
            RecenterPanels();
        }
        #endregion Form Resize
        #region csspDesktopServiceEvent
        private void CSSPDesktopService_StatusClear(object sender, ClearEventArgs e)
        {
            richTextBoxStatus.Text = "";
        }
        private void CSSPDesktopService_StatusAppend(object sender, AppendEventArgs e)
        {
            richTextBoxStatus.AppendText(e.Message);
        }
        private void CSSPDesktopService_StatusAppendTemp(object sender, AppendTempEventArgs e)
        {
            lblStatus.Text = e.Message;
        }
        private void CSSPDesktopService_StatusInstalling(object sender, InstallingEventArgs e)
        {
            richTextBoxStatus.AppendText(e.Percent.ToString());
        }
        private void CSSPDesktopService_StatusErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            richTextBoxStatus.AppendText(e.ErrorMessage);
        }
        #endregion csspDesktopServiceEvent
        #region Login
        private void linkLabelLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        #endregion Login
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void CheckInternetConnection()
        {
            CSSPDesktopService.CheckingInternetConnection();

            if (CSSPDesktopService.HasInternetConnection != null)
            {
                if ((bool)CSSPDesktopService.HasInternetConnection)
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.ConnectedOnInternet })";
                }
                else
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.NoInternetConnection })";
                }
            }
        }
        private void Login()
        {
            CSSPDesktopService.Login(textBoxLoginEmail.Text.Trim(), textBoxPassword.Text.Trim());
            if (!CSSPDesktopService.CheckIfLoginIsRequired().GetAwaiter().GetResult()) return;

            if (CSSPDesktopService.LoginRequired)
            {
                linkLabelLogoff.Visible = false;
                linkLabelShowLoginPanel.Visible = true;

                lblContactLoggedIn.Text = "";
                ShowPanels(ShowPanel.Login);

                MessageBox.Show(CSSPDesktopService.appTextModel.CouldNotLogin, CSSPDesktopService.appTextModel.ErrorWhileTryingToLogin, MessageBoxButtons.OK);
            }
            else
            {
                linkLabelLogoff.Visible = true;
                linkLabelShowLoginPanel.Visible = false;

                lblContactLoggedIn.Text = CSSPDesktopService.ContactLoggedIn.LoginEmail;
                ShowPanels(ShowPanel.Commands);
            }
        }
        private void Logoff()
        {
            CSSPDesktopService.Logoff();
            textBoxPassword.Text = "";
            ShowPanels(ShowPanel.Login);
        }
        private void RecenterPanels()
        {
            panelCommandsCenter.Top = panelCommandsCenter.Parent.Height / 2 - panelCommandsCenter.Height / 2;
            panelCommandsCenter.Left = panelCommandsCenter.Parent.Width / 2 - panelCommandsCenter.Width / 2;

            panelUpdateCenter.Top = panelUpdateCenter.Parent.Height / 2 - panelUpdateCenter.Height / 2;
            panelUpdateCenter.Left = panelUpdateCenter.Parent.Width / 2 - panelUpdateCenter.Width / 2;

            panelLoginCenter.Top = panelLoginCenter.Parent.Height / 2 - panelLoginCenter.Height / 2;
            panelLoginCenter.Left = panelLoginCenter.Parent.Width / 2 - panelLoginCenter.Width / 2;

            panelLanguageCenter.Top = panelLanguageCenter.Parent.Height / 2 - panelLanguageCenter.Height / 2;
            panelLanguageCenter.Left = panelLanguageCenter.Parent.Width / 2 - panelLanguageCenter.Width / 2;

            linkLabelHideHelpPanel.Left = panelHelpTop.Width / 2 - linkLabelHideHelpPanel.Width / 2;
        }
        private void SetLanguage(bool isEnglish)
        {
            IsEnglish = isEnglish;
            StartTheAppWithLanguage().GetAwaiter().GetResult();
        }
        private async Task<bool> StartTheAppWithLanguage()
        {
            SettingUpAllTextForLanguage();
            if (! await CSSPDesktopService.CreateAllRequiredDirectories()) return await Task.FromResult(false);

            // create CSSPDBLocal if it does not exist
            FileInfo fi = new FileInfo(CSSPDesktopService.CSSPDBLocal);
            if (!fi.Exists)
            {
                if (! await CSSPSQLiteService.CreateSQLiteCSSPDBLocal()) return await Task.FromResult(false);
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
                if (! await CSSPSQLiteService.CreateSQLiteCSSPDBLogin()) return await Task.FromResult(false);
            }

            if (! await CSSPDesktopService.CheckIfHelpFilesExist()) return await Task.FromResult(false);

            if (! await CSSPDesktopService.CheckIfLoginIsRequired()) return await Task.FromResult(false);

            if (CSSPDesktopService.LoginRequired)
            {
                linkLabelLogoff.Visible = false;
                linkLabelShowLoginPanel.Visible = true;

                lblContactLoggedIn.Text = "";
                ShowPanels(ShowPanel.Login);
            }
            else
            {
                linkLabelLogoff.Visible = true;
                linkLabelShowLoginPanel.Visible = false;

                lblContactLoggedIn.Text = CSSPDesktopService.ContactLoggedIn.LoginEmail;
                ShowPanels(ShowPanel.Commands);
            }

            return await Task.FromResult(true);
        }
        private bool Setup()
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
            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            if (string.IsNullOrWhiteSpace(CSSPDBLocal))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBLocal", "appsettings_csspdesktop.json"));
                return false;
            }

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            if (string.IsNullOrWhiteSpace(CSSPDBFilesManagement))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBFilesManagement", "appsettings_csspdesktop.json"));
                return false;
            }

            FileInfo fiCSSPDBFileManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFileManagement.FullName }");
            });

            string CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            if (string.IsNullOrWhiteSpace(CSSPDBLogin))
            {
                richTextBoxStatus.AppendText(string.Format(_CouldNotBeFoundInConfigurationFile_, "CSSPDBLogin", "appsettings_csspdesktop.json"));
                return false;
            }

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLogin);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Provider = Services.BuildServiceProvider();

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
            if (CSSPDesktopService == null)
            {
                if (!IsEnglish)
                {
                    richTextBoxStatus.AppendText("CSSPDesktopService ne devrais pas être null\r\n");
                }
                else
                {
                    richTextBoxStatus.AppendText("CSSPDesktopService should not be null\r\n");
                }
                return false;
            }

            CSSPDesktopService.StatusClear += CSSPDesktopService_StatusClear;
            CSSPDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
            CSSPDesktopService.StatusAppendTemp += CSSPDesktopService_StatusAppendTemp;
            CSSPDesktopService.StatusInstalling += CSSPDesktopService_StatusInstalling;
            CSSPDesktopService.StatusErrorMessage += CSSPDesktopService_StatusErrorMessage;

            CSSPDesktopService.IsEnglish = IsEnglish;
            if (!CSSPDesktopService.ReadConfiguration().GetAwaiter().GetResult()) return false;

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            if (CSSPSQLiteService == null)
            {
                richTextBoxStatus.AppendText(string.Format(CSSPDesktopService.appTextModel._ShouldNotBeNull, "CSSPSQLiteService"));
            }

            SettingUpAllTextForLanguage();

            splitContainerFirst.Dock = DockStyle.Fill;
            panelHelp.Dock = DockStyle.Fill;
            richTextBoxStatus.Dock = DockStyle.Fill;
            richTextBoxHelp.Dock = DockStyle.Fill;

            ShowPanels(ShowPanel.Language);

            RecenterPanels();

            CheckInternetConnection();

            return true;
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
            if (CSSPDesktopService.HasInternetConnection == null)
            {
                Text = CSSPDesktopService.appTextModel.FormTitleText;
            }
            else
            {
                if ((bool)CSSPDesktopService.HasInternetConnection)
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.ConnectedOnInternet })";
                }
                else
                {
                    Text = CSSPDesktopService.appTextModel.FormTitleText + $" --- ({ CSSPDesktopService.appTextModel.NoInternetConnection })";
                }
            }

            // PanelTop
            linkLabelShowLanguagePanel.Text = CSSPDesktopService.appTextModel.linkLabelShowLanguagePanelText;
            linkLabelShowHelpPanel.Text = CSSPDesktopService.appTextModel.linkLabelShowHelpPanelText;
            lblLoginEmail.Text = CSSPDesktopService.appTextModel.lblLoginEmailText;
            linkLabelShowLoginPanel.Text = CSSPDesktopService.appTextModel.linkLabelShowLoginPanelText;
            linkLabelLogoff.Text = CSSPDesktopService.appTextModel.linkLabelLogoffText;


            // PanelButtonsCenter
            linkLabelStart.Text = CSSPDesktopService.appTextModel.linkLabelStartText;
            linkLabelStop.Text = CSSPDesktopService.appTextModel.linkLabelStopText;
            linkLabelClose.Text = CSSPDesktopService.appTextModel.linkLabelCloseText;
            linkLabelShowUpdatePanel.Text = CSSPDesktopService.appTextModel.linkLabelUpdatesAvailableText;

            // PanelHelpCenter
            linkLabelHideHelpPanel.Text = CSSPDesktopService.appTextModel.linkLabelHideHelpPanelText;

            // PanelUpdateCenter
            linkLabelUpdate.Text = CSSPDesktopService.appTextModel.linkLabelUpdateText;
            linkLabelCancelUpdate.Text = CSSPDesktopService.appTextModel.linkLabelCancelUpdateText;
            linkLabelUpdateCompleted.Text = CSSPDesktopService.appTextModel.linkLabelUpdateCompletedText;
            lblInstalling.Text = CSSPDesktopService.appTextModel.lblInstallingText;

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTime.Text = CSSPDesktopService.appTextModel.lblCSSPWebToolsLoginOneTimeText;
            lblPassword.Text = CSSPDesktopService.appTextModel.lblPasswordText;
            linkLabelLogin.Text = CSSPDesktopService.appTextModel.linkLabelLoginText;

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
                linkLabelShowHelpPanel.Visible = true;
            }
            else
            {
                linkLabelShowHelpPanel.Visible = false;
            }

            switch (showPanel)
            {
                case ShowPanel.Commands:
                    {
                        panelTop.Visible = true;
                        if (CSSPDesktopService.LoginRequired)
                        {
                            panelLoginCenter.Visible = true;
                        }
                        else
                        {
                            panelCommandsCenter.Visible = true;
                        }

                        linkLabelStart.Focus();
                    }
                    break;
                case ShowPanel.Language:
                    {
                        panelTop.Visible = false;
                        panelLanguageCenter.Visible = true;
                    }
                    break;
                case ShowPanel.Help:
                    {
                        panelTop.Visible = false;
                        string fileToOpen = IsEnglish ? "HelpDocEN.rtf" : "HelpDocFR.rtf";
                        richTextBoxHelp.LoadFile($"{ CSSPDesktopService.LocalCSSPHelpPath }{ fileToOpen }");
                        panelHelp.Visible = true;

                        linkLabelHideHelpPanel.Focus();
                    }
                    break;
                case ShowPanel.Login:
                    {
                        panelTop.Visible = false;
                        panelLoginCenter.Visible = true;
                        textBoxLoginEmail.Focus();
                    }
                    break;
                case ShowPanel.Updates:
                    {
                        panelTop.Visible = true;
                        panelUpdateCenter.Visible = true;
                        linkLabelUpdate.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        private void Start()
        {
            linkLabelStart.Enabled = false;
            linkLabelStop.Enabled = true;
            CSSPDesktopService.Start();
        }
        private void Stop()
        {
            linkLabelStart.Enabled = true;
            linkLabelStop.Enabled = false;
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
