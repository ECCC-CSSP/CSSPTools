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
    public partial class TVItemInfrastructureTypeTVItemLink : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Infrastructure type")]
        [CSSPDisplayFR(DisplayFR = "Type d'infrastructure")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'infrastructure")]
        public InfrastructureTypeEnum InfrastructureType { get; set; }
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "See other TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Voir autre TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the other infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'autre infrastructure")]
        public int? SeeOtherMunicipalityTVItemID { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "InfrastructureTypeEnum", EnumType = "InfrastructureType")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Infrastructure type text")]
        [CSSPDisplayFR(DisplayFR = "Texte du type d'infrastructure")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure type text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du type d'infrastructure")]
        public string InfrastructureTypeText { get; set; }
        [CSSPDisplayEN(DisplayEN = "TV Item")]
        [CSSPDisplayFR(DisplayFR = "TV Item")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item")]
        [CSSPDescriptionFR(DescriptionFR = @"L'item de l'arbre visuel")]
        public TVItem TVItem { get; set; }
        [CSSPDisplayEN(DisplayEN = "TV item link list")]
        [CSSPDisplayFR(DisplayFR = "List de liens entre items de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view item link list")]
        [CSSPDescriptionFR(DescriptionFR = @"List de liens entre items de l'arbre visuel")]
        public List<TVItemLink> TVItemLinkList { get; set; }
        [CSSPDisplayEN(DisplayEN = "Flow to")]
        [CSSPDisplayFR(DisplayFR = "Coule vers")]
        [CSSPDescriptionEN(DescriptionEN = @"Infrastructure which flows to another infrastructure")]
        [CSSPDescriptionFR(DescriptionFR = @"Infrastructure coulant vers un autre infrastructure")]
        public TVItemInfrastructureTypeTVItemLink FlowTo { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemInfrastructureTypeTVItemLink() : base()
        {
            TVItemLinkList = new List<TVItemLink>();
        }
        #endregion Constructors
    }
}
