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
    public partial class Classification : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Classification ID")]
        [CSSPDisplayFR(DisplayFR = "Classification ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Classification table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Classification")]
        public int ClassificationID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "79")]
        [CSSPDisplayEN(DisplayEN = "Classification TVItemID")]
        [CSSPDisplayFR(DisplayFR = "Classification TVItemID")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table with the unique identifier")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems avec l'identifiant unique")]
        public int ClassificationTVItemID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Classification type")]
        [CSSPDisplayFR(DisplayFR = "Type de classification")]
        [CSSPDescriptionEN(DescriptionEN = @"Classification type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de classification")]
        public ClassificationTypeEnum ClassificationType { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Ordinal")]
        [CSSPDisplayFR(DisplayFR = "Ordre")]
        [CSSPDescriptionEN(DescriptionEN = @"Ordinal number used to order the classification")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro indiquent l'ordre des classification")]
        public int Ordinal { get; set; }

        [ForeignKey(nameof(ClassificationTVItemID))]
        [InverseProperty(nameof(TVItem.Classifications))]
        public virtual TVItem ClassificationTVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Classification() : base()
        {
        }
        #endregion Constructors
    }
}
