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
    public partial class MWQMRun : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MWQMRun ID")]
        [CSSPDisplayFR(DisplayFR = "MWQMRun ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MWQMRuns table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MWQMRuns")]
        public int MWQMRunID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPDisplayEN(DisplayEN = "Subsector TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
        [CSSPDisplayEN(DisplayEN = "MWQM run TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Tournée MWQM TVItemID (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MWQM run")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la tournée MWQM (fr)")]
        public int MWQMRunTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sample type")]
        [CSSPDisplayFR(DisplayFR = "Type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'échantillon")]
        public SampleTypeEnum RunSampleType { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date (local)")]
        public DateTime DateTime_Local { get; set; }
        [Range(1, 1000)]
        [CSSPDisplayEN(DisplayEN = "Run number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de la tournée")]
        public int RunNumber { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Start date")]
        [CSSPDisplayFR(DisplayFR = "Date du début")]
        [CSSPDescriptionEN(DescriptionEN = @"Start date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date du début")]
        public DateTime? StartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDateTime_Local")]
        [CSSPDisplayEN(DisplayEN = "End date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"End date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin")]
        public DateTime? EndDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lab received date")]
        [CSSPDisplayFR(DisplayFR = "Date reçu au laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab received date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date reçu au laboratoire")]
        public DateTime? LabReceivedDateTime_Local { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control 1 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température de control 1 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 1 in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 1 en dégré Celcius")]
        public double? TemperatureControl1_C { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control 2 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température de control 2 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 2 in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 2 en dégré Celcius")]
        public double? TemperatureControl2_C { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sea state at start (Beaufort scale)")]
        [CSSPDisplayFR(DisplayFR = "État de la mer au début (Échelle Beaufort)")]
        [CSSPDescriptionEN(DescriptionEN = @"Sea state at start (Beaufort scale)")]
        [CSSPDescriptionFR(DescriptionFR = @"État de la mer au début (Échelle Beaufort)")]
        public BeaufortScaleEnum? SeaStateAtStart_BeaufortScale { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sea state at end (Beaufort scale)")]
        [CSSPDisplayFR(DisplayFR = "État de la mer à la fin (Échelle Beaufort)")]
        [CSSPDescriptionEN(DescriptionEN = @"Sea state at end (Beaufort scale)")]
        [CSSPDescriptionFR(DescriptionFR = @"État de la mer à la fin (Échelle Beaufort)")]
        public BeaufortScaleEnum? SeaStateAtEnd_BeaufortScale { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Water level at brook (m)")]
        [CSSPDisplayFR(DisplayFR = "Niveau d'eau au ruisseau (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Water level at brook in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Niveau d'eau au ruisseau en mètres")]
        public double? WaterLevelAtBrook_m { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Wave height at start (m)")]
        [CSSPDisplayFR(DisplayFR = "Hauteur des vagues au début (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Water height at start in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Hauteur des vagues au début en mètres")]
        public double? WaveHightAtStart_m { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Wave height at end (m)")]
        [CSSPDisplayFR(DisplayFR = "Hauteur des vagues à la fin (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Water height at end in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Hauteur des vagues à la fin en mètres")]
        public double? WaveHightAtEnd_m { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample crew initials")]
        [CSSPDisplayFR(DisplayFR = "Initiales de l'équipe de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample crew initials")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiales de l'équipe de la tournée")]
        public string SampleCrewInitials { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Analyze method")]
        [CSSPDisplayFR(DisplayFR = "Méthode d'analyse")]
        [CSSPDescriptionEN(DescriptionEN = @"Analyze method")]
        [CSSPDescriptionFR(DescriptionFR = @"Méthode d'analyse")]
        public AnalyzeMethodEnum? AnalyzeMethod { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample matrix")]
        [CSSPDisplayFR(DisplayFR = "Milieu de l'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample matrix")]
        [CSSPDescriptionFR(DescriptionFR = @"Milieu de l'échantillon")]
        public SampleMatrixEnum? SampleMatrix { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Laboratory")]
        [CSSPDisplayFR(DisplayFR = "Laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory")]
        [CSSPDescriptionFR(DescriptionFR = @"Laboratoire")]
        public LaboratoryEnum? Laboratory { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample status")]
        [CSSPDisplayFR(DisplayFR = "État de l'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample status")]
        [CSSPDescriptionFR(DescriptionFR = @"État de l'échantillon")]
        public SampleStatusEnum? SampleStatus { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Lab sample approval contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Échantillon reçu au lab apprové par contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory sample approval contact TVItemID")]
        [CSSPDescriptionFR(DescriptionFR = @"Échantillon reçu au laboratoire apprové par contact TVItemID")]
        public int? LabSampleApprovalContactTVItemID { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lab analyze bath 1 incubation start date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de début du bain d'incubation 1 du lab (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory analyze bath 1 incubation start date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de début du bain d'incubation 1 du laboratoire (local)")]
        public DateTime? LabAnalyzeBath1IncubationStartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lab analyze bath 2 incubation start date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de début du bain d'incubation 2 du lab (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory analyze bath 2 incubation start date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de début du bain d'incubation 2 du laboratoire (local)")]
        public DateTime? LabAnalyzeBath2IncubationStartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lab analyze bath 3 incubation start date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de début du bain d'incubation 3 du lab (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory analyze bath 3 incubation start date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de début du bain d'incubation 3 du laboratoire (local)")]
        public DateTime? LabAnalyzeBath3IncubationStartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lab run sample approval date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date d'approbation de l'échantillon de la tournée reçu au lab (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab run sample approval date (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'approbation de l'échantillon de la tournée reçu au lab (local)")]
        public DateTime? LabRunSampleApprovalDateTime_Local { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tide start")]
        [CSSPDisplayFR(DisplayFR = "Marée de début")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide start")]
        [CSSPDescriptionFR(DescriptionFR = @"Marée de début")]
        public TideTextEnum? Tide_Start { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Tide end")]
        [CSSPDisplayFR(DisplayFR = "Marée de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide end")]
        [CSSPDescriptionFR(DescriptionFR = @"Marée de find")]
        public TideTextEnum? Tide_End { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 0 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 0 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 0 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 0 en millimètres")]
        public double? RainDay0_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 1 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 1 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 1 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 1 en millimètres")]
        public double? RainDay1_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 2 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 2 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 2 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 2 en millimètres")]
        public double? RainDay2_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 3 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 3 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 3 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 3 en millimètres")]
        public double? RainDay3_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 4 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 4 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 4 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 4 en millimètres")]
        public double? RainDay4_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 5 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 5 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 5 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 5 en millimètres")]
        public double? RainDay5_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 6 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 6 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 6 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 6 en millimètres")]
        public double? RainDay6_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 7 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 7 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 7 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 7 en millimètres")]
        public double? RainDay7_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 8 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 8 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 8 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 8 en millimètres")]
        public double? RainDay8_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 9 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 9 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 9 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 9 en millimètres")]
        public double? RainDay9_mm { get; set; }
        [Range(0.0D, 300.0D)]
        [CSSPDisplayEN(DisplayEN = "Rain day 10 (mm)")]
        [CSSPDisplayFR(DisplayFR = "Pluie jour 10 (mm)")]
        [CSSPDescriptionEN(DescriptionEN = @"Rain day 10 in millimeters")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie jour 10 en millimètres")]
        public double? RainDay10_mm { get; set; }
        [CSSPDisplayEN(DisplayEN = "Remove from statistics")]
        [CSSPDisplayFR(DisplayFR = "Enlever des statistiques")]
        [CSSPDescriptionEN(DescriptionEN = @"Remove from statistics")]
        [CSSPDescriptionFR(DescriptionFR = @"Enlever des statistiques")]
        public bool? RemoveFromStat { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MWQMRun() : base()
        {
        }
        #endregion Constructors
    }
}
