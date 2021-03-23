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
    public partial class ValRun
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [Range(1.0D, 10000000.0D)]
        public double val { get; set; }
        [Range(1, 20)]
        public int run { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ValRun()
        {
        }
        #endregion Constructors
    }
}
