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
    public partial class InputSummary : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "Summary")]
        [CSSPDisplayFR(DisplayFR = "Sommaire")]
        [CSSPDescriptionEN(DescriptionEN = @"Summary of the pollution sources for MIKE")]
        [CSSPDescriptionFR(DescriptionFR = @"Sommaire des sources de pollution pour MIKE")]
        public string Summary { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public InputSummary() : base()
        {
        }
        #endregion Constructors
    }
}
