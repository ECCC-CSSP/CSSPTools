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
    public partial class TVItemUserAuthorization : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "TVItemUserAuthorization ID")]
        [CSSPDisplayFR(DisplayFR = "TVItemUserAuthorization ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TVItemUserAuthorizations table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TVItemUserAuthorizations")]
        public int TVItemUserAuthorizationID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le contact")]
        public int ContactTVItemID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "TVItemID 1")]
        [CSSPDisplayFR(DisplayFR = "TVItemID 1")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the item 1 of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item 1 de l'arbre visuel")]
        public int TVItemID1 { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "TVItemID 2")]
        [CSSPDisplayFR(DisplayFR = "TVItemID 2")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the item 2 of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item 2 de l'arbre visuel")]
        public int? TVItemID2 { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "TVItemID 3")]
        [CSSPDisplayFR(DisplayFR = "TVItemID 3")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the item 3 of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item 3 de l'arbre visuel")]
        public int? TVItemID3 { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
        [CSSPDisplayEN(DisplayEN = "TVItemID 4")]
        [CSSPDisplayFR(DisplayFR = "TVItemID 4")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the item 4 of the tree view")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'item 4 de l'arbre visuel")]
        public int? TVItemID4 { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV authorization")]
        [CSSPDisplayFR(DisplayFR = "Authorization pour l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the tree view authorization")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant l'authorization pour l'arbre visuel")]
        public TVAuthEnum TVAuth { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItem.TVItemUserAuthorizationContactTVItems))]
        public virtual TVItem ContactTVItem { get; set; }
        [ForeignKey(nameof(TVItemID1))]
        [InverseProperty(nameof(TVItem.TVItemUserAuthorizationTVItemID1Navigations))]
        public virtual TVItem TVItemID1Navigation { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVItemUserAuthorization() : base()
        {
        }
        #endregion Constructors
    }
}
