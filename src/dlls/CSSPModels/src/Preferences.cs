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
    public partial class Preference
    {
        #region Properties in DB
        [Key]
        public int PreferenceID { get; set; }
        [CSSPMaxLength(200)]
        public string AzureStore { get; set; }
        [CSSPMaxLength(200)]
        public string LoginEmail { get; set; }
        [CSSPMaxLength(100)]
        public string Password { get; set; }
        public bool? HasInternetConnection { get; set; }
        public bool? LoggedIn { get; set; }
        [CSSPMaxLength(300)]
        [CSSPAllowNull]
        public string Token { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Preference() : base()
        {
        }
        #endregion Constructors
    }
}
