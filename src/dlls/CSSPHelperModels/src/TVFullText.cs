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
    public partial class TVFullText
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string TVPath { get; set; }
        [CSSPMaxLength(255)]
        [CSSPMinLength(1)]
        public string FullText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public TVFullText() : base()
        {
        }
        #endregion Constructors
    }
}
