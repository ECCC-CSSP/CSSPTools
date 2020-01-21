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
    public partial class EmailDistributionListContactLanguage : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "EmailDistributionListContactLanguage ID")]
        [CSSPDisplayFR(DisplayFR = "EmailDistributionListContactLanguage ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the EmailDistributionListContactLanguages table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table EmailDistributionListContactLanguages")]
        public int EmailDistributionListContactLanguageID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionListContact", ExistPlurial = "s", ExistFieldID = "EmailDistributionListContactID")]
        [CSSPDisplayEN(DisplayEN = "Email distribution list contact")]
        [CSSPDisplayFR(DisplayFR = "Liste de distribution des courriels contact")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the EmailDistributionListContact table representing the email distribution list contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table EmailDistributionListContact représentant la liste de distribution des courriels contact")]
        public int EmailDistributionListContactID { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Language")]
        [CSSPDisplayFR(DisplayFR = "Langage")]
        [CSSPDescriptionEN(DescriptionEN = @"Language of item")]
        [CSSPDescriptionFR(DescriptionFR = @"Langage de l'item")]
        public LanguageEnum Language { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Agency")]
        [CSSPDisplayFR(DisplayFR = "Agence")]
        [CSSPDescriptionEN(DescriptionEN = @"Agency")]
        [CSSPDescriptionFR(DescriptionFR = @"Agence")]
        public string Agency { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Translation status")]
        [CSSPDisplayFR(DisplayFR = "Le statut de la traduction")]
        [CSSPDescriptionEN(DescriptionEN = @"Translation status of the agency")]
        [CSSPDescriptionFR(DescriptionFR = @"Le statut de la traduction du nom de l'agence")]
        public TranslationStatusEnum TranslationStatus { get; set; }

        [ForeignKey(nameof(EmailDistributionListContactID))]
        [InverseProperty(nameof(EmailDistributionListContact.EmailDistributionListContactLanguages))]
        public virtual EmailDistributionListContact EmailDistributionListContactNavigation { get; set; }
        #endregion Properties in DB

        #region Constructors
        public EmailDistributionListContactLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
