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
    public partial class TVItemTVAuth
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int TVItemUserAuthID { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVText { get; set; }
        [CSSPRange(1, -1)]
        public int TVItemID1 { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVTypeStr { get; set; }
        [CSSPEnumType]
        public TVAuthEnum TVAuth { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "TVAuthEnum", EnumType = "TVAuth")]
        [CSSPAllowNull]
        public string TVAuthText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVItemTVAuth() : base()
        {
        }
        #endregion Constructors
    }
}
