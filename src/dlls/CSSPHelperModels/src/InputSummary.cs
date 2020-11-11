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
    public partial class InputSummary
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public string Summary { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public InputSummary() : base()
        {
        }
        #endregion Constructors
    }
}
