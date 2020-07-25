using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        private bool IsEnglish { get; set; }
        private string UpdateApplicationNotFound { get; set; }
        private string NoInternetConnectionFound { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDesktopForm()
        {
            InitializeComponent();
            ShowLanguagePanel();
        }
        #endregion Constructors

        #region Events
        private void butCloseEverything_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void butEnglish_Click(object sender, EventArgs e)
        {
            SetEnglish(true);
        }
        private void butFrancais_Click(object sender, EventArgs e)
        {
            SetEnglish(false);
        }
        private async void butStartCSSPWebTools_Click(object sender, EventArgs e)
        {
            if (!await Start()) return;

            butStartCSSPWebTools.Visible = false;
            butStopCSSPWebTools.Visible = true;
        }
        private async void butStopCSSPWebTools_Click(object sender, EventArgs e)
        {
            if (!await Stop()) return;

            butStartCSSPWebTools.Visible = true;
            butStopCSSPWebTools.Visible = false;
        }
        private void butUpdatesAvailable_Click(object sender, EventArgs e)
        {
            RunCSSPDesktopUpdateProcess();
        }
        private async void CSSPDesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await Stop();
        }
        private void CSSPDesktopService_StatusClear(object sender, ClearEventArgs e)
        {
            richTextBoxStatus.Text = "";
        }
        private void CSSPDesktopService_StatusAppend(object sender, AppendEventArgs e)
        {
            richTextBoxStatus.AppendText(e.Message);
        }
        private async void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await OpenHelp();
        }
        private void linkLabelLanguage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLanguagePanel();
        }
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task RunCSSPDesktopUpdateProcess()
        {
            if (! await CSSPDesktopService.CheckingInternetConnection())
            {
                richTextBoxStatus.Text = NoInternetConnectionFound;
                return;
            }

            FileInfo fi = new FileInfo(Environment.CurrentDirectory + @"\CSSPDesktopUpdate.exe");
            if (!fi.Exists)
            {
                richTextBoxStatus.Text = string.Format(UpdateApplicationNotFound, fi.FullName);
                return;
            }

            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = fi.FullName;
            processStartInfo.Arguments = IsEnglish ? "en" : "fr";
            processStartInfo.UseShellExecute = true;

            process.StartInfo = processStartInfo;
            process.Start();

            Close();
        }
        private async void SetEnglish(bool SetIsEnglish)
        {
            IsEnglish = SetIsEnglish;
            panelLanguage.SendToBack();
            panelLeft.Dock = DockStyle.Left;
            panelRight.Dock = DockStyle.Fill;
            richTextBoxStatus.Dock = DockStyle.Fill;

            if (await Setup())
            {
                CSSPDesktopService.IsEnglish = IsEnglish;
                SettingUpAllTextForLanguage();
            }
        }
        private void SettingUpAllTextForLanguage()
        {
            if (CSSPDesktopService.IsEnglish)
            {
                CSSPDesktopService.appTextModel = new AppTextModelEN();
            }
            else
            {
                CSSPDesktopService.appTextModel = new AppTextModelFR();
            }

            Text = CSSPDesktopService.appTextModel.CSSPDesktopFormText;
            linkLabelLanguage.Text = CSSPDesktopService.appTextModel.linkLabelLanguageText;
            linkLabelHelp.Text = CSSPDesktopService.appTextModel.linkLabelHelpText;
            butStartCSSPWebTools.Text = CSSPDesktopService.appTextModel.butStartCSSPWebToolsText;
            butStopCSSPWebTools.Text = CSSPDesktopService.appTextModel.butStopCSSPWebToolsText;
            butUpdatesAvailable.Text = CSSPDesktopService.appTextModel.butUpdateAvailableText;
            butCloseEverything.Text = CSSPDesktopService.appTextModel.butCloseEverythingText;
            lblNoInternetConnection.Text = CSSPDesktopService.appTextModel.lblNoInternetConnectionText;
            UpdateApplicationNotFound = CSSPDesktopService.appTextModel.UpdateApplicationNotFound;
        }
        private async Task<bool> Setup()
        {
            richTextBoxStatus.Text = "";

            Services = new ServiceCollection();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

            Provider = Services.BuildServiceProvider();

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();

            CSSPDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
            CSSPDesktopService.StatusClear += CSSPDesktopService_StatusClear;

            CSSPDesktopService.AppDataPath = appDataPath + "\\cssp\\";
            CSSPDesktopService.StartUrl = "https://localhost:4447/";
            CSSPDesktopService.CSSPWebAPIsExeFullPath = CSSPDesktopService.AppDataPath + "csspwebapis\\CSSPWebAPIs.exe";
            CSSPDesktopService.HelpPath = CSSPDesktopService.AppDataPath + "csspdesktop\\helpdocs\\";

            CSSPDesktopService.IsEnglish = true;

            SettingUpAllTextForLanguage();

            if (await CSSPDesktopService.CheckingInternetConnection())
            {
                lblNoInternetConnection.Visible = false;
            }
            else
            {
                lblNoInternetConnection.Visible = true;
            }

            if (!lblNoInternetConnection.Visible)
            {
                if (await CSSPDesktopService.CheckingAvailableUpdate())
                {
                    butUpdatesAvailable.Visible = true;
                }
                else
                {
                    butUpdatesAvailable.Visible = false;
                }
            }

            return await Task.FromResult(true);
        }
        private void ShowLanguagePanel()
        {
            panelLeft.Dock = DockStyle.None;
            panelLanguage.Dock = DockStyle.Fill;
            panelLanguage.BringToFront();
            panelLanguageCenter.Top = (panelLanguage.Height / 2) - (panelLanguageCenter.Height / 2);
            panelLanguageCenter.Left = (panelLanguage.Width / 2) - (panelLanguageCenter.Width / 2);
        }

        private async Task<bool> OpenHelp()
        {
            if (!await CSSPDesktopService.OpenHelp()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        private async Task<bool> Start()
        {
            if (!await CSSPDesktopService.Start()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        private async Task<bool> Stop()
        {
            if (!await CSSPDesktopService.Stop()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }


        #endregion Functions private

    }
}
