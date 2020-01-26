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
    public partial class URLNumberOfSamples : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Url")]
        [CSSPDisplayFR(DisplayFR = "Url")]
        [CSSPDescriptionEN(DescriptionEN = @"Url")]
        [CSSPDescriptionFR(DescriptionFR = @"Url")]
        public string url { get; set; }
        [CSSPDisplayEN(DisplayEN = "Number of samples")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'échantillons")]
        [CSSPDescriptionEN(DescriptionEN = @"Number of samples")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'échantillons")]
        public int NumberOfSamples { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public URLNumberOfSamples() : base()
        {
        }
        #endregion Constructors
    }
}
