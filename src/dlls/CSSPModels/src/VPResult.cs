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
    public partial class VPResult : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "VPResult ID")]
        [CSSPDisplayFR(DisplayFR = "VPResult ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the VPResults table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table VPResults")]
        public int VPResultID { get; set; }
        [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
        [CSSPDisplayEN(DisplayEN = "VP scenario ID")]
        [CSSPDisplayFR(DisplayFR = "Scénario VP ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the VPScenarios table representing the visual plumes scenario")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table VPScenarios représentant le scénario visual plumes")]
        public int VPScenarioID { get; set; }
        [Range(0, 1000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [Range(0, 10000000)]
        [CSSPDisplayEN(DisplayEN = "Concentration (MPN / 100 mL)")]
        [CSSPDisplayFR(DisplayFR = "Concentration (NPP / 100 mL)")]
        [CSSPDescriptionEN(DescriptionEN = @"Concentration in most probable number per 100 milli-Litres")]
        [CSSPDescriptionFR(DescriptionFR = @"Concentration en nombre le plus probable par 100 milli-Litres")]
        public int Concentration_MPN_100ml { get; set; }
        [Range(0.0D, 1000000.0D)]
        [CSSPDisplayEN(DisplayEN = "Dilution")]
        [CSSPDisplayFR(DisplayFR = "Dilution")]
        [CSSPDescriptionEN(DescriptionEN = @"Dilution")]
        [CSSPDescriptionFR(DescriptionFR = @"Dilution")]
        public double Dilution { get; set; }
        [Range(0.0D, 10000.0D)]
        [CSSPDisplayEN(DisplayEN = "Far field width (m)")]
        [CSSPDisplayFR(DisplayFR = "Largeur au loin (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field width in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Largeur au loin en métres")]
        public double FarFieldWidth_m { get; set; }
        [Range(0.0D, 100000.0D)]
        [CSSPDisplayEN(DisplayEN = "Dispersion distance (m)")]
        [CSSPDisplayFR(DisplayFR = "Distance de dispersion (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Dispersion distance in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Distance de dispersion en métres")]
        public double DispersionDistance_m { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Travel time (h)")]
        [CSSPDisplayFR(DisplayFR = "Temps de dispersion (h)")]
        [CSSPDescriptionEN(DescriptionEN = @"Travel time in hours")]
        [CSSPDescriptionFR(DescriptionFR = @"Temps de dispersion en heures")]
        public double TravelTime_hour { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPResult() : base()
        {
        }
        #endregion Constructors
    }
}
