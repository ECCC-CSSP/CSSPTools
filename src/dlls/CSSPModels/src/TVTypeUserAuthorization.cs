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
    public partial class TVTypeUserAuthorization : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "TVTypeUserAuthorization ID")]
        [CSSPDisplayFR(DisplayFR = "TVTypeUserAuthorization ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the TVTypeUserAuthorizations table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table TVTypeUserAuthorizations")]
        public int TVTypeUserAuthorizationID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
        [CSSPDisplayEN(DisplayEN = "Contact TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Contact TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant le contact")]
        public int ContactTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV type")]
        [CSSPDisplayFR(DisplayFR = "Type de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de l'arbre visuel")]
        public TVTypeEnum TVType { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "TV authorization")]
        [CSSPDisplayFR(DisplayFR = "Authorization de l'arbre visuel")]
        [CSSPDescriptionEN(DescriptionEN = @"Tree view authorization")]
        [CSSPDescriptionFR(DescriptionFR = @"Type d'authorization de l'arbre visuel")]
        public TVAuthEnum TVAuth { get; set; }
        #endregion Properties in DB

        #region Constructors
        public TVTypeUserAuthorization() : base()
        {
        }
        #endregion Constructors
    }
}
