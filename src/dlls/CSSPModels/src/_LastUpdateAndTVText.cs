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
    public partial class LastUpdateAndTVText : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Last update date")]
        [CSSPDisplayFR(DisplayFR = "Date de dernième mise à jour")]
        [CSSPDescriptionEN(DescriptionEN = @"Last update date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de dernième mise à jour")]
        public DateTime LastUpdateAndTVTextDate_UTC { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Last update date")]
        [CSSPDisplayFR(DisplayFR = "Date de dernième mise à jour")]
        [CSSPDescriptionEN(DescriptionEN = @"Last update date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de dernième mise à jour")]
        public DateTime LastUpdateDate_Local { get; set; }
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV text")]
        [CSSPDisplayFR(DisplayFR = "Texte TV")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'arbre visuel")]
        public string TVText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LastUpdateAndTVText() : base()
        {
        }
        #endregion Constructors
    }
}
