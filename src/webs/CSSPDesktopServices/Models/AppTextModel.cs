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
            butGetUpdatesText = "Get Updates";
            butHideHelpPanelText = "Close Help";
            butShowHelpPanelText = "Help";
            butShowLanguagePanelText = "Language";
            butStartText = "Start";
            butStopText = "Stop";
            lblStatusText = "Status:";

            butCloseHoverText = "This button will close the CSSP Desktop application";
            butGetUpdatesHoverText = "This button will get the update of the web application";
            butShowHelpPanelHoverText = "This button will open a help window";
            butShowLanguagePanelHoverText = "This button will let you select your prefered language";
            butStartHoverText = "This button will start the web application";
            butStopHoverText = "This button will stop the web application";

            // Error
            CouldNotFindFile_ = "Could not find file [{0}]";

            // Message
            HasInternetConnection = "Has Internet Connection";
            HasNoInternetConnection = "Has No Internet Connection";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            FormTitleText = "Application PCCSM de bureau";
            butCloseText = "Fermer";
            butGetUpdatesText = "Faire un mise à jour";
            butHideHelpPanelText = "Fermer";
            butShowHelpPanelText = "Aide";
            butShowLanguagePanelText = "Langage";
            butStartText = "Commencer";
            butStopText = "Arrêter";
            lblStatusText = "Etat:";

            butCloseHoverText = "Ce bouton va fermé l'application PCCSM de bureau";
            butGetUpdatesHoverText = "Ce bouton va faire un mise à jour de l'application web";
            butShowHelpPanelHoverText = "Ce bouton va ouvrir une fenêtre d'aide";
            butShowLanguagePanelHoverText = "Ce bouton va vous permettre de choisir le langage de préférence";
            butStartHoverText = "Ce bouton va commencer l'application web";
            butStopHoverText = "Ce bouton va arrêter l'application web";

            // Error
            CouldNotFindFile_ = "Dans l'impossibilité de trouver la filière [{0}]";

            // Message
            HasInternetConnection = "Connexion internet exist";
            HasNoInternetConnection = "Aucune connexion internet";
        }
    }
    public class AppTextModel
    {
        // Label and Button text
        public string FormTitleText { get; set; }
        public string butCloseText { get; set; }
        public string butGetUpdatesText { get; set; }
        public string butHideHelpPanelText { get; set; }
        public string butShowHelpPanelText { get; set; }
        public string butShowLanguagePanelText { get; set; }
        public string butStartText { get; set; }
        public string butStopText { get; set; }
        public string lblStatusText { get; set; }

        // Mouse Hover text
        public string butCloseHoverText { get; set; }
        public string butGetUpdatesHoverText { get; set; }
        public string butShowHelpPanelHoverText { get; set; }
        public string butShowLanguagePanelHoverText { get; set; }
        public string butStartHoverText { get; set; }
        public string butStopHoverText { get; set; }

        // Error
        public string CouldNotFindFile_ { get; set; }

        // Message
        public string HasInternetConnection { get; set; }
        public string HasNoInternetConnection { get; set; }
    }
}
