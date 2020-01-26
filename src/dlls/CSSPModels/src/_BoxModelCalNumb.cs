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
    public partial class BoxModelCalNumb : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Box model result type")]
        [CSSPDisplayFR(DisplayFR = "Type de résultat box model")]
        [CSSPDescriptionEN(DescriptionEN = @"Box model result type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de résultat box model")]
        public BoxModelResultTypeEnum BoxModelResultType { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Length (m)")]
        [CSSPDisplayFR(DisplayFR = "Longueur (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated length in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Longueur calculée en mètres")]
        public double CalLength_m { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Radius (m)")]
        [CSSPDisplayFR(DisplayFR = "Rayon (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated radius in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Rayon calculé en mètres")]
        public double CalRadius_m { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Surface (m2)")]
        [CSSPDisplayFR(DisplayFR = "Surface (m2)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated surface in square meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Surface calculée en mètres carrés")]
        public double CalSurface_m2 { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Volume (m3)")]
        [CSSPDisplayFR(DisplayFR = "Volume (m3)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated volume in cubic meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Volume calculé en mètres cubes")]
        public double CalVolume_m3 { get; set; }
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Width (m)")]
        [CSSPDisplayFR(DisplayFR = "Largeur (m)")]
        [CSSPDescriptionEN(DescriptionEN = @"Calculated with in meters")]
        [CSSPDescriptionFR(DescriptionFR = @"Largeur calculé en mètres")]
        public double CalWidth_m { get; set; }
        [CSSPDisplayEN(DisplayEN = "Fix length")]
        [CSSPDisplayFR(DisplayFR = "Longueur fix")]
        [CSSPDescriptionEN(DescriptionEN = @"Fix length")]
        [CSSPDescriptionFR(DescriptionFR = @"Longueur fix")]
        public bool FixLength { get; set; }
        [CSSPDisplayEN(DisplayEN = "Fix width")]
        [CSSPDisplayFR(DisplayFR = "Largeur fix")]
        [CSSPDescriptionEN(DescriptionEN = @"Fix width")]
        [CSSPDescriptionFR(DescriptionFR = @"Largueur fix")]
        public bool FixWidth { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "BoxModelResultTypeEnum", EnumType = "BoxModelResultType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Box model result type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type de résultat box model")]
        [CSSPDescriptionEN(DescriptionEN = @"Box model result type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type de résultat box model")]
        public string BoxModelResultTypeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public BoxModelCalNumb() : base()
        {
        }
        #endregion Constructors
    }
}
