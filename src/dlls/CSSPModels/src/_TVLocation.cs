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
    public partial class TVLocation
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1, -1)]
        [CSSPDisplayEN(DisplayEN = "TVItemID")]
        [CSSPDisplayFR(DisplayFR = "TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing tree view item")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item de l'arbre visuel")]
        public int TVItemID { get; set; }
        [StringLength(255, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "TV text")]
        [CSSPDisplayFR(DisplayFR = "Texte de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte de l'arbre visuel")]
        public string TVText { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de l'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Sub TV type")]
        [CSSPDisplayFR(DisplayFR = "Sous type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Sub tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Sous type de l'arbre visuel")]
        public TVTypeEnum SubTVType { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "TVType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "TV type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type de l'arbre visuel")]
        public string TVTypeText { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVTypeEnum", EnumType = "SubTVType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Sub TV type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du sous-type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Sub tree view type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du sous-type de l'arbre visuel")]
        public string SubTVTypeText { get; set; }
        [CSSPDisplayEN(DisplayEN = "MapObj list")]
        [CSSPDisplayFR(DisplayFR = "Liste MapObj")]
        [CSSPDescriptionEN(DescriptionEN = @"MapObj list")]
        [CSSPDescriptionFR(DescriptionFR = @"Liste MapObj")]
        public List<MapObj> MapObjList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVLocation() : base()
        {
            MapObjList = new List<MapObj>();
        }
        #endregion Constructors
    }
}
