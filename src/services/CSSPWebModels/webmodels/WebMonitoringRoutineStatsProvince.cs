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
    public partial class WebMonitoringRoutineStatsProvince
    {
        #region Properties
        public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringRoutineStatsProvince()
        {
            MonitoringStatsModelList = new List<MonitoringStatsModel>();
        }
        #endregion Constructors
    }
}
