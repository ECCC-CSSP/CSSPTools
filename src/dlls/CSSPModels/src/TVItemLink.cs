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
    public partial class TVItemLink : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "TVItemLink ID")]
        [CSSPDisplayFR(DisplayFR = "TVItemLink ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TVItemLinks table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TVItemLinks")]
        public int TVItemLinkID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "From TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Départ TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the from")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le départ")]
        public int FromTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "To TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Fin TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the to")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la fin")]
        public int ToTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "From tv type")]
        [CSSPDisplayFR(DisplayFR = "Type d'arbre visuel du départ")]
        [CSSPDescriptionEN(DescriptionEN = @"From tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'arbre visuel du départ")]
        public TVTypeEnum FromTVType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "To tv type")]
        [CSSPDisplayFR(DisplayFR = "Type d'arbre visuel de la fin")]
        [CSSPDescriptionEN(DescriptionEN = @"To tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'arbre visuel de la fin")]
        public TVTypeEnum ToTVType { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Start date")]
        [CSSPDisplayFR(DisplayFR = "Date de départ")]
        [CSSPDescriptionEN(DescriptionEN = @"Start date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de départ")]
        public DateTime? StartDateTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDateTime_Local")]
        [CSSPDisplayEN(DisplayEN = "End date")]
        [CSSPDisplayFR(DisplayFR = "Date de fin")]
        [CSSPDescriptionEN(DescriptionEN = @"End date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin")]
        public DateTime? EndDateTime_Local { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal")]
        [CSSPDescriptionFR(DescriptionFR = @"Ordre")]
        public int Ordinal { get; set; }
        [Range(0, 100)]
        [CSSPDisplayEN(DisplayEN = "TV level")]
        [CSSPDisplayFR(DisplayFR = "Niveau de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view level")]
        [CSSPDescriptionFR(DescriptionFR = @"Niveau de l'arbre visuel")]
        public int TVLevel { get; set; }
        [StringLength(250)]
        [CSSPDisplayEN(DisplayEN = "TV path")]
        [CSSPDisplayFR(DisplayFR = "Chemin de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view path")]
        [CSSPDescriptionFR(DescriptionFR = @"Chemin de l'arbre visuel")]
        public string TVPath { get; set; }
        [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID")]
        [CSSPDisplayEN(DisplayEN = "Parent TV item link")]
        [CSSPDisplayFR(DisplayFR = "Lien du parent de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Parent tree view item link")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien du parent de l'arbre visuel")]
        public int? ParentTVItemLinkID { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVItemLink() : base()
        {
        }
        #endregion Constructors
    }
}
