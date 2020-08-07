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

            // PanelTop
            linkLabelShowLanguagePanelText = "Language";
            linkLabelShowHelpPanelText = "Help";
            linkLabelShowLoginPanelText = "Login";
            linkLabelLogoffText = "Logoff";

            // PanelButtonsCenter
            linkLabelStartText = "Start";
            linkLabelStopText = "Stop";
            linkLabelCloseText = "Close";
            linkLabelUpdatesAvailableText = "Updates Available";

            // PanelHelp
            linkLabelHideHelpPanelText = "Close Help";

            // PanelUpdateCenter
            linkLabelUpdateText = "Update";
            linkLabelCancelUpdateText = "Cancel";
            linkLabelUpdateCompletedText = "Update Completed";
            lblInstallingText = "Installing...";

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTimeText = "CSSP Web Tools Login (one time thing)";
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
            CouldNotLogin = "Could not login";
            ErrorWhileTryingToLogin = "Error while trying to login";

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
            // PanelTop
            linkLabelShowLanguagePanelText = "Langage";
            linkLabelShowHelpPanelText = "Aide";
            linkLabelShowLoginPanelText = "Connexion";
            linkLabelLogoffText = "Déconnextion";

            // PanelButtonsCenter
            linkLabelStartText = "Commencer";
            linkLabelStopText = "Arrêter";
            linkLabelCloseText = "Fermer";
            linkLabelUpdatesAvailableText = "Mise à jour disponible";

            // PanelHelp
            linkLabelHideHelpPanelText = "Fermer l'aide";

            // PanelUpdateCenter
            linkLabelUpdateText = "Mise à jour";
            linkLabelCancelUpdateText = "Annuler";
            linkLabelUpdateCompletedText = "Mise à jour complété";
            lblInstallingText = "Installation en cours...";

            // PanelLoginCenter
            lblCSSPWebToolsLoginOneTimeText = "Connexion à l'outil PCCSM (une fois seulement)";
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
            CouldNotLogin = "Dans l'impossibilité d'ouvrir une session";
            ErrorWhileTryingToLogin = "Erreur pendant l'essay d'ouvrir une session";

            // Message
            ConnectedOnInternet = "Connexion internet exist";
            NoInternetConnection = "Aucune connexion internet";
        }
    }
    public class AppTextModel
    {
        // Form
        public string FormTitleText { get; set; }

        // PanelTop
        public string linkLabelShowLanguagePanelText { get; set; }
        public string linkLabelShowHelpPanelText { get; set; }
        public string linkLabelShowLoginPanelText { get; set; }
        public string linkLabelLogoffText { get; set; }

        // PanelButtonsCenter
        public string linkLabelStartText { get; set; }
        public string linkLabelStopText { get; set; }
        public string linkLabelCloseText { get; set; }
        public string linkLabelUpdatesAvailableText { get; set; }

        // PanelHelp
        public string linkLabelHideHelpPanelText { get; set; }

        // PanelUpdateCenter
        public string linkLabelUpdateText { get; set; }
        public string linkLabelCancelUpdateText { get; set; }
        public string linkLabelUpdateCompletedText { get; set; }
        public string lblInstallingText { get; set; }

        // PanelLoginCenter
        public string lblCSSPWebToolsLoginOneTimeText { get; set; }
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
        public string CouldNotLogin { get; set; }
        public string ErrorWhileTryingToLogin { get; set; }

        // Message
        public string ConnectedOnInternet { get; set; }
        public string NoInternetConnection { get; set; }
    }
}
