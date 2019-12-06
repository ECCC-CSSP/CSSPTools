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
    public partial class Coord : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Lat")]
        [CSSPDisplayFR(DisplayFR = "Lat")]
        [CSSPDescriptionEN(DescriptionEN = @"Latitude")]
        [CSSPDescriptionFR(DescriptionFR = @"Latitude")]
        public double Lat { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Long")]
        [CSSPDisplayFR(DisplayFR = "Long")]
        [CSSPDescriptionEN(DescriptionEN = @"Longitude")]
        [CSSPDescriptionFR(DescriptionFR = @"Longitude")]
        public double Lng { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Coord() : base()
        {
        }
        #endregion Constructors
    }
}
