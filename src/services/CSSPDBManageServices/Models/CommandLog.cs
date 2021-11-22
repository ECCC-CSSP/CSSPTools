﻿/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManageServices
{
    public partial class CommandLog
    {
        #region Properties in DB
        [Key]
        public int CommandLogID { get; set; }
        [CSSPMaxLength(200)]
        public string AppName { get; set; }
        [CSSPMaxLength(200)]
        public string CommandName { get; set; }
        [CSSPMaxLength(10000000)]
        public string Error { get; set; }
        [CSSPMaxLength(10000000)]
        public string Log { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime DateTimeUTC { get; set; }
        #endregion Properties in DB

        #region Constructors
        public CommandLog() : base()
        {
        }
        #endregion Constructors
    }
}