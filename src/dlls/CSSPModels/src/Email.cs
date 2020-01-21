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
    public partial class Email : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "Email ID")]
        [CSSPDisplayFR(DisplayFR = "Email ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the Emails table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table Emails")]
        public int EmailID { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "7")]
        [CSSPDisplayEN(DisplayEN = "Email")]
        [CSSPDisplayFR(DisplayFR = "Courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Link to the TVItems table representing the email")]
        [CSSPDescriptionFR(DescriptionFR = @"Lien à la table TVItems représentant la courriel")]
        public int EmailTVItemID { get; set; }
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [CSSPDisplayEN(DisplayEN = "Email address")]
        [CSSPDisplayFR(DisplayFR = "Adresse courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email address")]
        [CSSPDescriptionFR(DescriptionFR = @"Adresse courriel")]
        public string EmailAddress { get; set; }
        [CSSPEnumType]
        [CSSPDisplayEN(DisplayEN = "Email type")]
        [CSSPDisplayFR(DisplayFR = "Type de courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email type")]
        [CSSPDescriptionFR(DescriptionFR = @"Type de courriel")]
        public EmailTypeEnum EmailType { get; set; }

        [ForeignKey(nameof(EmailTVItemID))]
        [InverseProperty(nameof(TVItem.Emails))]
        public virtual TVItem EmailTVItem { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Email() : base()
        {
        }
        #endregion Constructors
    }
}
