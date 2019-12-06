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
    public partial class VPScenario : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "VPScenario ID")]
        [CSSPDisplayFR(DisplayFR = "VPScenario ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the VPScenarios table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table VPScenarios")]
        public int VPScenarioID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
        [CSSPDisplayEN(DisplayEN = "Infrastructure TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Infrastructure TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'infrastructure")]
        public int InfrastructureTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "VP scenario status")]
        [CSSPDisplayFR(DisplayFR = "État du scénario VP")]
        [CSSPDescriptionEN(DescriptionEN = @"Visual plumes scenario status")]
        [CSSPDescriptionFR(DescriptionFR = @"État du scénario visual plumes")]
        public ScenarioStatusEnum VPScenarioStatus { get; set; }
        [CSSPDisplayEN(DisplayEN = "Use as best estimate")]
        [CSSPDisplayFR(DisplayFR = "Utilise comme meilleur estimation")]
        [CSSPDescriptionEN(DescriptionEN = @"Use as best estimate")]
        [CSSPDescriptionFR(DescriptionFR = @"Utilise comme meilleur estimation")]
        public bool UseAsBestEstimate { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Effluent flow (m3/s)")]
        [CSSPDisplayFR(DisplayFR = "Débit de l'effluent (m3/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Effluent flow in cubic meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Débit de l'effluent en mètres cube par second")]
        public double? EffluentFlow_m3_s { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Effluent concentration (MPN / 100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Concentration de l'effluent (NPP / 100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Effluent concentration in most probable number per 100 milli-Litres")]
        [CSSPDescriptionFR(DescriptionFR = @"Concentration de l'effluent en nombre le plus probable par 100 milli-Litres")]
        public int? EffluentConcentration_MPN_100ml { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Froude number")]
        [CSSPDisplayFR(DisplayFR = "Nombre de Froude")]
        [CSSPDescriptionEN(DescriptionEN = @"Froude number")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre de Froude")]
        public double? FroudeNumber { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Port diameter (m)")]
        [CSSPDisplayFR(DisplayFR = "Diamètre de l'orifice (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Port diameter in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Diamètre de l'orifice en mètres")]
        public double? PortDiameter_m { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Port depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur de l'orifice (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Port depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur de l'orifice en mètres")]
        public double? PortDepth_m { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Port elevation (m)")]
        [CSSPDisplayFR(DisplayFR = "Élévation de l'orifice (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Port elevation in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Élévation de l'orifice en mètres")]
        public double? PortElevation_m { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Vertical angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle vertical (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Vertical angle in degree")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle vertical en dégré")]
        public double? VerticalAngle_deg { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Horizontal angle (deg)")]
        [CSSPDisplayFR(DisplayFR = "Angle horizontal (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Horizontal angle in degree")]
        [CSSPDescriptionFR(DescriptionFR = @"Angle horizontal en dégré")]
        public double? HorizontalAngle_deg { get; set; }
        [Range(1, 100)]
        [CSSPDisplayEN(DisplayEN = "Number of ports")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'orifice")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of ports")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'orifice")]
        public int? NumberOfPorts { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Port spacing (m)")]
        [CSSPDisplayFR(DisplayFR = "Distance entre les orifices (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Port spacing in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Distance entre les orifices en mètres")]
        public double? PortSpacing_m { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Acute mix zone (m)")]
        [CSSPDisplayFR(DisplayFR = "Zone de pollution aigüe (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Acute mix zone in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Zone de pollution aigüe en mètres")]
        public double? AcuteMixZone_m { get; set; }
        [Range(0.0D, 40000.0D)]
        [CSSPDisplayEN(DisplayEN = "Chronic mix zone (m)")]
        [CSSPDisplayFR(DisplayFR = "Zone de pollution chronique (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Chronic mix zone in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Zone de pollution chronique en mètres")]
        public double? ChronicMixZone_m { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Effluent salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Salinité de l'effluent (PSU)")]
        [CSSPDescriptionEN(DescriptionEN = @"Effluent salinity in PSU")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité de l'effluent en PSU")]
        public double? EffluentSalinity_PSU { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Effluent temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température de l'effluent (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Effluent temperature in degree Celcius")]
        [CSSPDescriptionFR(DescriptionFR = @"Température de l'effluent en dégré Celcius")]
        public double? EffluentTemperature_C { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Effluent velocity (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse de l'effluent (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Effluent velocity in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse de l'effluent en mètres par second")]
        public double? EffluentVelocity_m_s { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Raw results")]
        [CSSPDisplayFR(DisplayFR = "Résultats bruts")]
        [CSSPDescriptionEN(DescriptionEN = @"Raw results")]
        [CSSPDescriptionFR(DescriptionFR = @"Résultats bruts")]
        public string RawResults { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPScenario() : base()
        {
        }
        #endregion Constructors
    }
}
