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
    public partial class AspNetRole
    {
        #region Properties in DB
        [Key]
        [CSSPMaxLength(450)]
        public string Id { get; set; }
        [CSSPMaxLength(256)]
        [CSSPAllowNull]
        public string Name { get; set; }
        [CSSPMaxLength(256)]
        [CSSPAllowNull]
        public string NormalizeName { get; set; }
        [CSSPAllowNull]
        public string ConcurrencyStamp { get; set; }
        #endregion Properties in DB

        #region Constructors
        public AspNetRole()
        {
        }
        #endregion Constructors
    }
}
