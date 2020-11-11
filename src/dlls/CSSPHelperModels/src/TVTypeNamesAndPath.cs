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
    public partial class TVTypeNamesAndPath
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVTypeName { get; set; }
        [CSSPRange(1, -1)]
        public int Index { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVPath { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVTypeNamesAndPath() : base()
        {
        }
        #endregion Constructors
    }
}
