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
    public partial class Tel : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Tel ID")]
        [CSSPDisplayFR(DisplayFR = "Tel ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Tels table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Tels")]
        public int TelID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "21")]
        [CSSPDisplayEN(DisplayEN = "Tel")]
        [CSSPDisplayFR(DisplayFR = "Tél")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the telephone")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la téléphone")]
        public int TelTVItemID { get; set; }
        [StringLength(50)]
        [CSSPDisplayEN(DisplayEN = "Tel number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de tél")]
        [CSSPDescriptionEN(DescriptionEN = @"Telephone number")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de téléphone")]
        public string TelNumber { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Tel type")]
        [CSSPDisplayFR(DisplayFR = "Type de tél")]
        [CSSPDescriptionEN(DescriptionEN = @"Telephone type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de téléphone")]
        public TelTypeEnum TelType { get; set; }

        [ForeignKey(nameof(TelTVItemID))]
        [InverseProperty(nameof(TVItem.Tels))]
        public virtual TVItem TelTVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Tel() : base()
        {
        }
        #endregion Constructors
    }
}
