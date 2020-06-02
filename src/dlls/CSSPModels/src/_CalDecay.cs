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
    public partial class CalDecay
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(0.0D, -1.0D)]
        [CSSPDisplayEN(DisplayEN = "Decay rate")]
        [CSSPDisplayFR(DisplayFR = "Taux de décroissance")]
        [CSSPDescriptionEN(DescriptionEN = @"Decay rate")]
        [CSSPDescriptionFR(DescriptionFR = @"Taux de décroissance")]
        public double Decay { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CalDecay() : base()
        {
        }
        #endregion Constructors
    }
}
