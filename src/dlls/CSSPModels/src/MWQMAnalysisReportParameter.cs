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
    public partial class MWQMAnalysisReportParameter : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMAnalysisReportParameter ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMAnalysisReportParameter ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMAnalysisReportParameters table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMAnalysisReportParameters")]
        public int MWQMAnalysisReportParameterID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPDisplayEN(DisplayEN = "Subsector TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Item du sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [StringLength(250, MinimumLength = 5)]
        [CSSPDisplayEN(DisplayEN = "Analysis name")]
        [CSSPDisplayFR(DisplayFR = "Nom de l'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analysis name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de l'analyse")]
        public string AnalysisName { get; set; }
        [Range(1980, 2050)]
        [CSSPDisplayEN(DisplayEN = "Analysis report year")]
        [CSSPDisplayFR(DisplayFR = "Année du raport d'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analysis report year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année du raport d'analyse")]
        public int? AnalysisReportYear { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Start date")]
        [CSSPDisplayFR(DisplayFR = "Date de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Start date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ")]
        public DateTime StartDate { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDate")]
        [CSSPDisplayEN(DisplayEN = "End date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"End date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin")]
        public DateTime EndDate { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Analysis calculation type")]
        [CSSPDisplayFR(DisplayFR = "Type de calcul d'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analysis calculation type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de calcul d'analyse")]
        public AnalysisCalculationTypeEnum AnalysisCalculationType { get; set; }
        [Range(1, 1000)]
        [CSSPDisplayEN(DisplayEN = "Number of run")]
        [CSSPDisplayFR(DisplayFR = "Nombre de tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of run")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tournée")]
        public int NumberOfRuns { get; set; }
        [CSSPDisplayEN(DisplayEN = "Full year")]
        [CSSPDisplayFR(DisplayFR = "Toute l'année")]
        [CSSPDescriptionEN(DescriptionEN = @"Full year")]
        [CSSPDescriptionFR(DescriptionFR = @"Toute l'année")]
        public bool FullYear { get; set; }
        [Range(1.0D, 20.0D)]
        [CSSPDisplayEN(DisplayEN = "Salinity hyghlight deviation from average")]
        [CSSPDisplayFR(DisplayFR = "Écart de salinité hyghlight par rapport à la moyenne")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity hyghlight deviation from average")]
        [CSSPDescriptionFR(DescriptionFR = @"Écart de salinité hyghlight par rapport à la moyenne")]
        public double SalinityHighlightDeviationFromAverage { get; set; }
        [Range(0, 5)]
        [CSSPDisplayEN(DisplayEN = "Short range number of days")]
        [CSSPDisplayFR(DisplayFR = "Portée courte nombre de jours")]
        [CSSPDescriptionEN(DescriptionEN = @"Short range number of days")]
        [CSSPDescriptionFR(DescriptionFR = @"Portée courte nombre de jours")]
        public int ShortRangeNumberOfDays { get; set; }
        [Range(2, 7)]
        [CSSPDisplayEN(DisplayEN = "Mid range number of days")]
        [CSSPDisplayFR(DisplayFR = "Portée moyenne nombre de jours")]
        [CSSPDescriptionEN(DescriptionEN = @"Mid range number of days")]
        [CSSPDescriptionFR(DescriptionFR = @"Portée moyenne nombre de jours")]
        public int MidRangeNumberOfDays { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Dry limit 24h")]
        [CSSPDisplayFR(DisplayFR = "Limit sèche 24h")]
        [CSSPDescriptionEN(DescriptionEN = @"Dry limit 24h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit sèche 24h")]
        public int DryLimit24h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Dry limit 48h")]
        [CSSPDisplayFR(DisplayFR = "Limit sèche 48h")]
        [CSSPDescriptionEN(DescriptionEN = @"Dry limit 48h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit sèche 48h")]
        public int DryLimit48h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Dry limit 72h")]
        [CSSPDisplayFR(DisplayFR = "Limit sèche 72h")]
        [CSSPDescriptionEN(DescriptionEN = @"Dry limit 72h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit sèche 72h")]
        public int DryLimit72h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Dry limit 96h")]
        [CSSPDisplayFR(DisplayFR = "Limit sèche 96h")]
        [CSSPDescriptionEN(DescriptionEN = @"Dry limit 96h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit sèche 96h")]
        public int DryLimit96h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Wet limit 24h")]
        [CSSPDisplayFR(DisplayFR = "Limit pluie 24h")]
        [CSSPDescriptionEN(DescriptionEN = @"Wet limit 24h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit pluie 24h")]
        public int WetLimit24h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Wet limit 48h")]
        [CSSPDisplayFR(DisplayFR = "Limit pluie 48h")]
        [CSSPDescriptionEN(DescriptionEN = @"Wet limit 48h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit pluie 48h")]
        public int WetLimit48h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Wet limit 72h")]
        [CSSPDisplayFR(DisplayFR = "Limit pluie 72h")]
        [CSSPDescriptionEN(DescriptionEN = @"Wet limit 72h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit pluie 72h")]
        public int WetLimit72h { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Wet limit 96h")]
        [CSSPDisplayFR(DisplayFR = "Limit pluie 96h")]
        [CSSPDescriptionEN(DescriptionEN = @"Wet limit 96h")]
        [CSSPDescriptionFR(DescriptionFR = @"Limit pluie 96h")]
        public int WetLimit96h { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "Runs to omit")]
        [CSSPDisplayFR(DisplayFR = "Tournée à omettre")]
        [CSSPDescriptionEN(DescriptionEN = @"Runs to omit")]
        [CSSPDescriptionFR(DescriptionFR = @"Tournée à omettre")]
        public string RunsToOmit { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Show data type")]
        [CSSPDisplayFR(DisplayFR = "Type de donnée à montrer")]
        [CSSPDescriptionEN(DescriptionEN = @"Show data type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de donnée à montrer")]
        public string ShowDataTypes { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        [CSSPDisplayEN(DisplayEN = "Excel doc TVFile TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Item TVFile pour document Excel")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing Excel file")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant un document Excel")]
        public int? ExcelTVFileTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Analysis report export command")]
        [CSSPDisplayFR(DisplayFR = "Commande d'exportation du raport d'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analysis report export command")]
        [CSSPDescriptionFR(DescriptionFR = @"Commande d'exportation du raport d'analyse")]
        public AnalysisReportExportCommandEnum Command { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMAnalysisReportParameter() : base()
        {
        }
        #endregion Constructors
    }
}
