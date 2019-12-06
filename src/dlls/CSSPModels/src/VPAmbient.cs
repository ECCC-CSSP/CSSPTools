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
    public partial class VPAmbient : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "VPAmbient ID")]
        [CSSPDisplayFR(DisplayFR = "VPAmbient ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the VPAmbients table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table VPAmbients")]
        public int VPAmbientID { get; set; }
        [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
        [CSSPDisplayEN(DisplayEN = "VP scenario ID")]
        [CSSPDisplayFR(DisplayFR = "Scénario VP ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the VPScenarios table representing the visual plumes scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table VPScenarios représentant le scénario visual plumes")]
        public int VPScenarioID { get; set; }
        [Range(0, 10)]
        [CSSPDisplayEN(DisplayEN = "Row")]
        [CSSPDisplayFR(DisplayFR = "Rangé")]
        [CSSPDescriptionEN(DescriptionEN = @"Row")]
        [CSSPDescriptionFR(DescriptionFR = @"Rangé")]
        public int Row { get; set; }
        [Range(0.0D, 1000.0D)]
        [CSSPDisplayEN(DisplayEN = "Measurement depth (m)")]
        [CSSPDisplayFR(DisplayFR = "Profondeur de mesure (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Measurement depth in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Profondeur de mesure en mètres")]
        public double? MeasurementDepth_m { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Current speed (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse de courant (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Current speed in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse de courant en mètres par second")]
        public double? CurrentSpeed_m_s { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Current direction (deg)")]
        [CSSPDisplayFR(DisplayFR = "Direction du courant (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Current direction in degrees")]
        [CSSPDescriptionFR(DescriptionFR = @"Direction du courant en dégré")]
        public double? CurrentDirection_deg { get; set; }
        [Range(0.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Ambient salinity (PSU)")]
        [CSSPDisplayFR(DisplayFR = "Salinité ambiante (PSU)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ambient salinity (PSU)")]
        [CSSPDescriptionFR(DescriptionFR = @"Salinité ambiante (PSU)")]
        public double? AmbientSalinity_PSU { get; set; }
        [Range(-10.0D, 40.0D)]
        [CSSPDisplayEN(DisplayEN = "Ambient temperature (°C)")]
        [CSSPDisplayFR(DisplayFR = "Température ambiante (°C)")]
        [CSSPDescriptionEN(DescriptionEN = @"Ambient temperature (°C)")]
        [CSSPDescriptionFR(DescriptionFR = @"Température ambiante (°C)")]
        public double? AmbientTemperature_C { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Background concentration (MPN / 100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Concentration de fond (MPN / 100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Background concentration in most probable number per 100 milli-Litres")]
        [CSSPDescriptionFR(DescriptionFR = @"Concentration de fond en nombre le plus probable par 100 milli-Litres")]
        public int? BackgroundConcentration_MPN_100ml { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Pollution decay rate (/d)")]
        [CSSPDisplayFR(DisplayFR = "Taux de décoissance (/j)")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution decay rate per day")]
        [CSSPDescriptionFR(DescriptionFR = @"Taux de décoissance par jour)")]
        public double? PollutantDecayRate_per_day { get; set; }
        [Range(0.0D, 10.0D)]
        [CSSPDisplayEN(DisplayEN = "Far field current speed (m/s)")]
        [CSSPDisplayFR(DisplayFR = "Vitesse du courant de loin (m/s)")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field current speed in meters per second")]
        [CSSPDescriptionFR(DescriptionFR = @"Vitesse du courant de loin en mètre par second)")]
        public double? FarFieldCurrentSpeed_m_s { get; set; }
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Far field current direction (deg)")]
        [CSSPDisplayFR(DisplayFR = "Direction du courant de loin (deg)")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field current direction in degrees")]
        [CSSPDescriptionFR(DescriptionFR = @"Direction du courant de loin en dégré)")]
        public double? FarFieldCurrentDirection_deg { get; set; }
        [Range(0.0D, 1.0D)]
        [CSSPDisplayEN(DisplayEN = "Far field diffusion coefficient")]
        [CSSPDisplayFR(DisplayFR = "Coefficient de diffusion de loin")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field diffusion coefficient")]
        [CSSPDescriptionFR(DescriptionFR = @"Coefficient de diffusion de loin")]
        public double? FarFieldDiffusionCoefficient { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPAmbient() : base()
        {
        }
        #endregion Constructors
    }
}
