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
    public partial class WebMonitoringOtherStatsByYearForProvince
    {
        #region Properties
        public List<MonitoringStatsByYearModel> MonitoringStatsByYearModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringOtherStatsByYearForProvince()
        {
            MonitoringStatsByYearModelList = new List<MonitoringStatsByYearModel>();
        }
        #endregion Constructors
    }
}
