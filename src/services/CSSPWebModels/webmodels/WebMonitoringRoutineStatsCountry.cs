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
    public partial class WebMonitoringRoutineStatsCountry
    {
        #region Properties
        public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringRoutineStatsCountry()
        {
            MonitoringStatsModelList = new List<MonitoringStatsModel>();
        }
        #endregion Constructors
    }
}
