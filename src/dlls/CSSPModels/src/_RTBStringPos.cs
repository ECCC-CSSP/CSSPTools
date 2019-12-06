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
    public partial class RTBStringPos : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "Start pos")]
        [CSSPDisplayFR(DisplayFR = "Position de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Start position")]
        [CSSPDescriptionFR(DescriptionFR = @"Position de départ")]
        public int StartPos { get; set; }
        [Range(0, -1)]
        [CSSPDisplayEN(DisplayEN = "End pos")]
        [CSSPDisplayFR(DisplayFR = "Position de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"End position")]
        [CSSPDescriptionFR(DescriptionFR = @"Position de fin")]
        public int EndPos { get; set; }
        [CSSPDisplayEN(DisplayEN = "Text")]
        [CSSPDisplayFR(DisplayFR = "Texte")]
        [CSSPDescriptionEN(DescriptionEN = @"Text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte")]
        public string Text { get; set; }
        [CSSPDisplayEN(DisplayEN = "Tag text")]
        [CSSPDisplayFR(DisplayFR = "Texte du tag")]
        [CSSPDescriptionEN(DescriptionEN = @"Tag text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du tag")]
        public string TagText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public RTBStringPos() : base()
        {
        }
        #endregion Constructors
    }
}
