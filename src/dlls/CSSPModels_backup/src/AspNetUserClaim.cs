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
    public partial class AspNetUserClaim
    {
        #region Properties in DB
        [Key]
        public int Id { get; set; }
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
        public string UserId { get; set; }
        [CSSPAllowNull]
        public string ClaimType { get; set; }
        [CSSPAllowNull]
        public string ClaimValue { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetUserClaim()
        {
        }
        #endregion Constructors
    }
}
