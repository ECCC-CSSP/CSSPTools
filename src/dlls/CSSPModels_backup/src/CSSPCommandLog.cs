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

namespace CSSPModels
{
    public partial class CSSPCommandLog
    {
        #region Properties in DB
        [Key]
        public int CSSPCommandLogID { get; set; }
        [CSSPMaxLength(200)]
        public string AppName { get; set; }
        [CSSPMaxLength(200)]
        public string CommandName { get; set; }
        [CSSPAllowNull]
        public bool? Successful { get; set; }
        [CSSPMaxLength(500)]
        public string ErrorMessage { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime DateTimeUTC { get; set; }
        #endregion Properties in DB

        #region Constructors
        public CSSPCommandLog() : base()
        {
        }
        #endregion Constructors
    }
}
