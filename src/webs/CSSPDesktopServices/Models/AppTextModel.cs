﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPDesktopServices.Models
{
    public class AppTextModelEN : AppTextModel
    {
        public AppTextModelEN()
        {
            CSSPDesktopFormText = "CSSP Desktop Application";
            lblLanguageText = "Language:";
            linkLabelHelpText = "Help";
            butStartCSSPWebToolsText = "Start CSSP Web Tools";
            butStopCSSPWebToolsText = "Stop CSSP Web Tools";
            butUpdateAvailableText = "Update Available";
            butCloseEverythingText = "Close Everything";
            lblNoInternetConnectionText = "No Internet Connection";
            StartingCSSPWebAPIs = "Starting CSSPWebAPIs";
            StartedCSSPWebAPIs = "Started CSSPWebAPIs";
            StartingCSSPWebTools = "Starting CSSPWebTools";
            StartedCSSPWebTools = "Started CSSPWebTools";
        }
    }
    public class AppTextModelFR : AppTextModel
    {
        public AppTextModelFR()
        {
            CSSPDesktopFormText = "Application de bureau PCCSM";
            lblLanguageText = "Langage:";
            linkLabelHelpText = "Aide";
            butStartCSSPWebToolsText = "Ouvrir Outils Web PCCSM";
            butStopCSSPWebToolsText = "Annuler Outils Web Tools";
            butUpdateAvailableText = "Mise à jour disponible";
            butCloseEverythingText = "Ferme Tout";
            lblNoInternetConnectionText = "Pas de Connecton Internet";
            StartingCSSPWebAPIs = "Démarrage de CSSPWebAPIs";
            StartedCSSPWebAPIs = "CSSPWebAPIs démarrée ";
            StartingCSSPWebTools = "Démarrage de CSSPWebTools";
            StartedCSSPWebTools = "CSSPWebTools démarrée ";
        }
    }
    public class AppTextModel
    {
        public string CSSPDesktopFormText { get; set; }
        public string lblLanguageText { get; set; }
        public string linkLabelHelpText { get; set; }
        public string butStartCSSPWebToolsText { get; set; }
        public string butStopCSSPWebToolsText { get; set; }
        public string butUpdateAvailableText { get; set; }
        public string butCloseEverythingText { get; set; }
        public string lblNoInternetConnectionText { get; set; }
        public string StartingCSSPWebAPIs { get; set; }
        public string StartedCSSPWebAPIs { get; set; }
        public string StartingCSSPWebTools { get; set; }
        public string StartedCSSPWebTools { get; set; }
    }
}
