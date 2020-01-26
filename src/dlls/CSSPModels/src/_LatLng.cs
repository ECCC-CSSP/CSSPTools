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
    public partial class LatLng : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(-180.0D, 180.0D)]
        [CSSPDisplayEN(DisplayEN = "Lat")]
        [CSSPDisplayFR(DisplayFR = "Lat")]
        [CSSPDescriptionEN(DescriptionEN = @"Lat")]
        [CSSPDescriptionFR(DescriptionFR = @"Lat")]
        public double Lat { get; set; }
        [Range(-90.0D, 90.0D)]
        [CSSPDisplayEN(DisplayEN = "Lng")]
        [CSSPDisplayFR(DisplayFR = "Lng")]
        [CSSPDescriptionEN(DescriptionEN = @"Lng")]
        [CSSPDescriptionFR(DescriptionFR = @"Lng")]
        public double Lng { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LatLng() : base()
        {
        }
        #endregion Constructors
    }
}
