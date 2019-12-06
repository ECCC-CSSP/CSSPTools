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
    public partial class ResetPassword : LastUpdate
    {
        #region Properties in DB
        [Key]
        [CSSPDisplayEN(DisplayEN = "ResetPassword ID")]
        [CSSPDisplayFR(DisplayFR = "ResetPassword ID")]
        [CSSPDescriptionEN(DescriptionEN = @"Contains the unique ""identifier on each row of the ResetPasswords table")]
        [CSSPDescriptionFR(DescriptionFR = @"Contient l'identifiant unique sur chaque ligne de la table ResetPasswords")]
        public int ResetPasswordID { get; set; }
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        [CSSPDisplayEN(DisplayEN = "Email")]
        [CSSPDisplayFR(DisplayFR = "Courriel")]
        [CSSPDescriptionEN(DescriptionEN = @"Email")]
        [CSSPDescriptionFR(DescriptionFR = @"Courriel")]
        public string Email { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Expire date")]
        [CSSPDisplayFR(DisplayFR = "Date d'expiration")]
        [CSSPDescriptionEN(DescriptionEN = @"Expire date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'expiration")]
        public DateTime ExpireDate_Local { get; set; }
        [StringLength(8)]
        [CSSPDisplayEN(DisplayEN = "Code")]
        [CSSPDisplayFR(DisplayFR = "Code")]
        [CSSPDescriptionEN(DescriptionEN = @"Code --- is a unique code generated on the server and sent to the user email")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'expiration --- est un code généré par le serveur et envoyé au courriel de l'utilisateur")]
        public string Code { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ResetPassword() : base()
        {
        }
        #endregion Constructors
    }
}
