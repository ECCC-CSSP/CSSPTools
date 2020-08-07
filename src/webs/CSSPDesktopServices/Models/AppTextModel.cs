using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopServices.Models
{
    public class AppTextModelEN : AppTextModel
    {
        public AppTextModelEN()
        {
            // Form
            FormTitleText = "CSSP Desktop Application";

            // PanelButtonsCenter
            linkLabelStartText = "Start";
            linkLabelStopText = "Stop";
            linkLabelCloseText = "Close";
            linkLabelShowLanguagePanelText = "Language";
            linkLabelShowHelpPanelText = "Help";
            linkLabelUpdatesAvailableText = "Updates Available";

            // PanelHelp
            linkLabelHideHelpPanelText = "Close Help";

            // PanelUpdateCenter
            linkLabelUpdateText = "Update";
            linkLabelCancelUpdateText = "Cancel";
            linkLabelUpdateCompletedText = "Update Completed";
            lblInstallingText = "Installing...";

            // PanelLoginCenter
            lblLoginEmailText = "Login Email:";
            lblPasswordText = "Password:";
            linkLabelLoginText = "Login";

            // PanelStatus
            lblStatusText = "Status:";

            // Error
            CouldNotFindFile_ = "Could not find file [{0}]";
            CouldNotCreateDirectory_Error_ = "Could not create directory [{0}]. Error: [{1}]";
            _CouldNotBeFoundInConfigurationFile_ = "{0} could not be found in the configuration file {1}";
            _ShouldNotBeNull = "{0} ne devrais pas être null";

            // Message
            ConnectedOnInternet = "Connected On Internet";
            NoInternetConnection = "No Internet Connection";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            // Form
            FormTitleText = "Application PCCSM de bureau";

            // PanelButtonsCenter
            linkLabelStartText = "Commencer";
            linkLabelStopText = "Arrêter";
            linkLabelCloseText = "Fermer";
            linkLabelHideHelpPanelText = "Fermer";
            linkLabelShowLanguagePanelText = "Langage";
            linkLabelShowHelpPanelText = "Aide";
            linkLabelUpdatesAvailableText = "Mise à jour disponible";

            // PanelUpdateCenter
            linkLabelUpdateText = "Mise à jour";
            linkLabelCancelUpdateText = "Annuler";
            linkLabelUpdateCompletedText = "Mise à jour complété";
            lblInstallingText = "Installation en cours...";

            // PanelLoginCenter
            lblLoginEmailText = "Courriel de connextion:";
            lblPasswordText = "Mot de passe:";
            linkLabelLoginText = "Ouvrir session";

            // PanelStatus
            lblStatusText = "Etat:";

            // Error
            CouldNotFindFile_ = "Dans l'impossibilité de trouver la filière [{0}]";
            CouldNotCreateDirectory_Error_ = "Dans l'impossibilité de créer le répertoire [{0}]. Erreur: [{1}]";
            _CouldNotBeFoundInConfigurationFile_ = "Dans l'impossibilité de trouver {0} dans la filière de configuration {1}";
            _ShouldNotBeNull = "{0} should not be null";

            // Message
            ConnectedOnInternet = "Connexion internet exist";
            NoInternetConnection = "Aucune connexion internet";
        }
    }
    public class AppTextModel
    {
        // Form
        public string FormTitleText { get; set; }

        // PanelButtonsCenter
        public string linkLabelStartText { get; set; }
        public string linkLabelStopText { get; set; }
        public string linkLabelCloseText { get; set; }
        public string linkLabelShowLanguagePanelText { get; set; }
        public string linkLabelShowHelpPanelText { get; set; }
        public string linkLabelUpdatesAvailableText { get; set; }

        // PanelHelp
        public string linkLabelHideHelpPanelText { get; set; }

        // PanelUpdateCenter
        public string linkLabelUpdateText { get; set; }
        public string linkLabelCancelUpdateText { get; set; }
        public string linkLabelUpdateCompletedText { get; set; }
        public string lblInstallingText { get; set; }

        // PanelLoginCenter
        public string lblLoginEmailText { get; set; }
        public string lblPasswordText { get; set; }
        public string linkLabelLoginText { get; set; }

        // PanelStatus
        public string lblStatusText { get; set; }

        // Error
        public string CouldNotFindFile_ { get; set; }
        public string CouldNotCreateDirectory_Error_ { get; set; }
        public string _CouldNotBeFoundInConfigurationFile_ { get; set; }
        public string _ShouldNotBeNull { get; set; }

        // Message
        public string ConnectedOnInternet { get; set; }
        public string NoInternetConnection { get; set; }
    }
}
