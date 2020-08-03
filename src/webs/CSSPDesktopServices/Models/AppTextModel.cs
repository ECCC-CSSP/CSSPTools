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
            butStartText = "Start";
            butStopText = "Stop";
            butCloseText = "Close";
            butShowLanguagePanelText = "Language";
            butShowHelpPanelText = "Help";
            butUpdatesAvailableText = "Updates Available";
            // PanelButtonsCenter Hover
            butStartHoverText = "This button will start the web application";
            butStopHoverText = "This button will stop the web application";
            butCloseHoverText = "This button will close the CSSP Desktop application";
            butShowLanguagePanelHoverText = "This button will let you select your prefered language";
            butShowHelpPanelHoverText = "This button will open a help window";
            butUpdatesAvailableHoverText = "This button indicate that updates are available and will open a page for updating the web application";

            // PanelHelp
            butHideHelpPanelText = "Close Help";

            // PanelUpdateCenter
            butUpdateText = "Update";
            butCancelUpdateText = "Cancel";
            butUpdateCompletedText = "Update Completed";
            lblInstallingText = "Installing...";
            // PanelUpdateCenter Hover
            butUpdateHoverText = "This button will start the update";
            butCancelUpdateHoverText = "This button will return you to the start page";
            butUpdateCompletedHoverText = "This button indicates the update was completed and will return you to the start page";

            // PanelLoginCenter
            lblLoginEmailText = "Login Email:";
            lblPasswordText = "Password:";
            butLoginText = "Login";
            // PanelLoginCenter Hover
            textBoxLoginEmailHoverText = "Please enter your login email used for CSSP Web Tools";
            textBoxPasswordHoverText = "Plese enter your password used for CSSP Web Tools";
            butLoginHoverText = "This button will open a new session in order to locally save required information to run the CSSP Desktop Application";

            // PanelStatus
            lblStatusText = "Status:";

            // Error
            CouldNotFindFile_ = "Could not find file [{0}]";
            CouldNotCreateDirectory_Error_ = "Could not create directory [{0}]. Error: [{1}]";
            _CouldNotBeFoundInConfigurationFile_ = "{0} could not be found in the configuration file {1}";

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
            butStartText = "Commencer";
            butStopText = "Arrêter";
            butCloseText = "Fermer";
            butHideHelpPanelText = "Fermer";
            butShowLanguagePanelText = "Langage";
            butShowHelpPanelText = "Aide";
            butUpdatesAvailableText = "Mise à jour disponible";
            // PanelButtonsCenter Hover
            butStartHoverText = "Ce bouton va commencer l'application web";
            butStopHoverText = "Ce bouton va arrêter l'application web";
            butCloseHoverText = "Ce bouton va fermé l'application PCCSM de bureau";
            butShowHelpPanelHoverText = "Ce bouton va ouvrir une fenêtre d'aide";
            butShowLanguagePanelHoverText = "Ce bouton va vous permettre de choisir le langage de préférence";
            butUpdatesAvailableHoverText = "Ce bouton indique qu'il y a une mise à jour disponible et vous ouvrira une page afin de faire la mise à jour de l'application web";

            // PanelUpdateCenter
            butUpdateText = "Mise à jour";
            butCancelUpdateText = "Annuler";
            butUpdateCompletedText = "Mise à jour complété";
            lblInstallingText = "Installation en cours...";
            // PanelUpdateCenter Hover
            butUpdateHoverText = "Ce bouton va commencer la mise à jour";
            butCancelUpdateHoverText = "Ce bouton va vous retourner à la page de départ";
            butUpdateCompletedHoverText = "Ce bouton indique que la mise à jour est complété et va vous retourner à la page de départ";

            // PanelLoginCenter
            lblLoginEmailText = "Courriel de connextion:";
            lblPasswordText = "Mot de passe:";
            butLoginText = "Ouvrir session";
            // PanelLoginCenter Hover
            textBoxLoginEmailHoverText = "SVP entrez le courriel utilisé pour l'outil web PCCSM";
            textBoxPasswordHoverText = "SVP entrez le mot de passe utilisé pour l'outil web PCCSM";
            butLoginHoverText = "Ce bouton va ouvrir une nouvelle session afin de pouvoir sauvegarder l'information nécessaire pour l'application PCCSM de bureau";

            // PanelStatus
            lblStatusText = "Etat:";

            // Error
            CouldNotFindFile_ = "Dans l'impossibilité de trouver la filière [{0}]";
            CouldNotCreateDirectory_Error_ = "Dans l'impossibilité de créer le répertoire [{0}]. Erreur: [{1}]";
            _CouldNotBeFoundInConfigurationFile_ = "Dans l'impossibilité de trouver {0} dans la filière de configuration {1}"; 

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
        public string butStartText { get; set; }
        public string butStopText { get; set; }
        public string butCloseText { get; set; }
        public string butShowLanguagePanelText { get; set; }
        public string butShowHelpPanelText { get; set; }
        public string butUpdatesAvailableText { get; set; }
        // PanelButtonsCenter Hover
        public string butStartHoverText { get; set; }
        public string butStopHoverText { get; set; }
        public string butCloseHoverText { get; set; }
        public string butShowLanguagePanelHoverText { get; set; }
        public string butShowHelpPanelHoverText { get; set; }
        public string butUpdatesAvailableHoverText { get; set; }

        // PanelHelp
        public string butHideHelpPanelText { get; set; }

        // PanelUpdateCenter
        public string butUpdateText { get; set; }
        public string butCancelUpdateText { get; set; }
        public string butUpdateCompletedText { get; set; }
        public string lblInstallingText { get; set; }
        // PanelUpdateCenter Hover
        public string butCancelUpdateHoverText { get; set; }
        public string butUpdateHoverText { get; set; }
        public string butUpdateCompletedHoverText { get; set; }

        // PanelLoginCenter
        public string lblLoginEmailText { get; set; }
        public string lblPasswordText { get; set; }
        public string butLoginText { get; set; }
        // PanelLoginCenter
        public string textBoxLoginEmailHoverText { get; set; }
        public string textBoxPasswordHoverText { get; set; }
        public string butLoginHoverText { get; set; }

        // PanelStatus
        public string lblStatusText { get; set; }

        // Error
        public string CouldNotFindFile_ { get; set; }
        public string CouldNotCreateDirectory_Error_ { get; set; }
        public string _CouldNotBeFoundInConfigurationFile_ { get; set; }

        // Message
        public string ConnectedOnInternet { get; set; }
        public string NoInternetConnection { get; set; }
    }
}
