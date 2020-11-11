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

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class LoginModel
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(100)]
        [CSSPMinLength(5)]
        public string LoginEmail { get; set; }
        [CSSPMaxLength(50)]
        [CSSPMinLength(5)]
        public string Password { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LoginModel() : base()
        {
        }
        #endregion Constructors
    }
}
