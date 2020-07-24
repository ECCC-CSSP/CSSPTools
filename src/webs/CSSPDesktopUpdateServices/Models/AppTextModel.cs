using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopUpdateServices.Models
{
    public class AppTextModelEN : AppTextModel
    {
        public AppTextModelEN()
        {
            CSSPDesktopUpdateFormText = "CSSP Desktop Update Application";
            lblDownloadingUpdateText = "Downloading update ...";
            lblInstallingUpdateText = "Installing update ...";
            lblCSSPDesktopRestartText = "CSSP Desktop Application will be automatically restarted once updating is completed";
            CSSPDesktopApplicationNotFoundText = "CSSP Desktop application not found [{0}]";
            NoInternetConnectionFoundText = "No internet connection found";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            CSSPDesktopUpdateFormText = "Application de bureau PCCSM mise à jour";
            lblDownloadingUpdateText = "Téléchargement pour mise à jour ...";
            lblInstallingUpdateText = "Intallation pour mise à jour ...";
            lblCSSPDesktopRestartText = "Application de bureau PCCSM sera reparti une fois la mise à jour complétée";
            CSSPDesktopApplicationNotFoundText = "Dans l'impossibilité de trouver l'application de bureau PCCSM  [{0}]";
            NoInternetConnectionFoundText = "Dans l'impossibilité de trouver une connexion internet";
        }
    }
    public class AppTextModel
    {
        public string CSSPDesktopUpdateFormText { get; set; }
        public string lblDownloadingUpdateText { get; set; }
        public string lblInstallingUpdateText { get; set; }
        public string lblCSSPDesktopRestartText { get; set; }
        public string CSSPDesktopApplicationNotFoundText { get; set; }
        public string NoInternetConnectionFoundText { get; set; }
    }
}
