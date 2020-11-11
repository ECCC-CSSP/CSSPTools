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
    public partial class LastUpdateAndTVText
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        public DateTime LastUpdateAndTVTextDate_UTC { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime LastUpdateDate_Local { get; set; }
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string TVText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LastUpdateAndTVText() : base()
        {
        }
        #endregion Constructors
    }
}
