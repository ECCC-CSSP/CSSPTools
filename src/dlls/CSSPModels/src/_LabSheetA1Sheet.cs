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
    [NotMapped]
    public partial class LabSheetA1Sheet : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Version")]
        [CSSPDisplayFR(DisplayFR = "Version")]
        [CSSPDescriptionEN(DescriptionEN = @"Version of the document (lab sheet)")]
        [CSSPDescriptionFR(DescriptionFR = @"Version du document (feuille de laboratoire)")]
        public int Version { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sampling plan type")]
        [CSSPDisplayFR(DisplayFR = "Type de plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sampling plan type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de plan d'échantillonnage")]
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sample type")]
        [CSSPDisplayFR(DisplayFR = "Type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'échantillon")]
        public SampleTypeEnum SampleType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Lab sheet type")]
        [CSSPDisplayFR(DisplayFR = "Type de feuille de lab")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de feuille de laboratoire")]
        public LabSheetTypeEnum LabSheetType { get; set; }
        [CSSPDisplayEN(DisplayEN = "Subsector name")]
        [CSSPDisplayFR(DisplayFR = "Nom du sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Subsector name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du sous-secteur")]
        public string SubsectorName { get; set; }
        [CSSPDisplayEN(DisplayEN = "Subsector location")]
        [CSSPDisplayFR(DisplayFR = "Emplacement du sous-secteur")]
        [CSSPDescriptionEN(DescriptionEN = @"Subsector location")]
        [CSSPDescriptionFR(DescriptionFR = @"Emplacement du sous-secteur")]
        public string SubsectorLocation { get; set; }
        [CSSPDisplayEN(DisplayEN = "Subsector TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Sous-secteur TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItem table representing the subsector")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItem représentant la sous-secteur")]
        public int SubsectorTVItemID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run year")]
        [CSSPDisplayFR(DisplayFR = "Année de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année de la tournée")]
        public string RunYear { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run month")]
        [CSSPDisplayFR(DisplayFR = "Mois de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de la tournée")]
        public string RunMonth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run day")]
        [CSSPDisplayFR(DisplayFR = "Jour de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de la tournée")]
        public string RunDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de la tournée")]
        public int RunNumber { get; set; }
        [CSSPDisplayEN(DisplayEN = "Tide sites ID")]
        [CSSPDisplayFR(DisplayFR = "ID des site de marées")]
        [CSSPDescriptionEN(DescriptionEN = @"Tide sites ID")]
        [CSSPDescriptionFR(DescriptionFR = @"ID des site de marées")]
        public string Tides { get; set; }
        [CSSPDisplayEN(DisplayEN = "Sample crew initials")]
        [CSSPDisplayFR(DisplayFR = "Initiales des contacts faisant l'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample crew initials")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiales des contacts faisant l'échantillonnage")]
        public string SampleCrewInitials { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation starts on the same day")]
        [CSSPDisplayFR(DisplayFR = "Incubation commence le même jour")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation starts on the same day")]
        [CSSPDescriptionFR(DescriptionFR = @"Incubation commence le même jour")]
        public string IncubationStartSameDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Water bath count")]
        [CSSPDisplayFR(DisplayFR = "Nombre de bain d'eau")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de bain d'eau")]
        public int WaterBathCount { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 1")]
        public string IncubationBath1StartTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 2")]
        public string IncubationBath2StartTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 start time")]
        [CSSPDisplayFR(DisplayFR = "Temps de départ bain d'incubation 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 start time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de départ bain d'incubation 3")]
        public string IncubationBath3StartTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 1")]
        public string IncubationBath1EndTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 2")]
        public string IncubationBath2EndTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 end time")]
        [CSSPDisplayFR(DisplayFR = "Temps de fin bain d'incubation 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 end time")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de fin bain d'incubation 3")]
        public string IncubationBath3EndTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 1 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 1 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 1 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 1 en minutes")]
        public string IncubationBath1TimeCalculated { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 2 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 2 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 2 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 2 en minutes")]
        public string IncubationBath2TimeCalculated { get; set; }
        [CSSPDisplayEN(DisplayEN = "Incubation bath 3 time calculated (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps calculé de bain d'incubation 3 (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Incubation bath 3 time calculated (min)")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps calculé de bain d'incubation 3 en minutes")]
        public string IncubationBath3TimeCalculated { get; set; }
        [CSSPDisplayEN(DisplayEN = "Water bath 1")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 1")]
        public string WaterBath1 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Water bath 2")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 2")]
        public string WaterBath2 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Water bath 3")]
        [CSSPDisplayFR(DisplayFR = "Bain d'eau 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Water bath 3")]
        [CSSPDescriptionFR(DescriptionFR = @"Bain d'eau 3")]
        public string WaterBath3 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Temperature control 1")]
        [CSSPDisplayFR(DisplayFR = "Température de control 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 1")]
        public string TCField1 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Temperature control lab 1")]
        [CSSPDisplayFR(DisplayFR = "Température de control au laboratoire 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control lab 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control au laboratoire 1")]
        public string TCLab1 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Has 2 coolers")]
        [CSSPDisplayFR(DisplayFR = "Il y a 2 glacières")]
        [CSSPDescriptionEN(DescriptionEN = @"Has 2 coolers")]
        [CSSPDescriptionFR(DescriptionFR = @"Il y a 2 glacières")]
        public string TCHas2Coolers { get; set; }
        [CSSPDisplayEN(DisplayEN = "Temperature control 2")]
        [CSSPDisplayFR(DisplayFR = "Température de control 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control 2")]
        public string TCField2 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Temperature control lab 2")]
        [CSSPDisplayFR(DisplayFR = "Température de control au laboratoire 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Temperature control lab 2")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de control au laboratoire 2")]
        public string TCLab2 { get; set; }
        [CSSPDisplayEN(DisplayEN = "First temperature control")]
        [CSSPDisplayFR(DisplayFR = "Première température de control")]
        [CSSPDescriptionEN(DescriptionEN = @"First temperature control")]
        [CSSPDescriptionFR(DescriptionFR = @"Première température de control")]
        public string TCFirst { get; set; }
        [CSSPDisplayEN(DisplayEN = "Average temperature control")]
        [CSSPDisplayFR(DisplayFR = "Moyenne de température de control")]
        [CSSPDescriptionEN(DescriptionEN = @"Average temperature control")]
        [CSSPDescriptionFR(DescriptionFR = @"Moyenne de température de control")]
        public string TCAverage { get; set; }
        [CSSPDisplayEN(DisplayEN = "Control lot")]
        [CSSPDisplayFR(DisplayFR = "Lot de contrôle")]
        [CSSPDescriptionEN(DescriptionEN = @"Control lot")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot de contrôle")]
        public string ControlLot { get; set; }
        [CSSPDisplayEN(DisplayEN = "Positive 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Positive 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Positive 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Positive 35 (°C)")]
        public string Positive35 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Non target 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Non target 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Non target 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Non target 35 (°C)")]
        public string NonTarget35 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Negative 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Negative 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Negative 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Negative 35 (°C)")]
        public string Negative35 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 1 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 positive 44.5 (°C)")]
        public string Bath1Positive44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 2 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 positive 44.5 (°C)")]
        public string Bath2Positive44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 3 positive 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 positive 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 positive 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 positive 44.5 (°C)")]
        public string Bath3Positive44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 1 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 non target 44.5 (°C)")]
        public string Bath1NonTarget44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 2 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 non target 44.5 (°C)")]
        public string Bath2NonTarget44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 3 non target 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 non target 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 non target 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 non target 44.5 (°C)")]
        public string Bath3NonTarget44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 1 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 negative 44.5 (°C)")]
        public string Bath1Negative44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 2 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 negative 44.5 (°C)")]
        public string Bath2Negative44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 3 negative 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 negative 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 negative 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 negative 44.5 (°C)")]
        public string Bath3Negative44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Blank 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Blank 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Blank 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Blank 35 (°C)")]
        public string Blank35 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 1 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 1 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 1 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 1 blank 44.5 (°C)")]
        public string Bath1Blank44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 2 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 2 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 2 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 2 blank 44.5 (°C)")]
        public string Bath2Blank44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Bath 3 blank 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Bath 3 blank 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Bath 3 blank 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Bath 3 blank 44.5 (°C)")]
        public string Bath3Blank44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lot 35 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Lot 35 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Lot 35 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot 35 (°C)")]
        public string Lot35 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lot 44.5 (°C)")]
        [CSSPDisplayFR(DisplayFR = "Lot 44.5 (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Lot 44.5 (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Lot 44.5 (°C)")]
        public string Lot44_5 { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de tourée")]
        [CSSPDescriptionEN(DescriptionEN = @"Run comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de tourée")]
        public string RunComment { get; set; }
        [CSSPDisplayEN(DisplayEN = "Run weather comment")]
        [CSSPDisplayFR(DisplayFR = "Commentaire de tourée météo")]
        [CSSPDescriptionEN(DescriptionEN = @"Run weather comment")]
        [CSSPDescriptionFR(DescriptionFR = @"Commentaire de tourée météo")]
        public string RunWeatherComment { get; set; }
        [CSSPDisplayEN(DisplayEN = "Sample bottle lot number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de lot des bouteille d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample bottle lot number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de lot des bouteille d'échantillonnage")]
        public string SampleBottleLotNumber { get; set; }
        [CSSPDisplayEN(DisplayEN = "Salinity read by")]
        [CSSPDisplayFR(DisplayFR = "Salinité lu par")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read by")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité lu par")]
        public string SalinitiesReadBy { get; set; }
        [CSSPDisplayEN(DisplayEN = "Salinity read year")]
        [CSSPDisplayFR(DisplayFR = "Année de lecture de salinité")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année de lecture de salinité")]
        public string SalinitiesReadYear { get; set; }
        [CSSPDisplayEN(DisplayEN = "Salinity read month")]
        [CSSPDisplayFR(DisplayFR = "Mois de lecture de salinité")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de lecture de salinité")]
        public string SalinitiesReadMonth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Salinity read day")]
        [CSSPDisplayFR(DisplayFR = "Jour de lecture de salinité")]
        [CSSPDescriptionEN(DescriptionEN = @"Salinity read day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de lecture de salinité")]
        public string SalinitiesReadDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results read by")]
        [CSSPDisplayFR(DisplayFR = "Résultats lu par")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read by")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats lu par")]
        public string ResultsReadBy { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results read year")]
        [CSSPDisplayFR(DisplayFR = "Année de lecture des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année de lecture des résultats")]
        public string ResultsReadYear { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results read month")]
        [CSSPDisplayFR(DisplayFR = "Mois de lecture des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de lecture des résultats")]
        public string ResultsReadMonth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results read day")]
        [CSSPDisplayFR(DisplayFR = "Jour de lecture des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results read day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de lecture des résultats")]
        public string ResultsReadDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results recorded by")]
        [CSSPDisplayFR(DisplayFR = "Résultats enregistrés par")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded by")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats enregistrés par")]
        public string ResultsRecordedBy { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results recorded year")]
        [CSSPDisplayFR(DisplayFR = "Année d'enregistrement des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année de d'enregistrement des résultats")]
        public string ResultsRecordedYear { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results recorded month")]
        [CSSPDisplayFR(DisplayFR = "Mois d'enregistrement des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois de d'enregistrement des résultats")]
        public string ResultsRecordedMonth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Results recorded day")]
        [CSSPDisplayFR(DisplayFR = "Jour d'enregistrement des résultats")]
        [CSSPDescriptionEN(DescriptionEN = @"Results recorded day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour de d'enregistrement des résultats")]
        public string ResultsRecordedDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate R log")]
        [CSSPDisplayFR(DisplayFR = "R Log du duplicata du la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate R log")]
        [CSSPDescriptionFR(DescriptionFR = @"R Log du duplicata du la tournée")]
        public string DailyDuplicateRLog { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata du la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata du la tournée")]
        public string DailyDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Daily duplicate is acceptable or unacceptable")]
        [CSSPDisplayFR(DisplayFR = "Duplicata du la tournée est acceptable ou inacceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate is acceptable or unacceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Duplicata du la tournée est acceptable ou inacceptable")]
        public string DailyDuplicateAcceptableOrUnacceptable { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate R log")]
        [CSSPDisplayFR(DisplayFR = "R Log du duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate R log")]
        [CSSPDescriptionFR(DescriptionFR = @"R Log du duplicata intertech")]
        public string IntertechDuplicateRLog { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata intertech")]
        public string IntertechDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate is acceptable or unacceptable")]
        [CSSPDisplayFR(DisplayFR = "Duplicata intertech est acceptable ou inacceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate is acceptable or unacceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Duplicata intertech est acceptable ou inacceptable")]
        public string IntertechDuplicateAcceptableOrUnacceptable { get; set; }
        [CSSPDisplayEN(DisplayEN = "Intertech read is acceptable or unacceptable")]
        [CSSPDisplayFR(DisplayFR = "Lecture intertech est acceptable ou inacceptable")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech read is acceptable or unacceptable")]
        [CSSPDescriptionFR(DescriptionFR = @"Lecture intertech est acceptable ou inacceptable")]
        public string IntertechReadAcceptableOrUnacceptable { get; set; }
        [CSSPDisplayEN(DisplayEN = "Approval year")]
        [CSSPDisplayFR(DisplayFR = "Année d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année d'approbation")]
        public string ApprovalYear { get; set; }
        [CSSPDisplayEN(DisplayEN = "Approval month")]
        [CSSPDisplayFR(DisplayFR = "Mois d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval month")]
        [CSSPDescriptionFR(DescriptionFR = @"Mois d'approbation")]
        public string ApprovalMonth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Approval day")]
        [CSSPDisplayFR(DisplayFR = "Jour d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval day")]
        [CSSPDescriptionFR(DescriptionFR = @"Jour d'approbation")]
        public string ApprovalDay { get; set; }
        [CSSPDisplayEN(DisplayEN = "Approved by supervisor initials")]
        [CSSPDisplayFR(DisplayFR = "Initials du superviseur qui a apprové")]
        [CSSPDescriptionEN(DescriptionEN = @"Approved by supervisor initials")]
        [CSSPDescriptionFR(DescriptionFR = @"Initials du superviseur qui a apprové")]
        public string ApprovedBySupervisorInitials { get; set; }
        [CSSPDisplayEN(DisplayEN = "Include laboratory QA/QC")]
        [CSSPDisplayFR(DisplayFR = "Inclure l'assurance de qualité / contrôle de qualité du laboratoire")]
        [CSSPDescriptionEN(DescriptionEN = @"Include laboratory quality assurance / quality control")]
        [CSSPDescriptionFR(DescriptionFR = @"Inclure l'assurance de qualité / contrôle de qualité du laboratoire")]
        public bool IncludeLaboratoryQAQC { get; set; }
        [CSSPDisplayEN(DisplayEN = "Backup directory")]
        [CSSPDisplayFR(DisplayFR = "Répertoire de sauvegarde")]
        [CSSPDescriptionEN(DescriptionEN = @"Backup directory")]
        [CSSPDescriptionFR(DescriptionFR = @"Répertoire de sauvegarde")]
        public string BackupDirectory { get; set; }
        [CSSPDisplayEN(DisplayEN = "Log")]
        [CSSPDisplayFR(DisplayFR = "Log")]
        [CSSPDescriptionEN(DescriptionEN = @"Log")]
        [CSSPDescriptionFR(DescriptionFR = @"Log")]
        public string Log { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SamplingPlanTypeEnum", EnumType = "SamplingPlanType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sampling plan type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type de plan d'échantillonnage")]
        [CSSPDescriptionEN(DescriptionEN = @"Sampling plan type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type de plan d'échantillonnage")]
        public string SamplingPlanTypeText { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SampleTypeEnum", EnumType = "SampleType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sample type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'échantillon")]
        [CSSPDescriptionEN(DescriptionEN = @"Sample type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'échantillon")]
        public string SampleTypeText { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "LabSheetTypeEnum", EnumType = "LabSheetType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Lab sheet type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type de feuille de lab")]
        [CSSPDescriptionEN(DescriptionEN = @"Laboratory sheet type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type de feuille de laboratoire")]
        public string LabSheetTypeText { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lab sheet A1 measurement list")]
        [CSSPDisplayFR(DisplayFR = "Liste de measure de la feuille de laboratoire A1")]
        [CSSPDescriptionEN(DescriptionEN = @"Lab sheet A1 measurement list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste de measure de la feuille de laboratoire A1")]
        public List<LabSheetA1Measurement> LabSheetA1MeasurementList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetA1Sheet() : base()
        {
            LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();
        }
        #endregion Constructors
    }
}
