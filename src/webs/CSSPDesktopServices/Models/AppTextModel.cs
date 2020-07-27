using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopServices.Models
{
    public class AppTextModelEN : AppTextModel
    {
        public AppTextModelEN()
        {
            FormTitleText = "CSSP Desktop Application";
            butCloseText = "Close";
            butHideHelpPanelText = "Close Help";
            butShowHelpPanelText = "Help";
            butShowLanguagePanelText = "Language";
            butStartText = "Start";
            butStopText = "Stop";
            butUpdatesAvailableText = "Updates Available";
            butUpdateText = "Update";
            butCancelUpdateText = "Cancel";
            butUpdateCompletedText = "Update Completed";
            lblStatusText = "Status:";

            butCancelUpdateHoverText = "This button will return you to the start page";
            butCloseHoverText = "This button will close the CSSP Desktop application";
            butShowHelpPanelHoverText = "This button will open a help window";
            butShowLanguagePanelHoverText = "This button will let you select your prefered language";
            butStartHoverText = "This button will start the web application";
            butStopHoverText = "This button will stop the web application";
            butUpdateHoverText = "This button will start the update";
            butUpdateCompletedHoverText = "This button indicates the update was completed and will return you to the start page";
            butUpdatesAvailableHoverText = "This button indicate that updates are available and will open a page for updating the web application";

            // Error
            CouldNotFindFile_ = "Could not find file [{0}]";

            // Message
            ConnectedOnInternet = "Connected On Internet";
            NoInternetConnection = "No Internet Connection";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            FormTitleText = "Application PCCSM de bureau";
            butCloseText = "Fermer";
            butHideHelpPanelText = "Fermer";
            butShowHelpPanelText = "Aide";
            butShowLanguagePanelText = "Langage";
            butStartText = "Commencer";
            butStopText = "Arrêter";
            butUpdatesAvailableText = "Mise à jour disponible";
            butUpdateText = "Mise à jour";
            butCancelUpdateText = "Annuler";
            butUpdateCompletedText = "Mise à jour complété";
            lblStatusText = "Etat:";

            butCancelUpdateHoverText = "Ce bouton va vous retourner à la page de départ";
            butCloseHoverText = "Ce bouton va fermé l'application PCCSM de bureau";
            butShowHelpPanelHoverText = "Ce bouton va ouvrir une fenêtre d'aide";
            butShowLanguagePanelHoverText = "Ce bouton va vous permettre de choisir le langage de préférence";
            butStartHoverText = "Ce bouton va commencer l'application web";
            butStopHoverText = "Ce bouton va arrêter l'application web";
            butUpdateHoverText = "Ce bouton va commencer la mise à jour";
            butUpdateCompletedHoverText = "Ce bouton indique que la mise à jour est complété et va vous retourner à la page de départ";
            butUpdatesAvailableHoverText = "Ce bouton indique qu'il y a une mise à jour disponible et vous ouvrira une page afin de faire la mise à jour de l'application web";

            // Error
            CouldNotFindFile_ = "Dans l'impossibilité de trouver la filière [{0}]";

            // Message
            ConnectedOnInternet = "Connexion internet exist";
            NoInternetConnection = "Aucune connexion internet";
        }
    }
    public class AppTextModel
    {
        // Label and Button text
        public string FormTitleText { get; set; }
        public string butCloseText { get; set; }
        public string butHideHelpPanelText { get; set; }
        public string butShowHelpPanelText { get; set; }
        public string butShowLanguagePanelText { get; set; }
        public string butStartText { get; set; }
        public string butStopText { get; set; }
        public string lblStatusText { get; set; }
        public string butUpdatesAvailableText { get; set; }
        public string butUpdateText { get; set; }
        public string butCancelUpdateText { get; set; }
        public string butUpdateCompletedText { get; set; }

        // Mouse Hover text
        public string butCancelUpdateHoverText { get; set; }
        public string butCloseHoverText { get; set; }
        public string butShowHelpPanelHoverText { get; set; }
        public string butShowLanguagePanelHoverText { get; set; }
        public string butStartHoverText { get; set; }
        public string butStopHoverText { get; set; }
        public string butUpdateHoverText { get; set; }
        public string butUpdateCompletedHoverText { get; set; }
        public string butUpdatesAvailableHoverText { get; set; }

        // Error
        public string CouldNotFindFile_ { get; set; }

        // Message
        public string ConnectedOnInternet { get; set; }
        public string NoInternetConnection { get; set; }
    }
}
