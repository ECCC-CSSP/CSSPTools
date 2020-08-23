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
        public bool? AzureLoggedIn { get; set; }
        [CSSPMaxLength(300)]
        [CSSPAllowNull]
        public string AzureToken { get; set; }
        public bool? LocalLoggedIn { get; set; }
        [CSSPMaxLength(300)]
        [CSSPAllowNull]
        public string LocalToken { get; set; }
        #endregion Properties in DB

        #region Constructors
        public Preference() : base()
        {
        }
        #endregion Constructors
    }
}
