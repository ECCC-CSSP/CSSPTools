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
    public partial class MonitoringStatByYear
    {
        #region Properties
        public int Year { get; set; }
        public int MWQMSiteCount { get; set; }
        public int MWQMRunCount { get; set; }
        public int MWQMSampleCount { get; set; }
        #endregion Properties

        #region Constructors
        public MonitoringStatByYear()
        {

        }
        #endregion Constructors
    }

}
