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
    public partial class Register : CSSPError
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(255, MinimumLength = 6)]
        [CSSPDisplayEN(DisplayEN = "Login email")]
        [CSSPDisplayFR(DisplayFR = "Courriel de connexion")]
        [CSSPDescriptionEN(DescriptionEN = @"Login email")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel de connexion")]
        public string LoginEmail { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "First name")]
        [CSSPDisplayFR(DisplayFR = "Prénom")]
        [CSSPDescriptionEN(DescriptionEN = @"First name")]
        [CSSPDescriptionFR(DescriptionFR = @"Prénom")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Initial")]
        [CSSPDisplayFR(DisplayFR = "Initiale")]
        [CSSPDescriptionEN(DescriptionEN = @"Initial")]
        [CSSPDescriptionFR(DescriptionFR = @"Initiale")]
        public string Initial { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Last name")]
        [CSSPDisplayFR(DisplayFR = "Nom de famille")]
        [CSSPDescriptionEN(DescriptionEN = @"Last name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom de famille")]
        public string LastName { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Web name")]
        [CSSPDisplayFR(DisplayFR = "Nom Web")]
        [CSSPDescriptionEN(DescriptionEN = @"Web name")]
        [CSSPDescriptionFR(DescriptionFR = @"Nom Web")]
        public string WebName { get; set; }
        [StringLength(100, MinimumLength = 6)]
        [CSSPDisplayEN(DisplayEN = "Password")]
        [CSSPDisplayFR(DisplayFR = "Mot de passe")]
        [CSSPDescriptionEN(DescriptionEN = @"Password")]
        [CSSPDescriptionFR(DescriptionFR = @"Mot de passe")]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 6)]
        [Compare("Password")]
        [CSSPDisplayEN(DisplayEN = "Confirm password")]
        [CSSPDisplayFR(DisplayFR = "Confirmation du mot de passe")]
        [CSSPDescriptionEN(DescriptionEN = @"Confirm password")]
        [CSSPDescriptionFR(DescriptionFR = @"Confirmation du mot de passe")]
        public string ConfirmPassword { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Register() : base()
        {
        }
        #endregion Constructors
    }
}
