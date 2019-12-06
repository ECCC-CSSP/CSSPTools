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
    public partial class PolSourceSiteEffectTerm : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "PolSourceSiteEffectTerm ID")]
        [CSSPDisplayFR(DisplayFR = "PolSourceSiteEffectTerm ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the PolSourceSiteEffectTerms table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table PolSourceSiteEffectTerms")]
        public int PolSourceSiteEffectTermID { get; set; }
        [CSSPDisplayEN(DisplayEN = "Is group")]
        [CSSPDisplayFR(DisplayFR = "Est un groupe")]
        [CSSPDescriptionEN(DescriptionEN = @"Is group")]
        [CSSPDescriptionFR(DescriptionFR = @"Est un groupe")]
        public bool IsGroup { get; set; }
        [CSSPExist(ExistTypeName = "PolSourceSiteEffectTerm", ExistPlurial = "s", ExistFieldID = "PolSourceSiteEffectTermID")]
        [CSSPDisplayEN(DisplayEN = "Pollution source site effect term ID")]
        [CSSPDisplayFR(DisplayFR = "Terme d'effect pour le site de la source de pollution ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Pollution source site effect term ID")]
        [CSSPDescriptionFR(DescriptionFR = @"Terme d'effect pour le site de la source de pollution ID")]
        public int? UnderGroupID { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "English effect term")]
        [CSSPDisplayFR(DisplayFR = "Terme d'effet en anglais")]
        [CSSPDescriptionEN(DescriptionEN = @"English effect term")]
        [CSSPDescriptionFR(DescriptionFR = @"Terme d'effet en anglais")]
        public string EffectTermEN { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "French effect term")]
        [CSSPDisplayFR(DisplayFR = "Terme d'effet en français")]
        [CSSPDescriptionEN(DescriptionEN = @"French effect term")]
        [CSSPDescriptionFR(DescriptionFR = @"Terme d'effet en français")]
        public string EffectTermFR { get; set; }
        #endregion Properties in DB

        #region Constructors
        public PolSourceSiteEffectTerm() : base()
        {
        }
        #endregion Constructors
    }
}
