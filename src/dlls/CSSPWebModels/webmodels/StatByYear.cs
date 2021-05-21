/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class StatByYear
    {
        #region Properties
        public int Year { get; set; }
        public int MWQMSiteCount { get; set; }
        public int MWQMRunCount { get; set; }
        public int MWQMSampleCount { get; set; }
        #endregion Properties

        #region Constructors
        public StatByYear()
        {

        }
        #endregion Constructors
    }

}
