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
    public partial class WebMonitoringOtherStatsCountry
    {
        #region Properties
        public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringOtherStatsCountry()
        {
            MonitoringStatsModelList = new List<MonitoringStatsModel>();
        }
        #endregion Constructors
    }
}
