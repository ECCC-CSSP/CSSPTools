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
    public partial class WebMonitoringRoutineStatsByYearForCountry
    {
        #region Properties
        public List<MonitoringStatsByYearModel> MonitoringStatsByYearModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringRoutineStatsByYearForCountry()
        {
            MonitoringStatsByYearModelList = new List<MonitoringStatsByYearModel>();
        }
        #endregion Constructors
    }
}
