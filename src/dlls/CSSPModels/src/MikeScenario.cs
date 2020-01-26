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
    public partial class MikeScenario : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "MikeScenario ID")]
        [CSSPDisplayFR(DisplayFR = "MikeScenario ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the MikeScenarios table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table MikeScenarios")]
        public int MikeScenarioID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "13")]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Item du scenario MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MIKE scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le scénario MIKE")]
        public int MikeScenarioTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "13")]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario parent ID")]
        [CSSPDisplayFR(DisplayFR = "Item parent du scenario MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the MikeScenarios table representing MIKE scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table MIkeScenarios représentant le scénario MIKE")]
        public int? ParentMikeScenarioID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario status")]
        [CSSPDisplayFR(DisplayFR = "État du scenario MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario status")]
        [CSSPDescriptionFR(DescriptionFR = @"État du scenario MIKE")]
        public ScenarioStatusEnum ScenarioStatus { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario error info")]
        [CSSPDisplayFR(DisplayFR = "Info de l'erreur du scenario MIKE")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario error information")]
        [CSSPDescriptionFR(DescriptionFR = @"Information de l'erreur du scenario MIKE")]
        public string ErrorInfo { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario start date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de départ du scenario MIKE (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario start date in local time")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ du scenario MIKE en temps local")]
        public DateTime MikeScenarioStartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario end date (local)")]
        [CSSPDisplayFR(DisplayFR = "Date de fin du scenario MIKE (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario end date in local time")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin du scenario MIKE en temps local")]
        public DateTime MikeScenarioEndDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario start excecution time (local)")]
        [CSSPDisplayFR(DisplayFR = "Début du temps d'exécution du scenario MIKE (local)")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario start excecution time (local)")]
        [CSSPDescriptionFR(DescriptionFR = @"Début du temps d'exécution du scenario MIKE (local)")]
        public DateTime? MikeScenarioStartExecutionDateTime_Local { get; set; }
        [Range(1.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "MIKE scenario excecution time (min)")]
        [CSSPDisplayFR(DisplayFR = "Temps d'exécution du scenario MIKE (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"MIKE scenario excecution time in minutes")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps d'exécution du scenario MIKE en minutes")]
        public double? MikeScenarioExecutionTime_min { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Wind speed (km/h)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse du vent (km/h)")]
        [CSSPDescriptionEN(DescriptionEN = @"Wind speed in kilometers per hour)")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse du vent en kilomètres par heure")]
        public double WindSpeed_km_h { get; set; }
        [Range(0.0D, 360.0D)]
        [CSSPDisplayEN(DisplayEN = "Wind direction (deg)")]
        [CSSPDisplayFR(DisplayFR = "Direction du vent (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Wind direction in degree (north 0, east 90)")]
        [CSSPDescriptionFR(DescriptionFR = @"Direction du vent en degree (nord 0, est 90)")]
        public double WindDirection_deg { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Decay factor (/day)")]
        [CSSPDisplayFR(DisplayFR = "Taux de décroissance (/jour)")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay factor per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Taux de décroissance par jour")]
        public double DecayFactor_per_day { get; set; }
        [CSSPDisplayEN(DisplayEN = "Decay factor is constant")]
        [CSSPDisplayFR(DisplayFR = "Taux de décroissance est constant")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay factor is constant")]
        [CSSPDescriptionFR(DescriptionFR = @"Taux de décroissance est constant")]
        public bool DecayIsConstant { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Decay factor amplitude")]
        [CSSPDisplayFR(DisplayFR = "Amplitude du taux de décroissance")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay factor amplitude")]
        [CSSPDescriptionFR(DescriptionFR = @"Amplitude du taux de décroissance")]
        public double DecayFactorAmplitude { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Results frequency (min)")]
        [CSSPDisplayFR(DisplayFR = "Fréquence des résultats (min)")]
        [CSSPDescriptionEN(DescriptionEN = @"Results frequency in minutes")]
        [CSSPDescriptionFR(DescriptionFR = @"Fréquence des résultats en minutes")]
        public int ResultFrequency_min { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Ambient temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température ambiante (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ambient temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température ambiante en dégré Celcius")]
        public double AmbientTemperature_C { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Ambient salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Salinité ambiante (PSU) (fr)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ambient salinity in PSU")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité ambiante en PSU (fr)")]
        public double AmbientSalinity_PSU { get; set; }
        [CSSPDisplayEN(DisplayEN = "Generate decoupling files")]
        [CSSPDisplayFR(DisplayFR = "Générer des fichiers de découplage")]
        [CSSPDescriptionEN(DescriptionEN = @"Generate decoupling files")]
        [CSSPDescriptionFR(DescriptionFR = @"Générer des fichiers de découplage")]
        public bool? GenerateDecouplingFiles { get; set; }
        [CSSPDisplayEN(DisplayEN = "Use decoupling files")]
        [CSSPDisplayFR(DisplayFR = "Utiliser les fichiers de découplage")]
        [CSSPDescriptionEN(DescriptionEN = @"Use decoupling files")]
        [CSSPDescriptionFR(DescriptionFR = @"Utiliser les fichiers de découplage")]
        public bool? UseDecouplingFiles { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
        [CSSPDisplayEN(DisplayEN = "Use salinity and temperature initial condition from TVFile TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Utilise les conditions initiales de salinité et température à partir de TVFile TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing TV file")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant TV file")]
        public int? UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
        [CSSPDisplayEN(DisplayEN = "For simulating MWQM run TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Pour simuler la tournée TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing MWQM run")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la trounée")]
        public int? ForSimulatingMWQMRunTVItemID { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Manning number")]
        [CSSPDisplayFR(DisplayFR = "Nombre manning")]
        [CSSPDescriptionEN(DescriptionEN = @"Mannning number")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre manning")]
        public double ManningNumber { get; set; }
        [Range(1, 1000000)]
        [CSSPDisplayEN(DisplayEN = "Number of elements")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'éléments")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of elements")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'éléments")]
        public int? NumberOfElements { get; set; }
        [Range(1, 1000000)]
        [CSSPDisplayEN(DisplayEN = "Number of time steps")]
        [CSSPDisplayFR(DisplayFR = "Nombre de pas de temps")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of time steps")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de pas de temps")]
        public int? NumberOfTimeSteps { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Number of sigma layers")]
        [CSSPDisplayFR(DisplayFR = "Nombre de tranche sigma")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of sigma layers")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tranche sigma")]
        public int? NumberOfSigmaLayers { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Number of Z layers")]
        [CSSPDisplayFR(DisplayFR = "Nombre de tranche Z")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of Z layers")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de tranche Z")]
        public int? NumberOfZLayers { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Number of hydrodynamic output parameters")]
        [CSSPDisplayFR(DisplayFR = "Nombre de paramètres de sorti hydrodynamique")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of hydrodynamic output parameters")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de paramètres de sorti hydrodynamique")]
        public int? NumberOfHydroOutputParameters { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Number of transport output parameters")]
        [CSSPDisplayFR(DisplayFR = "Nombre de paramètres de sorti transport")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of transport output parameters")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de paramètres de sorti transport")]
        public int? NumberOfTransOutputParameters { get; set; }
        [Range(0, 100000000)]
        [CSSPDisplayEN(DisplayEN = "Estimated hydrodynamic file size")]
        [CSSPDisplayFR(DisplayFR = "Estimation de la taille du fichier hydrodynamique")]
        [CSSPDescriptionEN(DescriptionEN = @"Estimated hydrodynamic file size")]
        [CSSPDescriptionFR(DescriptionFR = @"Estimation de la taille du fichier hydrodynamique")]
        public long? EstimatedHydroFileSize { get; set; }
        [Range(0, 100000000)]
        [CSSPDisplayEN(DisplayEN = "Estimated transport file size")]
        [CSSPDisplayFR(DisplayFR = "Estimation de la taille du fichier transport")]
        [CSSPDescriptionEN(DescriptionEN = @"Estimated transport file size")]
        [CSSPDescriptionFR(DescriptionFR = @"Estimation de la taille du fichier transport")]
        public long? EstimatedTransFileSize { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeScenario() : base()
        {
        }
        #endregion Constructors
    }
}
