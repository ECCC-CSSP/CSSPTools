﻿/*
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
    public partial class TVTextLanguage
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public string TVText { get; set; }
        [CSSPEnumType]
        public LanguageEnum Language { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "LanguageEnum", EnumType = "Language")]
        [CSSPAllowNull]
        public string LanguageText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVTextLanguage() : base()
        {
        }
        #endregion Constructors
    }
}
