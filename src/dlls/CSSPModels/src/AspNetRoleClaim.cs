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
    public partial class AspNetRoleClaim
    {
        #region Properties in DB
        [Key]
        public string Id { get; set; }
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetRoles", FieldName = "Id")]
        public string RoleId { get; set; }
        [CSSPAllowNull]
        public string ClaimType { get; set; }
        [CSSPAllowNull]
        public string ClaimValue { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetRoleClaim()
        {
        }
        #endregion Constructors
    }
}
