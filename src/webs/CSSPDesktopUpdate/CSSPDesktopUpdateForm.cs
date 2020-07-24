using CSSPDesktopUpdateServices.Models;
using CSSPDesktopUpdateServices.Services;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPDesktopUpdate
{
    public partial class CSSPDesktopUpdateForm : Form
    {
        #region Variables
        #endregion Variables

        #region Parameters
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPDesktopUpdateService CSSPDesktopUpdateService { get; set; }
        private bool IsEnglish { get; set; }
        #endregion Parameters

        #region Constructors
        public CSSPDesktopUpdateForm()
        {
            InitializeComponent();

            if (!Setup()) return;
        }
        #endregion Constructors

        #region Events
        private void CSSPDesktopUpdateService_StatusDownloading(object sender, DownloadingEventArgs e)
        {
            progressBarDownloading.Value = e.Percent;
            progressBarDownloading.Refresh();
            Application.DoEvents();
        }
        private void CSSPDesktopUpdateService_StatusInstalling(object sender, InstallingEventArgs e)
        {
            progressBarInstalling.Value = e.Percent;
            progressBarDownloading.Refresh();
            Application.DoEvents();
        }
        private void CSSPDesktopUpdateService_StatusErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            lblError.Text = e.ErrorMessage;
            lblError.Refresh();
            Application.DoEvents();
        }
        private void timerCSSPDesktopUpdate_Tick(object sender, EventArgs e)
        {
            timerCSSPDesktopUpdate.Enabled = false;
            Start();
        }
        #endregion Events

        #region Functions private
        private bool Start()
        {
            if (!CSSPDesktopUpdateService.Start()) return false;

            Close();

            return true;
        }
        private bool Setup()
        {
            IsEnglish = true;

            Services = new ServiceCollection();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            Services.AddSingleton<ICSSPDesktopUpdateService, CSSPDesktopUpdateService>();

            try
            {
                Provider = Services.BuildServiceProvider();
                CSSPDesktopUpdateService = Provider.GetService<ICSSPDesktopUpdateService>();

                CSSPDesktopUpdateService.StatusDownloading += CSSPDesktopUpdateService_StatusDownloading;
                CSSPDesktopUpdateService.StatusInstalling += CSSPDesktopUpdateService_StatusInstalling;
                CSSPDesktopUpdateService.StatusErrorMessage += CSSPDesktopUpdateService_StatusErrorMessage;

                string[] args = Environment.GetCommandLineArgs();

                if (args.Count() > 1)
                {
                    lblError.Text = args[1];

                    if (args[1] == "fr")
                    {
                        IsEnglish = false;
                    }
                }

                CSSPDesktopUpdateService.IsEnglish = IsEnglish;

                if (CSSPDesktopUpdateService.IsEnglish)
                {
                    CSSPDesktopUpdateService.appTextModel = new AppTextModelEN();
                }
                else
                {
                    CSSPDesktopUpdateService.appTextModel = new AppTextModelFR();
                }

                Text = CSSPDesktopUpdateService.appTextModel.CSSPDesktopUpdateFormText;
                lblDownloadingUpdate.Text = CSSPDesktopUpdateService.appTextModel.lblDownloadingUpdateText;
                lblInstallingUpdate.Text = CSSPDesktopUpdateService.appTextModel.lblInstallingUpdateText;
                lblCSSPDesktopRestart.Text = CSSPDesktopUpdateService.appTextModel.lblCSSPDesktopRestartText;
                //lblError.Text = "";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return false;
            }

            timerCSSPDesktopUpdate.Enabled = true;

            return true;
        }
        #endregion Functions private


    }
}
