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
    public partial class PolyPoint : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "X coord")]
        [CSSPDisplayFR(DisplayFR = "Coordonnée X")]
        [CSSPDescriptionEN(DescriptionEN = @"X coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonnée X")]
        public double XCoord { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Y coord")]
        [CSSPDisplayFR(DisplayFR = "Coordonnée Y")]
        [CSSPDescriptionEN(DescriptionEN = @"Y coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonnée Y")]
        public double YCoord { get; set; }
        [CSSPDisplayEN(DisplayEN = "Z coord")]
        [CSSPDisplayFR(DisplayFR = "Coordonnée Z")]
        [CSSPDescriptionEN(DescriptionEN = @"Z coordinate")]
        [CSSPDescriptionFR(DescriptionFR = @"Coordonnée Z")]
        public double Z { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolyPoint() : base()
        {
        }
        #endregion Constructors
    }
}
