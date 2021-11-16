/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class MonitoringStatBySeason
    {
        #region Properties
        [CSSPEnumType]
        public SeasonEnum Season { get; set; }
        public int MWQMSiteCount { get; set; }
        public int MWQMRunCount { get; set; }
        public int MWQMSampleCount { get; set; }
        #endregion Properties

        #region Constructors
        public MonitoringStatBySeason()
        {

        }
        #endregion Constructors
    }

}
