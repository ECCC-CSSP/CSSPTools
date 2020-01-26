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
    public partial class Search : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Value")]
        [CSSPDisplayFR(DisplayFR = "Valeur")]
        [CSSPDescriptionEN(DescriptionEN = @"Value")]
        [CSSPDescriptionFR(DescriptionFR = @"Valeur")]
        public string value { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "ID")]
        [CSSPDisplayFR(DisplayFR = "ID")]
        [CSSPDescriptionEN(DescriptionEN = @"ID")]
        [CSSPDescriptionFR(DescriptionFR = @"ID")]
        public int id { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Search() : base()
        {
        }
        #endregion Constructors
    }
}
