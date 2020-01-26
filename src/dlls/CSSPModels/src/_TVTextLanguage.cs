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
    public partial class TVTextLanguage : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPDisplayEN(DisplayEN = "TV text")]
        [CSSPDisplayFR(DisplayFR = "Texte de 'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"TV text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de 'arbre visuel")]
        public string TVText { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage")]
        public LanguageEnum Language { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "LanguageEnum", EnumType = "Language")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Language text")]
        [CSSPDisplayFR(DisplayFR = "Texte du langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du langage")]
        public string LanguageText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVTextLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
