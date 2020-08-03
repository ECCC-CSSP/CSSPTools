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
        private void butCancelUpdate_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
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
            SetLanguageToEnglish();
        }
        private void butSetLanguageToFrancais_Click(object sender, EventArgs e)
        {
            SetLanguageToFrench();
        }
        private void butStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void butStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void butUpdatesAvailable_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Updates);
            butUpdateCompleted.Visible = false;
        }
        private void butUpdate_Click(object sender, EventArgs e)
        {
            butCancelUpdate.Enabled = false;
            CSSPDesktopService.InstallUpdates();
            butCancelUpdate.Visible = false;
            butUpdate.Visible = false;
            butUpdateCompleted.Visible = true;
        }
        private void butUpdateCompleted_Click(object sender, EventArgs e)
        {
            ShowPanels(ShowPanel.Commands);
            butCancelUpdate.Enabled = true;
            butCancelUpdate.Visible = true;
            butUpdate.Visible = true;
            butUpdateCompleted.Visible = false;
        }
        #endregion Button Click
        #region Mouse Hover
        private void butCancelUpdate_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butCancelUpdateHoverText;
        }
        private void butClose_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butCloseHoverText;
        }
        private void butShowHelpPanel_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butShowHelpPanelHoverText;
        }
        private void butShowLanguagePanel_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butShowLanguagePanelHoverText;
        }
        private void butStart_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butStartHoverText;
        }
        private void butStop_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butStopHoverText;
        }
        private void panelCommandsCenter_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
        private void butUpdate_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butUpdateHoverText;
        }
        private void butUpdateCompleted_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butUpdateCompletedHoverText;
        }
        private void panelUpdateCenter_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
        private void splitContainerFirst_Panel1_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
        private void butUpdatesAvailable_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butUpdatesAvailableHoverText;
        }
        private void textBoxLoginEmail_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.textBoxLoginEmailHoverText;
        }
        private void textBoxPassword_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.textBoxPasswordHoverText;
        }
        private void butLogin_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = CSSPDesktopService.appTextModel.butLoginHoverText;
        }
        #endregion Mouse Hover
        #region Form Resize
        private void CSSPDesktopForm_Resize(object sender, EventArgs e)
        {
            RecenterPanels();
        }
        #endregion Form Resize
        #region TimerCheckInternetConnection
        private void timerCheckInternetConnection_Tick(object sender, EventArgs e)
        {
            timerCheckInternetConnection.Stop();

            DoTimerCheckInternetConnection();

            timerCheckInternetConnection.Start();
        }

        private void DoTimerCheckInternetConnection()
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
        #endregion TimerCheckInternetConnection
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
        private void butLogin_Click(object sender, EventArgs e)
        {
            CSSPDesktopService.Login(textBoxLoginEmail.Text.Trim(), textBoxPassword.Text.Trim());
        }
        #endregion Login
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
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

            butHideHelpPanel.Left = panelHelpTop.Width / 2 - butHideHelpPanel.Width / 2;
        }
        private void SetLanguageToEnglish()
        {
            IsEnglish = true;
            StartTheAppWithLanguage();
        }
        private void SetLanguageToFrench()
        {
            IsEnglish = false;
            StartTheAppWithLanguage();
        }
        private void StartTheAppWithLanguage()
        {
            SettingUpAllTextForLanguage();
            CSSPDesktopService.AnalyseDirectoriesAndDatabases();
            if (CSSPDesktopService.LoginRequired)
            {
                ShowPanels(ShowPanel.Login);
            }
            else
            {
                ShowPanels(ShowPanel.Commands);
            }
        }
        private bool Setup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdesktop.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

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
            if (!CSSPDesktopService.ReadConfiguration()) return false;

            SettingUpAllTextForLanguage();

            splitContainerFirst.Dock = DockStyle.Fill;
            panelHelp.Dock = DockStyle.Fill;
            richTextBoxStatus.Dock = DockStyle.Fill;
            richTextBoxHelp.Dock = DockStyle.Fill;

            ShowPanels(ShowPanel.Language);

            RecenterPanels();

            CSSPDesktopService.CreateAllRequiredDirectories();

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDesktopService.CSSPDBLocal.Replace("{CSSPDesktopPath}", CSSPDesktopService.CSSPDesktopPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDesktopService.CSSPDBLogin.Replace("{CSSPDesktopPath}", CSSPDesktopService.CSSPDesktopPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Provider = Services.BuildServiceProvider();

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
            Text = CSSPDesktopService.appTextModel.FormTitleText;

            // PanelButtonsCenter
            butStart.Text = CSSPDesktopService.appTextModel.butStartText;
            butStop.Text = CSSPDesktopService.appTextModel.butStopText;
            butClose.Text = CSSPDesktopService.appTextModel.butCloseText;
            butShowLanguagePanel.Text = CSSPDesktopService.appTextModel.butShowLanguagePanelText;
            butShowHelpPanel.Text = CSSPDesktopService.appTextModel.butShowHelpPanelText;
            butUpdatesAvailable.Text = CSSPDesktopService.appTextModel.butUpdatesAvailableText;

            // PanelHelpCenter
            butHideHelpPanel.Text = CSSPDesktopService.appTextModel.butHideHelpPanelText;

            // PanelUpdateCenter
            butUpdate.Text = CSSPDesktopService.appTextModel.butUpdateText;
            butCancelUpdate.Text = CSSPDesktopService.appTextModel.butCancelUpdateText;
            butUpdateCompleted.Text = CSSPDesktopService.appTextModel.butUpdateCompletedText;
            lblInstalling.Text = CSSPDesktopService.appTextModel.lblInstallingText;

            // PanelLoginCenter
            lblLoginEmail.Text = CSSPDesktopService.appTextModel.lblLoginEmailText;
            lblPassword.Text = CSSPDesktopService.appTextModel.lblPasswordText;
            butLogin.Text = CSSPDesktopService.appTextModel.butLoginText;

            // PanelStatus
            lblStatus.Text = CSSPDesktopService.appTextModel.lblStatusText;
        }
        private void ShowPanels(ShowPanel showPanel)
        {
            panelLanguageCenter.Visible = false;
            panelUpdateCenter.Visible = false;
            panelLoginCenter.Visible = false;
            panelHelp.Visible = false;
            panelCommandsCenter.Visible = false;

            switch (showPanel)
            {
                case ShowPanel.Commands:
                    panelCommandsCenter.Visible = true;
                    break;
                case ShowPanel.Language:
                    panelLanguageCenter.Visible = true;
                    break;
                case ShowPanel.Help:
                    {
                        string fileToOpen = IsEnglish ? "HelpDocEN.rtf" : "HelpDocFR.rtf";
                        richTextBoxHelp.LoadFile($"{ Environment.CurrentDirectory }\\helpdocs\\{ fileToOpen }");
                        panelHelp.Visible = true;
                    }
                    break;
                case ShowPanel.Login:
                    panelLoginCenter.Visible = true;
                    break;
                case ShowPanel.Updates:
                    panelUpdateCenter.Visible = true;
                    break;
                default:
                    break;
            }
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
