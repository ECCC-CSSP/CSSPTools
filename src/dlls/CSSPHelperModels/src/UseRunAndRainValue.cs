/*
 * Manually edited
 * 
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class UseRunAndRainValue
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public bool UseRun { get; set; }
        [Range(0.0D, 300.0D)]
        public double RainValue { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public UseRunAndRainValue()
        {
        }
        #endregion Constructors
    }
}
