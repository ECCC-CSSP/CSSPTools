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
    public partial class TVFullText
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TVPath")]
        [CSSPDisplayFR(DisplayFR = "TVPath")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view path")]
        [CSSPDescriptionFR(DescriptionFR = @"Chemin de l'arbre visuel")]
        public string TVPath { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Full text")]
        [CSSPDisplayFR(DisplayFR = "Texte intégral")]
        [CSSPDescriptionEN(DescriptionEN = @"Full text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte intégral")]
        public string FullText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVFullText() : base()
        {
        }
        #endregion Constructors
    }
}
