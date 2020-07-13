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
        #endregion Properties

        #region Constructors
        public CSSPDesktopForm()
        {
            InitializeComponent();
            Setup();
        }
        #endregion Constructors

        #region Events
        private void butCloseEverything_Click(object sender, EventArgs e)
        {
            Close();
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
        private void LanguageSelect_Click(object sender, EventArgs e)
        {
            LanguageSelect();
        }
        private async void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await OpenHelp();
        }
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void LanguageSelect()
        {
            richTextBoxStatus.Text = "";

            if (radioButtonEN.Checked)
            {
                CSSPDesktopService.IsEnglish = true;
            }
            if (radioButtonFR.Checked)
            {
                CSSPDesktopService.IsEnglish = false;
            }

            SettingUpAllTextForLanguage();
        }
        private void SettingUpAllTextForLanguage()
        {
            if (CSSPDesktopService.IsEnglish)
            {
                CSSPDesktopService.appTextModel = (AppTextModel)new AppTextModelEN();
            }
            else
            {
                CSSPDesktopService.appTextModel = (AppTextModel)new AppTextModelFR();
            }

            this.Text = CSSPDesktopService.appTextModel.CSSPDesktopFormText;
            lblLanguageText.Text = CSSPDesktopService.appTextModel.lblLanguageText;
            linkLabelHelp.Text = CSSPDesktopService.appTextModel.linkLabelHelpText;
            butStartCSSPWebTools.Text = CSSPDesktopService.appTextModel.butStartCSSPWebToolsText;
            butStopCSSPWebTools.Text = CSSPDesktopService.appTextModel.butStopCSSPWebToolsText;
            butUpdatesAvailable.Text = CSSPDesktopService.appTextModel.butUpdateAvailableText;
            butCloseEverything.Text = CSSPDesktopService.appTextModel.butCloseEverythingText;
            lblNoInternetConnection.Text = CSSPDesktopService.appTextModel.lblNoInternetConnectionText;
        }
        private async void Setup()
        {
            richTextBoxStatus.Dock = DockStyle.Fill;
            richTextBoxStatus.Text = "";
            richTextBoxStatus.AppendText("EN ---- Setting up the application\r\n");
            richTextBoxStatus.AppendText("FR ---- Configuration de l'application\r\n\r\n");

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdesktop.json")
               .AddUserSecrets("c93f6009-1ca1-47b1-9998-2c9d1cade102")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

            Provider = Services.BuildServiceProvider();

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();

            CSSPDesktopService.StatusAppend += CSSPDesktopService_StatusAppend;
            CSSPDesktopService.StatusClear += CSSPDesktopService_StatusClear;

            // doing AppDataPath
            string AppDataPath = Configuration.GetValue<string>("AppDataPath");
            if (string.IsNullOrWhiteSpace(AppDataPath))
            {
                richTextBoxStatus.AppendText("EN ---- AppDataPath not found in appsetting_csspdesktop\r\n");
                richTextBoxStatus.AppendText("FR ---- AppDataPath introuvable dans appsetting_csspdesktop\r\n\r\n");
                return;
            }

            CSSPDesktopService.AppDataPath = AppDataPath.Replace("{AppDataPath}", appDataPath);
            richTextBoxStatus.AppendText($"AppDataPath = [{ CSSPDesktopService.AppDataPath }]\r\n\r\n");

            // doing StartUrl
            string StartUrl = Configuration.GetValue<string>("StartUrl");
            if (string.IsNullOrWhiteSpace(StartUrl))
            {
                richTextBoxStatus.AppendText("EN ---- StartUrl not found in appsetting_csspdesktop\r\n");
                richTextBoxStatus.AppendText("FR ---- StartUrl introuvable dans appsetting_csspdesktop\r\n\r\n");
                return;
            }

            CSSPDesktopService.StartUrl = StartUrl;
            richTextBoxStatus.AppendText($"StartUrl = [{ CSSPDesktopService.StartUrl }]\r\n\r\n");

            // doing CSSPWebAPIsExeFullPath
            string CSSPWebAPIsExeFullPath = Configuration.GetValue<string>("CSSPWebAPIsExeFullPath");
            if (string.IsNullOrWhiteSpace(CSSPWebAPIsExeFullPath))
            {
                richTextBoxStatus.AppendText("EN ---- CSSPWebAPIsExeFullPath not found in appsetting_csspdesktop\r\n");
                richTextBoxStatus.AppendText("FR ---- CSSPWebAPIsExeFullPath introuvable dans appsetting_csspdesktop\r\n\r\n");
                return;
            }

            CSSPDesktopService.CSSPWebAPIsExeFullPath = CSSPWebAPIsExeFullPath.Replace("{AppDataPath}", appDataPath);
            richTextBoxStatus.AppendText($"CSSPWebAPIsExeFullPath = [{ CSSPDesktopService.CSSPWebAPIsExeFullPath }]\r\n\r\n");

            // doing HelpPath 
            string HelpPath = Configuration.GetValue<string>("HelpPath");
            if (string.IsNullOrWhiteSpace(HelpPath))
            {
                richTextBoxStatus.AppendText("EN ---- HelpPath not found in appsetting_csspdesktop\r\n");
                richTextBoxStatus.AppendText("FR ---- HelpPath introuvable dans appsetting_csspdesktop\r\n\r\n");
                return;
            }

            CSSPDesktopService.HelpPath = HelpPath.Replace("{ExecutablePath}", AppDomain.CurrentDomain.BaseDirectory);
            richTextBoxStatus.AppendText($"HelpPath = [{ CSSPDesktopService.HelpPath }]\r\n\r\n");

            // doing InternetConnectionTestingURLs
            List<string> InternetConnectionTestingURLs = Configuration.GetSection("InternetConnectionTestingURLs").GetChildren().Select(x => x.Value).ToList();
            if (InternetConnectionTestingURLs.Count != 2)
            {
                richTextBoxStatus.AppendText("EN ---- InternetConnectionTestingURLs not found in appsetting_csspdesktop\r\n");
                richTextBoxStatus.AppendText("FR ---- InternetConnectionTestingURLs introuvable dans appsetting_csspdesktop\r\n\r\n");
                return;
            }

            CSSPDesktopService.InternetConnectionTestingURLs = InternetConnectionTestingURLs;
            richTextBoxStatus.AppendText($"InternetConnectionTestingURLs = [{ string.Join(", ", CSSPDesktopService.InternetConnectionTestingURLs) }]\r\n\r\n");

            CSSPDesktopService.IsEnglish = true;

            SettingUpAllTextForLanguage();

            if (await CSSPDesktopService.CheckingInternetConnection())
            {
                lblNoInternetConnection.Visible = false;
                richTextBoxStatus.AppendText($"EN ---- Connected To Internet\r\n");
                richTextBoxStatus.AppendText($"FR ---- Connecté à Internet\r\n\r\n");
            }
            else
            {
                lblNoInternetConnection.Visible = true;
                richTextBoxStatus.AppendText($"EN ---- No Internet Connection\r\n");
                richTextBoxStatus.AppendText($"FR ---- Pas de connexion Internet\r\n\r\n");
            }

            if (!lblNoInternetConnection.Visible)
            {
                if (await CSSPDesktopService.CheckingAvailableUpdate())
                {
                    butUpdatesAvailable.Visible = true;
                    richTextBoxStatus.AppendText($"EN ---- Updates Available\r\n");
                    richTextBoxStatus.AppendText($"FR ---- Mises à jour disponibles\r\n\r\n");
                }
                else
                {
                    butUpdatesAvailable.Visible = false;
                    richTextBoxStatus.AppendText($"EN ---- No Upates Available\r\n");
                    richTextBoxStatus.AppendText($"EN ---- Aucune mise à jour disponible\r\n\r\n");
                }
            }
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
