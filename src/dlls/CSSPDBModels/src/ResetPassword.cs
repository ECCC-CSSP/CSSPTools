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

namespace CSSPDBModels
{
    public partial class ResetPassword : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int ResetPasswordID { get; set; }
        [CSSPMaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime ExpireDate_Local { get; set; }
        [CSSPMaxLength(8)]
        public string Code { get; set; }
        #endregion Properties in DB

        #region Constructors
        public ResetPassword() : base()
        {
        }
        #endregion Constructors
    }
}
