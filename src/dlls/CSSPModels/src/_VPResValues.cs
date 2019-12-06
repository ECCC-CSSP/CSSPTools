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
    [NotMapped]
    public partial class VPResValues : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "Conc")]
        [CSSPDisplayFR(DisplayFR = "Conc")]
        [CSSPDescriptionEN(DescriptionEN = @"Concontration")]
        [CSSPDescriptionFR(DescriptionFR = @"Concontration")]
        public int Conc { get; set; }
        [CSSPDisplayEN(DisplayEN = "Dilu")]
        [CSSPDisplayFR(DisplayFR = "Dilu")]
        [CSSPDescriptionEN(DescriptionEN = @"Dilution")]
        [CSSPDescriptionFR(DescriptionFR = @"Dilution")]
        public double Dilu { get; set; }
        [CSSPDisplayEN(DisplayEN = "Far field width")]
        [CSSPDisplayFR(DisplayFR = "Largeur du champ éloigné")]
        [CSSPDescriptionEN(DescriptionEN = @"Far field width")]
        [CSSPDescriptionFR(DescriptionFR = @"Largeur du champ éloigné")]
        public double FarfieldWidth { get; set; }
        [CSSPDisplayEN(DisplayEN = "Distance")]
        [CSSPDisplayFR(DisplayFR = "Distance")]
        [CSSPDescriptionEN(DescriptionEN = @"Distance the pollution travelled")]
        [CSSPDescriptionFR(DescriptionFR = @"Distance parcourue de la pollution")]
        public double Distance { get; set; }
        [CSSPDisplayEN(DisplayEN = "Time")]
        [CSSPDisplayFR(DisplayFR = "Time")]
        [CSSPDescriptionEN(DescriptionEN = @"Time the pollution travelled")]
        [CSSPDescriptionFR(DescriptionFR = @"Le temps du parcour de lla pollution")]
        public double TheTime { get; set; }
        [CSSPDisplayEN(DisplayEN = "Decay")]
        [CSSPDisplayFR(DisplayFR = "Décroissance")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay")]
        [CSSPDescriptionFR(DescriptionFR = @"Décroissance")]
        public double Decay { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VPResValues() : base()
        {
        }
        #endregion Constructors
    }
}
