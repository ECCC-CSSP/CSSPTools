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
    public partial class TVTypeNamesAndPath : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV type name")]
        [CSSPDisplayFR(DisplayFR = "Nom du type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du type de l'arbre visuel")]
        public string TVTypeName { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "Index")]
        [CSSPDisplayFR(DisplayFR = "Indice")]
        [CSSPDescriptionEN(DescriptionEN = @"Index")]
        [CSSPDescriptionFR(DescriptionFR = @"Indice")]
        public int Index { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV path")]
        [CSSPDisplayFR(DisplayFR = "Chemin de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view path")]
        [CSSPDescriptionFR(DescriptionFR = @"Chemin de l'arbre visuel")]
        public string TVPath { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVTypeNamesAndPath() : base()
        {
        }
        #endregion Constructors
    }
}
