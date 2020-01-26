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
    public partial class EmailDistributionListLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "EmailDistributionListLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "EmailDistributionListLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the EmailDistributionListLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table EmailDistributionListLanguages")]
        public int EmailDistributionListLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPDisplayEN(DisplayEN = "Email distribution list")]
        [CSSPDisplayFR(DisplayFR = "Liste de distribution des courriels")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the EmailDistributionList table representing the email distribution list")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table EmailDistributionList représentant la liste de distribution des courriels")]
        public int EmailDistributionListID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Email List Name")]
        [CSSPDisplayFR(DisplayFR = "Nom de la liste de courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email List Name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de la liste de courriel")]
        public string EmailListName { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the region name")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom de la région")]
        public TranslationStatusEnum TranslationStatus { get; set; }
        #endregion Properties in DB

        #region Constructors
        public EmailDistributionListLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
