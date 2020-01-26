/*
 * Manually edited
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
    public partial class LabSheetDetail : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "LabSheetDetail ID")]
        [CSSPDisplayFR(DisplayFR = "LabSheetDetail ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the LabSheetDetails table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table LabSheetDetails")]
        public int LabSheetDetailID { get; set; }
        [CSSPExist(ExistTypeName = "LabSheet", ExistPlurial = "s", ExistFieldID = "LabSheetID")]
        [CSSPDisplayEN(DisplayEN = "Lab sheet")]
        [CSSPDisplayFR(DisplayFR = "Feuille de laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the LabSheets table representing the lab sheet")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table LabSheets représentant la feuille de laboratoire")]
        public int LabSheetID { get; set; }
        [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
        [CSSPDisplayEN(DisplayEN = "Sampling plan")]
        [CSSPDisplayFR(DisplayFR = "Plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the SamplingPlan table representing the sampling plan")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table SamplingPlan représentant la plan d'échantillonnage")]
        public int SamplingPlanID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
        [CSSPDisplayEN(DisplayEN = "Subsector TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItem table representing the subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItem représentant la sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [Range(1, 5)]
        [CSSPDisplayEN(DisplayEN = "Version")]
        [CSSPDisplayFR(DisplayFR = "Version")]
        [CSSPDescriptionEN(DescriptionEN = @"Version of the document (lab sheet)")]
        [CSSPDescriptionFR(DescriptionFR = @"Version du document (feuille de laboratoire)")]
        public int Version { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Run date")]
        [CSSPDisplayFR(DisplayFR = "Date de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de la tournée")]
        public DateTime RunDate { get; set; }
        [StringLength(7, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Tide sites ID")]
        [CSSPDisplayFR(DisplayFR = "ID des site de marées")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide sites ID")]
        [CSSPDescriptionFR(DescriptionFR = @"ID des site de marées")]
        public string Tides { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample crew initials")]
        [CSSPDisplayFR(DisplayFR = "Initiales des contacts faisant l'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample crew initials")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiales des contacts faisant l'échantillonnage")]
        public string SampleCrewInitials { get; set; }
        [Range(1, 3)]
        [CSSPDisplayEN(DisplayEN = "Water bath count")]
        [CSSPDisplayFR(DisplayFR = "Nombre de bain d'eau")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de bain d'eau")]
        public int? WaterBathCount { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 1")]
        public DateTime? IncubationBath1StartTime { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 2")]
        public DateTime? IncubationBath2StartTime { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 3")]
        public DateTime? IncubationBath3StartTime { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 1")]
        public DateTime? IncubationBath1EndTime { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 2")]
        public DateTime? IncubationBath2EndTime { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 3")]
        public DateTime? IncubationBath3EndTime { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 1 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 1 en minutes")]
        public int? IncubationBath1TimeCalculated_minutes { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 2 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 2 en minutes")]
        public int? IncubationBath2TimeCalculated_minutes { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 3 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 3 en minutes")]
        public int? IncubationBath3TimeCalculated_minutes { get; set; }
        [StringLength(10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Water bath 1")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 1")]
        public string WaterBath1 { get; set; }
        [StringLength(10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Water bath 2")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 2")]
        public string WaterBath2 { get; set; }
        [StringLength(10)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Water bath 3")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 3")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 3")]
        public string WaterBath3 { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control 1")]
        [CSSPDisplayFR(DisplayFR = "Température de control 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 1")]
        public double? TCField1 { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control lab 1")]
        [CSSPDisplayFR(DisplayFR = "Température de control au laboratoire 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control lab 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control au laboratoire 1")]
        public double? TCLab1 { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control 2")]
        [CSSPDisplayFR(DisplayFR = "Température de control 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 2")]
        public double? TCField2 { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Temperature control lab 2")]
        [CSSPDisplayFR(DisplayFR = "Température de control au laboratoire 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control lab 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control au laboratoire 2")]
        public double? TCLab2 { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "First temperature control")]
        [CSSPDisplayFR(DisplayFR = "Première température de control")]
        [CSSPDescriptionEN(DescriptionEN = @"First temperature control")]
        [CSSPDescriptionFR(DescriptionFR = @"Première température de control")]
        public double? TCFirst { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Average temperature control")]
        [CSSPDisplayFR(DisplayFR = "Moyenne de température de control")]
        [CSSPDescriptionEN(DescriptionEN = @"Average temperature control")]
        [CSSPDescriptionFR(DescriptionFR = @"Moyenne de température de control")]
        public double? TCAverage { get; set; }
        [StringLength(100)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Control lot")]
        [CSSPDisplayFR(DisplayFR = "Lot de contrôle")]
        [CSSPDescriptionEN(DescriptionEN = @"Control lot")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot de contrôle")]
        public string ControlLot { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Positive 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Positive 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Positive 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Positive 35 (°C)")]
        public string Positive35 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Non target 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Non target 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Non target 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Non target 35 (°C)")]
        public string NonTarget35 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Negative 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Negative 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Negative 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Negative 35 (°C)")]
        public string Negative35 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 1 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 positive 44.5 (°C)")]
        public string Bath1Positive44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 2 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 positive 44.5 (°C)")]
        public string Bath2Positive44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 3 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 positive 44.5 (°C)")]
        public string Bath3Positive44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 1 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 non target 44.5 (°C)")]
        public string Bath1NonTarget44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 2 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 non target 44.5 (°C)")]
        public string Bath2NonTarget44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 3 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 non target 44.5 (°C)")]
        public string Bath3NonTarget44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 1 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 negative 44.5 (°C)")]
        public string Bath1Negative44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 2 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 negative 44.5 (°C)")]
        public string Bath2Negative44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 3 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 negative 44.5 (°C)")]
        public string Bath3Negative44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Blank 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Blank 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Blank 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Blank 35 (°C)")]
        public string Blank35 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 1 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 blank 44.5 (°C)")]
        public string Bath1Blank44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 2 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 blank 44.5 (°C)")]
        public string Bath2Blank44_5 { get; set; }
        [StringLength(1, MinimumLength = 1)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Bath 3 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 blank 44.5 (°C)")]
        public string Bath3Blank44_5 { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Lot 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Lot 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Lot 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot 35 (°C)")]
        public string Lot35 { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Lot 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Lot 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Lot 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot 44.5 (°C)")]
        public string Lot44_5 { get; set; }
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Weather")]
        [CSSPDisplayFR(DisplayFR = "Météo")]
        [CSSPDescriptionEN(DescriptionEN = @"Weather")]
        [CSSPDescriptionFR(DescriptionFR = @"Météo")]
        public string Weather { get; set; }
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Run comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de tourée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de tourée")]
        public string RunComment { get; set; }
        [StringLength(250)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Run weather comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de tourée météo")]
        [CSSPDescriptionEN(DescriptionEN = @"Run weather comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de tourée météo")]
        public string RunWeatherComment { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample bottle lot number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de lot des bouteille d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample bottle lot number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de lot des bouteille d'échantillonnage")]
        public string SampleBottleLotNumber { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Salinity read by")]
        [CSSPDisplayFR(DisplayFR = "Salinité lu par")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read by")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité lu par")]
        public string SalinitiesReadBy { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Salinity read date")]
        [CSSPDisplayFR(DisplayFR = "Date de lecture de salinité")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de lecture de salinité")]
        public DateTime? SalinitiesReadDate { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Results read by")]
        [CSSPDisplayFR(DisplayFR = "Résultats lu par")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read by")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats lu par")]
        public string ResultsReadBy { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Results read date")]
        [CSSPDisplayFR(DisplayFR = "Date de lecture des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de lecture des résultats")]
        public DateTime? ResultsReadDate { get; set; }
        [StringLength(20)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Results recorded by")]
        [CSSPDisplayFR(DisplayFR = "Résultats enregistrés par")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded by")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats enregistrés par")]
        public string ResultsRecordedBy { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Results recorded date")]
        [CSSPDisplayFR(DisplayFR = "Date d'enregistrement des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de d'enregistrement des résultats")]
        public DateTime? ResultsRecordedDate { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Daily duplicate R log")]
        [CSSPDisplayFR(DisplayFR = "R Log du duplicata du la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate R log")]
        [CSSPDescriptionFR(DescriptionFR = @"R Log du duplicata du la tournée")]
        public double? DailyDuplicateRLog { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Daily duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata du la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata du la tournée")]
        public double? DailyDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate is acceptable")]
        [CSSPDisplayFR(DisplayFR = "Duplicata du la tournée est acceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate is acceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Duplicata du la tournée est acceptable")]
        public bool? DailyDuplicateAcceptable { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate R log")]
        [CSSPDisplayFR(DisplayFR = "R Log du duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate R log")]
        [CSSPDescriptionFR(DescriptionFR = @"R Log du duplicata intertech")]
        public double? IntertechDuplicateRLog { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata intertech")]
        public double? IntertechDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate is acceptable")]
        [CSSPDisplayFR(DisplayFR = "Duplicata intertech est acceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate is acceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Duplicata intertech est acceptable")]
        public bool? IntertechDuplicateAcceptable { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech read is acceptable")]
        [CSSPDisplayFR(DisplayFR = "Lecture intertech est acceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech read is acceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Lecture intertech est acceptable")]
        public bool? IntertechReadAcceptable { get; set; }
        #endregion Properties in DB

        #region Constructors
        public LabSheetDetail() : base()
        {
        }
        #endregion Constructors
    }
}
