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
    public partial class AspNetUserLogin
    {
        #region Properties in DB
        [CSSPMaxLength(128)]
        public string LoginProvider { get; set; }
        [CSSPMaxLength(128)]
        public string ProviderKey { get; set; }
        [CSSPAllowNull]
        public string ProviderDisplayName { get; set; }
        [CSSPMaxLength(450)]
        [CSSPForeignKey(TableName = "AspNetUsers", FieldName = "Id")]
        public string UserId { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetUserLogin()
        {
        }
        #endregion Constructors
    }
}
