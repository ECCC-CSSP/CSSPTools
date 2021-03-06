﻿/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class DBTable
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string TableName { get; set; }
        [CSSPMaxLength(3)]
        [CSSPMinLength(1)]
        public string Plurial { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public DBTable() : base()
        {
        }
        #endregion Constructors
    }
}
