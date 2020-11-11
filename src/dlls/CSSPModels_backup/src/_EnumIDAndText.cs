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
    [NotMapped]
    public partial class EnumIDAndText
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int? EnumID { get; set; }
        [CSSPMaxLength(200)]
        [CSSPAllowNull]
        public string EnumText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public EnumIDAndText() : base()
        {
        }
        #endregion Constructors
    }
}
