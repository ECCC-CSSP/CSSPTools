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
    public partial class AspNetUserRole
    {
        #region Properties in DB
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
        public string UserId { get; set; }
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetRoles", FieldName = "Id")]
        public string RoleId { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetUserRole()
        {
        }
        #endregion Constructors
    }
}
