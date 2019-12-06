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
    public partial class TVItemTVAuth : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "User authorization TV item")]
        [CSSPDisplayFR(DisplayFR = "L'item de l'arbre visuel avec l'authorisation de l'utilisateur")]
        [CSSPDescriptionEN(DescriptionEN = @"User authorization TV item")]
        [CSSPDescriptionFR(DescriptionFR = @"L'item de l'arbre visuel avec l'authorisation de l'utilisateur")]
        public int TVItemUserAuthID { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV text")]
        [CSSPDisplayFR(DisplayFR = "Text de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view text")]
        [CSSPDescriptionFR(DescriptionFR = @"Text de l'arbre visuel")]
        public string TVText { get; set; }
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "TV item 1")]
        [CSSPDisplayFR(DisplayFR = "Item 1 de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item 1")]
        [CSSPDescriptionFR(DescriptionFR = @"Item 1 de l'arbre visuel")]
        public int TVItemID1 { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'arbre visuel")]
        public string TVTypeStr { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV auth")]
        [CSSPDisplayFR(DisplayFR = "Auth de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view authorization")]
        [CSSPDescriptionFR(DescriptionFR = @"Authorisation de l'arbre visuel")]
        public TVAuthEnum TVAuth { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVAuthEnum", EnumType = "TVAuth")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "TV auth text")]
        [CSSPDisplayFR(DisplayFR = "Texte de l'authorisation de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view auth text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'authorisation de l'arbre visuel")]
        public string TVAuthText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemTVAuth() : base()
        {
        }
        #endregion Constructors
    }
}
