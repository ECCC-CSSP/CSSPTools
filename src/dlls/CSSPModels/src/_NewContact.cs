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
    [NotMapped]
    public partial class NewContact
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Login email")]
        [CSSPDisplayFR(DisplayFR = "Courriel de connexion")]
        [CSSPDescriptionEN(DescriptionEN = @"Login email")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel de connexion")]
        public string LoginEmail { get; set; }
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "First name")]
        [CSSPDisplayFR(DisplayFR = "Prénom")]
        [CSSPDescriptionEN(DescriptionEN = @"First name")]
        [CSSPDescriptionFR(DescriptionFR = @"Prénom")]
        public string FirstName { get; set; }
        [StringLength(200, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Last name")]
        [CSSPDisplayFR(DisplayFR = "Nom de famille")]
        [CSSPDescriptionEN(DescriptionEN = @"Last name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de famille")]
        public string LastName { get; set; }
        [StringLength(50)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Initial")]
        [CSSPDisplayFR(DisplayFR = "Initiale")]
        [CSSPDescriptionEN(DescriptionEN = @"Initial")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiale")]
        public string Initial { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Contact title")]
        [CSSPDisplayFR(DisplayFR = "Titre du contact")]
        [CSSPDescriptionEN(DescriptionEN = @"Contact title")]
        [CSSPDescriptionFR(DescriptionFR = @"Titre du contact")]
        public ContactTitleEnum? ContactTitle { get; set; }
        [StringLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "ContactTitleEnum", EnumType = "ContactTitle")]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Contact title text")]
        [CSSPDisplayFR(DisplayFR = "Texte du titre du contact")]
        [CSSPDescriptionEN(DescriptionEN = @"Contact title text")]
        [CSSPDescriptionFR(DescriptionFR = @"Texte du titre du contact")]
        public string ContactTitleText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public NewContact() : base()
        {
        }
        #endregion Constructors
    }
}
