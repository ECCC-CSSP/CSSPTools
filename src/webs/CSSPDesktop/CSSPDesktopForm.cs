using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        ICSSPDesktopService csspDesktopService { get; set; }
        ShowPanel currentPanel { get; set; } = ShowPanel.Buttons;
        bool IsEnglish { get; set; } = true;
        #endregion Properties

        #region Constructors
        public CSSPDesktopForm()
        {
            InitializeComponent();
            Setup();
        }
        #endregion Constructors

        #region Events
        #region Button Click
        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void butGetUpdates_Click(object sender, EventArgs e)
        {
            GetUpdates();
        }
        private void butHideHelpPanel_Click(object sender, EventArgs e)
        {
            HideHelpPanel();
        }
        private void butShowHelpPanel_Click(object sender, EventArgs e)
        {
            ShowHelpPanel();
        }
        private void butShowLanguagePanel_Click(object sender, EventArgs e)
        {
            ShowLanguagePanel();
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
        #endregion Button Click
        #region Mouse Hover
        private void butClose_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butCloseHoverText;
        }
        private void butGetUpdates_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butGetUpdatesHoverText;
        }
        private void butShowHelpPanel_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butShowHelpPanelHoverText;
        }
        private void butShowLanguagePanel_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butShowLanguagePanelHoverText;
        }
        private void butStart_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butStartHoverText;
        }
        private void butStop_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = csspDesktopService.appTextModel.butStopHoverText;
        }
        private void panelButtonCenter_MouseHover(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
        #endregion Mouse Hover
        #region Form Resize
        private void CSSPDesktopForm_Resize(object sender, EventArgs e)
        {
            SetupPanels();
        }
        #endregion Foem Resize
        #region TimerCheckInternetConnection
        private void timerCheckInternetConnection_Tick(object sender, EventArgs e)
        {
            timerCheckInternetConnection.Stop();

            DoTimerCheckInternetConnection();

            //timerCheckInternetConnection.Start();
        }

        private void DoTimerCheckInternetConnection()
        {
            csspDesktopService.CheckingInternetConnection();

            if (csspDesktopService.HasInternetConnection)
            {
                Text = csspDesktopService.appTextModel.FormTitleText + $" --- ({ csspDesktopService.appTextModel.HasInternetConnection })";
            }
            else
            {
                Text = csspDesktopService.appTextModel.FormTitleText + $" --- ({ csspDesktopService.appTextModel.HasNoInternetConnection })";
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
        #endregion csspDesktopServiceEvent
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void GetUpdates()
        {
            throw new NotImplementedException();
        }
        private void HideHelpPanel()
        {
            splitContainerFirst.BringToFront();
        }
        private void ShowHelpPanel()
        {
            panelHelp.BringToFront();
            string fileToOpen = IsEnglish ? "HelpDocEN.html" : "HelpDocFR.html";

            webBrowserHelp.Navigate($"{ Environment.CurrentDirectory }\\helpdocs\\{ fileToOpen }");
        }
        private void ShowLanguagePanel()
        {
            panelLanguage.BringToFront();
        }
        private void SetLanguageToEnglish()
        {
            IsEnglish = true;
            SettingUpAllTextForLanguage();
            currentPanel = ShowPanel.Buttons;
            SetupPanels();
        }
        private void SetLanguageToFrench()
        {
            IsEnglish = false;
            SettingUpAllTextForLanguage();
            currentPanel = ShowPanel.Buttons;
            SetupPanels();
        }
        private void Setup()
        {
            csspDesktopService = new CSSPDesktopService();

            csspDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
            csspDesktopService.StatusClear += CSSPDesktopService_StatusClear;

            csspDesktopService.IsEnglish = IsEnglish;
            SettingUpAllTextForLanguage();
            currentPanel = ShowPanel.Buttons;
            SetupPanels();

            csspDesktopService.CreateAllRequiredDirectories();
            //csspDesktopService.CheckingInternetConnection();
            //SettingUpAllTextForLanguage();
        }
        private void SettingUpAllTextForLanguage()
        {
            csspDesktopService.IsEnglish = IsEnglish;

            if (IsEnglish)
            {
                csspDesktopService.appTextModel = new AppTextModelEN();
            }
            else
            {
                csspDesktopService.appTextModel = new AppTextModelFR();
            }

            Text = csspDesktopService.appTextModel.FormTitleText;
            butHideHelpPanel.Text = csspDesktopService.appTextModel.butHideHelpPanelText;
            butClose.Text = csspDesktopService.appTextModel.butCloseText;
            butGetUpdates.Text = csspDesktopService.appTextModel.butGetUpdatesText;
            butShowHelpPanel.Text = csspDesktopService.appTextModel.butShowHelpPanelText;
            butShowLanguagePanel.Text = csspDesktopService.appTextModel.butShowLanguagePanelText;
            butStart.Text = csspDesktopService.appTextModel.butStartText;
            butStop.Text = csspDesktopService.appTextModel.butStopText;
            lblStatus.Text = csspDesktopService.appTextModel.lblStatusText;
        }
        private void SetupPanels()
        {
            switch (currentPanel)
            {
                case ShowPanel.Buttons:
                    splitContainerFirst.BringToFront();
                    break;
                case ShowPanel.Language:
                    panelLanguage.BringToFront();
                    break;
                case ShowPanel.Help:
                    panelHelp.BringToFront();
                    break;
                default:
                    break;
            }
            panelLanguage.Dock = DockStyle.Fill;
            splitContainerFirst.Dock = DockStyle.Fill;
            panelHelp.Dock = DockStyle.Fill;
            richTextBoxStatus.Dock = DockStyle.Fill;
            webBrowserHelp.Dock = DockStyle.Fill;

            panelButtonCenter.Top = panelButtonCenter.Parent.Height / 2 - panelButtonCenter.Height / 2;
            panelButtonCenter.Left = panelButtonCenter.Parent.Width / 2 - panelButtonCenter.Width / 2;

            panelLanguageCenter.Top = panelLanguageCenter.Parent.Height / 2 - panelLanguageCenter.Height / 2;
            panelLanguageCenter.Left = panelLanguageCenter.Parent.Width / 2 - panelLanguageCenter.Width / 2;

            butHideHelpPanel.Left = panelHelpTop.Width / 2 - butHideHelpPanel.Width / 2;
        }
        private void Start()
        {
            butStart.Enabled = false;
            butStop.Enabled = true;
            csspDesktopService.Start();
        }
        private void Stop()
        {
            butStart.Enabled = true;
            butStop.Enabled = false;
            csspDesktopService.Stop();
        }
        #endregion Functions private

        #region Enums
        private enum ShowPanel
        {
            Buttons,
            Language,
            Help,
        }
        #endregion Enums

    }
}
