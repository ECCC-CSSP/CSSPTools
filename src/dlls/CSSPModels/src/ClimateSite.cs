/*
 * Manually edited by Charles LeBlanc 
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPModels
{
    public partial class ClimateSite : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ClimateSite ID")]
        [CSSPDisplayFR(DisplayFR = "ClimateSite ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ClimateSites table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ClimateSites")]
        public int ClimateSiteID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "4")]
        [CSSPDisplayEN(DisplayEN = "ClimateSite TVItemID")]
        [CSSPDisplayFR(DisplayFR = "ClimateSite TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int ClimateSiteTVItemID { get; set; }
        [Range(1, 100000)]
        [CSSPDisplayEN(DisplayEN = "ECDBID")]
        [CSSPDisplayFR(DisplayFR = "ECDBID")]
        [CSSPDescriptionEN(DescriptionEN = @"ECDBID --- Environment Canada weather office web site unique id for the weather climate site")]
        [CSSPDescriptionFR(DescriptionFR = @"ECDBID --- Site Web du bureau météorologique d'Environnement Canada identifiant le site de site climatatique")]
        public int? ECDBID { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Climate site name")]
        [CSSPDisplayFR(DisplayFR = "Nom du site climatique")]
        [CSSPDescriptionEN(DescriptionEN = @"Climate site name is a unique name for the site given by Environment Canada")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du site climatique est un nom unique pour le site donné par Environnement Canada")]
        public string ClimateSiteName { get; set; }
        [StringLength(4)]
        [CSSPDisplayEN(DisplayEN = "Province")]
        [CSSPDisplayFR(DisplayFR = "Province")]
        [CSSPDescriptionEN(DescriptionEN = @"Province identified by two letters initiales")]
        [CSSPDescriptionFR(DescriptionFR = @"Province identifiée par les initiales de deux lettres")]
        public string Province { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Elevation (m)")]
        [CSSPDisplayFR(DisplayFR = "Élévation (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Elevation (m) is the elevation above mean sea level")]
        [CSSPDescriptionFR(DescriptionFR = @"Élévation (m) est l'élévation au dessus du niveau moyen de la mer")]
        public double? Elevation_m { get; set; }
        [StringLength(10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Climate site ID")]
        [CSSPDisplayFR(DisplayFR = "Identifiant du site climatique")]
        [CSSPDescriptionEN(DescriptionEN = @"Climate site ID is a unique ID for the climate site for Environment Canada")]
        [CSSPDescriptionFR(DescriptionFR = @"Identifiant du site climatique est unique pour le site climatique pour Environnemement Canada")]
        public string ClimateID { get; set; }
        [Range(1, 100000)]
        [CSSPDisplayEN(DisplayEN = "WMOID")]
        [CSSPDisplayFR(DisplayFR = "WMOID")]
        [CSSPDescriptionEN(DescriptionEN = @"WMOID is a unique ID for the climate site for World Meteorological Office")]
        [CSSPDescriptionFR(DescriptionFR = @"WMOID est un identifiant unique pour le site climatique pour World Meteorological Office")]
        public int? WMOID { get; set; }
        [StringLength(3)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "TCID")]
        [CSSPDisplayFR(DisplayFR = "TCID")]
        [CSSPDescriptionEN(DescriptionEN = @"TCID is the identifier assigned by Transport Canada to identify meteorological reports from airport observing sites transmitted in real time in aviation formats.")]
        [CSSPDescriptionFR(DescriptionFR = @"TCID est l'identificateur attribué par Transports Canada pour identifier les rapports météorologiques provenant des stations localisées aux aéroports et sont transmis en temps réel dans des formats d'aviation.")]
        public string TCID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Quebec Site")]
        [CSSPDisplayFR(DisplayFR = "Site du Québec")]
        [CSSPDescriptionEN(DescriptionEN = @"Quebec Climate Site")]
        [CSSPDescriptionFR(DescriptionFR = @"Site climatique du Québec")]
        public bool? IsQuebecSite { get; set; }
        [CSSPDisplayEN(DisplayEN = "CoCoRaHS Site")]
        [CSSPDisplayFR(DisplayFR = "Site CoCoRaHS")]
        [CSSPDescriptionEN(DescriptionEN = @"CoCoRaHS Climate Site")]
        [CSSPDescriptionFR(DescriptionFR = @"Site climatique de CoCoRaHS")]
        public bool? IsCoCoRaHS { get; set; }
        [Range(-10.0D, 0.0D)]
        [CSSPDisplayEN(DisplayEN = "Time zone offset (hour)")]
        [CSSPDisplayFR(DisplayFR = "Décalage du fuseau horaire (heure)")]
        [CSSPDescriptionEN(DescriptionEN = @"Time zone offset (hour)")]
        [CSSPDescriptionFR(DescriptionFR = @"Décalage du fuseau horaire (heure)")]
        public double? TimeOffset_hour { get; set; }
        [StringLength(50)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "File description")]
        [CSSPDisplayFR(DisplayFR = "Description de filière")]
        [CSSPDescriptionEN(DescriptionEN = @"File description --- temporary field used while uploading data from Environment Canda weather office web site")]
        [CSSPDescriptionFR(DescriptionFR = @"Description de filière --- champ temporaire utilisé lors du téléchargement des données du site Web du bureau météorologique d'Environnement Canada")]
        public string File_desc { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Hourly start date")]
        [CSSPDisplayFR(DisplayFR = "Date de départ des données horaires")]
        [CSSPDescriptionEN(DescriptionEN = @"Hourly start date will contain null is the climate site does not have hourly data or the starting date of hourly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ des données horaires contiendra null si le site climatique n'a pas de données horaires ou la date de départ des données horaires")]
        public DateTime? HourlyStartDate_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Hourly end date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin des données horaires")]
        [CSSPDescriptionEN(DescriptionEN = @"Hourly end date will contain null is the climate site does not have hourly data or the end date of hourly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin des données horaires contiendra null si le site climatique n'a pas de données horaires ou la date de fin des données horaires")]
        public DateTime? HourlyEndDate_Local { get; set; }
        [CSSPDisplayEN(DisplayEN = "Hourly now")]
        [CSSPDisplayFR(DisplayFR = "Horaire maintenant")]
        [CSSPDescriptionEN(DescriptionEN = @"Hourly now indicates if there are hourly data at this date")]
        [CSSPDescriptionFR(DescriptionFR = @"Horaire maintenant indique s'il y a des données horaires maintenant")]
        public bool? HourlyNow { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Daily start date")]
        [CSSPDisplayFR(DisplayFR = "Date de départ des données journalières")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily start date will contain null is the climate site does not have daily data or the start date of hourly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ des données journalières contiendra null si le site climatique n'a pas de données journalières ou la date de départ des données journalières")]
        public DateTime? DailyStartDate_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Daily end date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin des données journalières")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily end date will contain null is the climate site does not have daily data or the end date of hourly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin des données journalières contiendra null si le site climatique n'a pas de données journalières ou la date de fin des données journalières")]
        public DateTime? DailyEndDate_Local { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily now")]
        [CSSPDisplayFR(DisplayFR = "Jounalier maintenant")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily now indicates if there are daily data at this date")]
        [CSSPDescriptionFR(DescriptionFR = @"Journalier maintenant indique s'il y a des données journalières maintenant")]
        public bool? DailyNow { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Monthly start date")]
        [CSSPDisplayFR(DisplayFR = "Date de départ des données mensuelles")]
        [CSSPDescriptionEN(DescriptionEN = @"Monthly start date will contain null is the climate site does not have monthly data or the start date of monthly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ des données mensuelles contiendra null si le site climatique n'a pas de données mensuelles ou la date de départ des données mensuelles")]
        public DateTime? MonthlyStartDate_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Monthly end date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin des données mensuelles")]
        [CSSPDescriptionEN(DescriptionEN = @"Monthly end date will contain null is the climate site does not have monthly data or the end date of monthly data")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin des données mensuelles contiendra null si le site climatique n'a pas de données mensuelles ou la date de fin des données mensuelles")]
        public DateTime? MonthlyEndDate_Local { get; set; }
        [CSSPDisplayEN(DisplayEN = "Monthly now")]
        [CSSPDisplayFR(DisplayFR = "Mensuel maintenant")]
        [CSSPDescriptionEN(DescriptionEN = @"Monthly now indicates if there are monthly data at this date")]
        [CSSPDescriptionFR(DescriptionFR = @"Mensuel maintenant indique s'il y a des données mensuelles maintenant")]
        public bool? MonthlyNow { get; set; }

        [ForeignKey(nameof(ClimateSiteTVItemID))]
        [InverseProperty(nameof(TVItem.ClimateSites))]
        public virtual TVItem ClimateSiteTVItem { get; set; }
        [InverseProperty("ClimateSite")]
        public virtual ICollection<ClimateDataValue> ClimateDataValues { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ClimateSite() : base()
        {
        }
        #endregion Constructors
    }
}
