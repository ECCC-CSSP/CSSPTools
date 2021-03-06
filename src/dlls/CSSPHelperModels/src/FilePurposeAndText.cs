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
    public partial class FilePurposeAndText
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        public FilePurposeEnum FilePurpose { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "FilePurposeEnum", EnumType = "FilePurpose")]
        [CSSPAllowNull]
        public string FilePurposeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public FilePurposeAndText() : base()
        {
        }
        #endregion Constructors
    }
}
