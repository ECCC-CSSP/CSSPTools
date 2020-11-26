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
    public partial class ValRun
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public double val { get; set; }
        public int run { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ValRun()
        {
        }
        #endregion Constructors
    }
}
