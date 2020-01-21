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
    public partial class AspNetUser : CSSPError
    {
        #region Properties in DB
        [Key]
        [StringLength(128)]
        [CSSPDisplayEN(DisplayEN = "Id")]
        [CSSPDisplayFR(DisplayFR = "Id")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the AspNetUsers table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table AspNetUsers")]
        public string Id { get; set; }
        [StringLength(256)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Email")]
        [CSSPDisplayFR(DisplayFR = "Courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Login email for connecting to web site")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel de connexion pour le site web")]
        public string Email { get; set; }
        [CSSPDisplayEN(DisplayEN = "Email confirmed")]
        [CSSPDisplayFR(DisplayFR = "Courriel confirmé")]
        [CSSPDescriptionEN(DescriptionEN = @"Login email has been confirmed by receiving a unique code previously sent to the login email")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel de connexion a été confirmé en recevant un code unique envoyé préalablement au courriel de connextion")]
        public bool EmailConfirmed { get; set; }
        [StringLength(256)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Encrypted Passord")]
        [CSSPDisplayFR(DisplayFR = "Mot de passe crypté")]
        [CSSPDescriptionEN(DescriptionEN = @"Encrypted password so no one can read the password from the database")]
        [CSSPDescriptionFR(DescriptionFR = @"Mot de passe crypté afin que personne puisse lire le mot de passe à partir de la base de données")]
        public string PasswordHash { get; set; }
        [StringLength(256)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Security stamp")]
        [CSSPDisplayFR(DisplayFR = "Timbre de sécurité")]
        [CSSPDescriptionEN(DescriptionEN = @"Security stamp is unique and created from a GUID")]
        [CSSPDescriptionFR(DescriptionFR = @"Timbre de sérité est unique et créé à partir d'un GUID")]
        public string SecurityStamp { get; set; }
        [StringLength(256)]
        [CSSPAllowNull]
        [CSSPDisplayEN(DisplayEN = "Telephone number")]
        [CSSPDisplayFR(DisplayFR = "Numéro de téléphone")]
        [CSSPDescriptionEN(DescriptionEN = @"Telephone number used for the two step login")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de téléphone usilisé lors du login en deux étapes")]
        public string PhoneNumber { get; set; }
        [CSSPDisplayEN(DisplayEN = "Telephone number confirmed")]
        [CSSPDisplayFR(DisplayFR = "Numéro de téléphone confirmé")]
        [CSSPDescriptionEN(DescriptionEN = @"Telephone number confirmed")]
        [CSSPDescriptionFR(DescriptionFR = @"Numéro de téléphone confirmé")]
        public bool PhoneNumberConfirmed { get; set; }
        [CSSPDisplayEN(DisplayEN = "Two factor enabled")]
        [CSSPDisplayFR(DisplayFR = "Deux facteurs activés")]
        [CSSPDescriptionEN(DescriptionEN = @"Two factor enabled")]
        [CSSPDescriptionFR(DescriptionFR = @"Deux facteurs activés")]
        public bool TwoFactorEnabled { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Lockout end date UTC")]
        [CSSPDisplayFR(DisplayFR = "Date de fin de verouillage UTC")]
        [CSSPDescriptionEN(DescriptionEN = @"Lockout end date UTC")]
        [CSSPDescriptionFR(DescriptionFR = @"Date de fin de verouillage UTC")]
        public DateTime? LockoutEndDateUtc { get; set; }
        [CSSPDisplayEN(DisplayEN = "Lockout enabled")]
        [CSSPDisplayFR(DisplayFR = "Verouillage activé")]
        [CSSPDescriptionEN(DescriptionEN = @"Lockout enabled")]
        [CSSPDescriptionFR(DescriptionFR = @"Verouillage activé")]
        public bool LockoutEnabled { get; set; }
        [Range(0, 10000)]
        [CSSPDisplayEN(DisplayEN = "Access failed count")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'échecs d'accès")]
        [CSSPDescriptionEN(DescriptionEN = @"Access failed count")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'échecs d'accès")]
        public int AccessFailedCount { get; set; }
        [StringLength(256)]
        [CSSPDisplayEN(DisplayEN = "User name")]
        [CSSPDisplayFR(DisplayFR = "Nombre d'utilisateur")]
        [CSSPDescriptionEN(DescriptionEN = @"User name should be identical to the Email field")]
        [CSSPDescriptionFR(DescriptionFR = @"Nombre d'utilisateur devrait être identique au champ Email")]
        public string UserName { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual ICollection<Contact> Contacts { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetUser()
        {
        }
        #endregion Constructors
    }
}
