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
    public partial class EmailDistributionListContact : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "EmailDistributionListContact ID")]
        [CSSPDisplayFR(DisplayFR = "EmailDistributionListContact ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the EmailDistributionListContacts table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table EmailDistributionListContacts")]
        public int EmailDistributionListContactID { get; set; }
        [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
        [CSSPDisplayEN(DisplayEN = "Email distribution list")]
        [CSSPDisplayFR(DisplayFR = "Liste de distribution des courriels")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the EmailDistributionList table representing the email distribution list")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table EmailDistributionList représentant la liste de distribution des courriels")]
        public int EmailDistributionListID { get; set; }
        [CSSPDisplayEN(DisplayEN = "CC")]
        [CSSPDisplayFR(DisplayFR = "CC")]
        [CSSPDescriptionEN(DescriptionEN = @"Send email as CC")]
        [CSSPDescriptionFR(DescriptionFR = @"Envoy courriel comme CC")]
        public bool IsCC { get; set; }
        [StringLength(100)]
        [CSSPDisplayEN(DisplayEN = "Name")]
        [CSSPDisplayFR(DisplayFR = "Nom")]
        [CSSPDescriptionEN(DescriptionEN = @"Name of the contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom du contact")]
        public string Name { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        [CSSPDisplayEN(DisplayEN = "Email")]
        [CSSPDisplayFR(DisplayFR = "Courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email of the contact")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel du contact")]
        public string Email { get; set; }
        [CSSPDisplayEN(DisplayEN = "CMP Rainfall Seasonal")]
        [CSSPDisplayFR(DisplayFR = "Pluie Saisonnière PGC")]
        [CSSPDescriptionEN(DescriptionEN = @"CMP Rainfall Seasonal")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie Saisonnière PGC")]
        public bool CMPRainfallSeasonal { get; set; }
        [CSSPDisplayEN(DisplayEN = "CMP Wastewater")]
        [CSSPDisplayFR(DisplayFR = "Eaux Usées PGC")]
        [CSSPDescriptionEN(DescriptionEN = @"CMP Wastewater")]
        [CSSPDescriptionFR(DescriptionFR = @"Eaux usées PGC")]
        public bool CMPWastewater { get; set; }
        [CSSPDisplayEN(DisplayEN = "Emergency Weather")]
        [CSSPDisplayFR(DisplayFR = "Pluie Urgence")]
        [CSSPDescriptionEN(DescriptionEN = @"Emergency Weather")]
        [CSSPDescriptionFR(DescriptionFR = @"Pluie Urgence")]
        public bool EmergencyWeather { get; set; }
        [CSSPDisplayEN(DisplayEN = "Emergency Wastewater")]
        [CSSPDisplayFR(DisplayFR = "Eaux Usées Urgence")]
        [CSSPDescriptionEN(DescriptionEN = @"Emergency Wastewater")]
        [CSSPDescriptionFR(DescriptionFR = @"Eaux Usées Urgence")]
        public bool EmergencyWastewater { get; set; }
        [CSSPDisplayEN(DisplayEN = "Reopening All Types")]
        [CSSPDisplayFR(DisplayFR = "Réouverture Tous Types")]
        [CSSPDescriptionEN(DescriptionEN = @"Reopening All Types")]
        [CSSPDescriptionFR(DescriptionFR = @"Réouverture Tous Types")]
        public bool ReopeningAllTypes { get; set; }

        [ForeignKey(nameof(EmailDistributionListID))]
        [InverseProperty(nameof(EmailDistributionList.EmailDistributionListContacts))]
        public virtual EmailDistributionList EmailDistributionListNavigation { get; set; }
        [InverseProperty("EmailDistributionListContact")]
        public virtual ICollection<EmailDistributionListContactLanguage> EmailDistributionListContactLanguages { get; set; }
        #endregion Properties in DB

        #region Constructors
        public EmailDistributionListContact() : base()
        {
        }
        #endregion Constructors
    }
}
