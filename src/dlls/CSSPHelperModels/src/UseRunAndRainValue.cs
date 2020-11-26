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
    public partial class UseRunAndRainValue
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public bool UseRun { get; set; }
        public double RainValue { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public UseRunAndRainValue()
        {
        }
        #endregion Constructors
    }
}
