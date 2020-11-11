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
    public partial class AspNetUserToken
    {
        #region Properties in DB
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
        public string UserId { get; set; }
        [CSSPMaxLength(128)]
        public string LoginProvider { get; set; }
        [CSSPMaxLength(128)]
        public string Name { get; set; }
        [CSSPAllowNull]
        public string Value { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetUserToken()
        {
        }
        #endregion Constructors
    }
}
