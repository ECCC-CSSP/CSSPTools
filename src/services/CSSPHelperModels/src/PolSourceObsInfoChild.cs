﻿/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class PolSourceObsInfoChild
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        public PolSourceObsInfoEnum PolSourceObsInfo { get; set; }
        [CSSPEnumType]
        public PolSourceObsInfoEnum PolSourceObsInfoChildStart { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfo")]
        [CSSPAllowNull]
        public string PolSourceObsInfoText { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfoChildStart")]
        [CSSPAllowNull]
        public string PolSourceObsInfoChildStartText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolSourceObsInfoChild() : base()
        {
        }
        #endregion Constructors
    }
}